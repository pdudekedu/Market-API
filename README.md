In appsettings.json is located configuration of connection string and some options for reading from CSV, including path, batch size and headers names.

# ENDPOINTS:
  - api/assets/update POST - triggers read from file to DB  
  - api/assets GET - gets asset IDs for property set to specific value  
  body:  
  {  
  "property": string,  
  "value": bool  
  }  
  - api/assets POST - sets property for asset  
  body:  
  {  
  "assetid": int,  
  "property": string,  
  "value": bool,  
  "timestamp": datetime
  }  
      
