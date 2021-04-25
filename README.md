# ResturantOpeningHours

## although the json object works well but it could be better by making it much simpler 

 "thursday": [
 {
 "type": "open_hours",
 "openhour": 36000,
 "closehour":65800
 }
 ],
 
 personally i think this should be in the format above. as this will save excution time and also server resources. 

## this project was done using c# 
## Design Patterns: Mediator 

## the following packages should be updated. 

```
<ItemGroup>
    <PackageReference Include="MediatR" Version="9.0.0" />
    <PackageReference Include="MediatR.Extensions.Microsoft.DependencyInjection" Version="9.0.0" />
    <PackageReference Include="Swashbuckle.AspNetCore.Swagger" Version="5.6.3" />
    <PackageReference Include="Swashbuckle.AspNetCore.SwaggerGen" Version="5.6.3" />
    <PackageReference Include="Swashbuckle.AspNetCore.SwaggerUI" Version="5.6.3" />
</ItemGroup>
```

  ## please remember to run a dotnet restore on this solution. 
  
  
  ## Test Cases
  
  ### Open and close same day
  ```
  {
  "monday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "tuesday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "wednesday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "thursday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "friday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "saturday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "sunday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ]
}
```


### Open and close different days

```
{
  "monday": [
    {
      "type": "close",
      "value": 1619258400
    },
    {
      "type": "open",
      "value": 1619283600
    }
  ],
  "tuesday": [
    {
      "type": "close",
      "value": 1619258400
    },
    {
      "type": "open",
      "value": 1619283600
    }
  ],
  "wednesday": [
    {
      "type": "close",
      "value": 1619258400
    },
    {
      "type": "open",
      "value": 1619283600
    }
  ],
  "thursday": [
    {
      "type": "close",
      "value": 1619258400
    },
    {
      "type": "open",
      "value": 1619283600
    }
  ],
  "friday": [
    {
      "type": "close",
      "value": 1619258400
    },
    {
      "type": "open",
      "value": 1619283600
    }
  ],
  "saturday": [
    {
      "type": "close",
      "value": 1619258400
    },
    {
      "type": "open",
      "value": 1619283600
    }
  ],
  "sunday": [
    {
      "type": "close",
      "value": 1619258400
    },
    {
      "type": "open",
      "value": 1619283600
    }
  ]
}
```

### Open and close multiple times a day

```
{
  "monday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619269200
    },
    {
      "type": "open",
      "value": 1619272800
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "tuesday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619269200
    },
    {
      "type": "open",
      "value": 1619272800
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "wednesday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619269200
    },
    {
      "type": "open",
      "value": 1619272800
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "thursday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619269200
    },
    {
      "type": "open",
      "value": 1619272800
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "friday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619269200
    },
    {
      "type": "open",
      "value": 1619272800
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "saturday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619269200
    },
    {
      "type": "open",
      "value": 1619272800
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ],
  "sunday": [
    {
      "type": "open",
      "value": 1619258400
    },
    {
      "type": "close",
      "value": 1619269200
    },
    {
      "type": "open",
      "value": 1619272800
    },
    {
      "type": "close",
      "value": 1619283600
    }
  ]
}
```
