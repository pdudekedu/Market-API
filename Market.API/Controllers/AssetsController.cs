using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Market.API.Settings;
using Market.Data;
using Market.Models;
using Market.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;

namespace Market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPropertyValuesRepository _propertyValuesRepository;
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IAssetsRepository _assetsRepository;
        private readonly UpdateDataSettings _updateDataSettings;

        public AssetsController(IConfiguration configuration, 
            IOptions<UpdateDataSettings> updateDataSettings, 
            IPropertyValuesRepository propertyValuesRepository,
            IPropertiesRepository propertiesRepository,
            IAssetsRepository assetsRepository)
        {
            _updateDataSettings = updateDataSettings?.Value;
            _configuration = configuration;
            _propertyValuesRepository = propertyValuesRepository;
            _propertiesRepository = propertiesRepository;
            _assetsRepository = assetsRepository;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update()
        {
            if (string.IsNullOrEmpty(_updateDataSettings?.Path))
            {
                Console.WriteLine("No file path set.");
                return NotFound();
            }

            int result = 0;
            try
            {
                using (CSVParser parser = new CSVParser(_updateDataSettings))
                {
                    if (!parser.ValidHeaders)
                    {
                        return BadRequest("No valid headers found.");
                    }

                    IDictionary<string, int> properties = await _propertiesRepository.GetPropertiesForSearching();
                    if (properties == null || !properties.Any())
                        return NotFound("No properties found.");
                    IEnumerable<int> assets = await _assetsRepository.GetAssetsIDs();
                    if (assets == null || !assets.Any())
                        return NotFound("No assets found.");

                    int batchSize = Math.Max(_updateDataSettings.BatchSize, 2);
                    assets = assets.ToHashSet();
                    List<PropertyValue> values = new List<PropertyValue>();
                    List<Task<int>> tasks = new List<Task<int>>();
                    while (!parser.EndOfData)
                    {
                        long lineNumber = parser.LineNumber;
                        if (parser.ReadPropertyValue(assets, properties, out PropertyValue propertyValue, out string error))
                        {
                            values.Add(propertyValue);
                            if (values.Count >= batchSize)
                            {
                                tasks.Add(_propertyValuesRepository.UpdateIfNewer(_configuration, values));
                                values = new List<PropertyValue>();
                            }
                        }
                        else
                            Console.WriteLine($"Line {lineNumber}: {error}");
                    }
                    if (values.Count >= 0)
                        tasks.Add(_propertyValuesRepository.UpdateIfNewer(_configuration, values));

                    await Task.WhenAll(tasks.ToArray());
                    result = tasks.Sum(x => x.Result);
                }
                return Ok(result);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Source file not found.");
                return BadRequest("Source file not found.");
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAssetsForProperty([FromBody] PropertyValueToSearch propertyValue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!await _propertiesRepository.PropertyExists(propertyValue.Property))
            {
                ModelState.AddModelError(nameof(PropertyValueToSearch.Property), $"No property of name '{propertyValue.Property}' found.");
                return BadRequest(ModelState);
            }

            try
            {
                IEnumerable<int> result = await _assetsRepository.GetAssetsIDs(propertyValue);
                if (!result.Any())
                    return NotFound();
                else
                    return Ok(result);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetPropertValue([FromBody] PropertyValueToSet propertyValue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int? propertyId = await _propertiesRepository.GetPropertyId(propertyValue.Property);
                if (propertyId == null)
                {
                    ModelState.AddModelError(nameof(PropertyValueToSet.Property), $"No property of name '{propertyValue.Property}' found.");
                    return NotFound(ModelState);
                }
                if (!await _assetsRepository.AssetExists(propertyValue.AssetId.Value))
                {
                    ModelState.AddModelError(nameof(PropertyValueToSet.AssetId), $"No asset of ID {propertyValue.AssetId} found.");
                    return NotFound(ModelState);
                }

                int result = await _propertyValuesRepository.UpdateIfNewer(propertyValue);
                if (result > 0)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
