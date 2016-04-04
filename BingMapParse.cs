      // Read out the results
      // Fragile, might need to change if the Bing API changes
      var results = JObject.Parse(json);
      var resources = results["resourceSets"][0]["resources"];
      if (!resources.HasValues)
      {
        result.Message = $"Could not find '{name}' as a location";
      }
      else
      {
        var confidence = (string)resources[0]["confidence"];
        if (confidence != "High")
        {
          result.Message = $"Could not find a confident match for '{name}' as a location";
        }
        else
        {
          var coords = resources[0]["geocodePoints"][0]["coordinates"];
          result.Latitude = (double)coords[0];
          result.Longitude = (double)coords[1];
          result.Success = true;
          result.Message = "Success";
        }
      }
