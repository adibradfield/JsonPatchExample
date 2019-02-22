# JsonPatchExample

## Benefits
- Allows patch documents of multiple versioned DTO's to be mapped to a patch document of a single Application Layer object
- The mapper assumes that properties have the same name, but this can be overridden with a simple syntax
- In the mapper, you can transform data, and even change the type
- The same features can be used to map to properties of member objects (i.e. an address object on a customer)
- Provides a clearer syntax for performing validation in the application layer

## Example Request
Endpoint: /api/person/1

```json
[
  {
    "op": "replace",
    "path": "/firstName",
    "value": "Jimmy"
  },
  {
    "op": "replace",
    "path": "/surname",
    "value": "O'Keef"
  },
  {
    "op": "replace",
    "path": "/address/postcode",
    "value": "M1 0AA"
  },
  {
    "op": "replace",
    "path": "/address/town",
    "value": "Manchester"
  }
]
```

## Things to try
- Change the surname (Data transformed in mapper, and also mapped to "LastName" property)
- Change the addresses town "Grimsby" (Validation in application layer)

## Important Files
- [PersonController](JsonPatchExample/Controllers/PersonController.cs) - Shows how the mapper is used
- [PersonPatchMapper](JsonPatchExample/Models/Mappers/PersonPatchMapper.cs) - Shows how the mapper is defined
- [PersonLogic](JsonPatchExample/BusinessLogic/PersonLogic.cs) - Shows how to use a PatchDelta to make validation clearer
- [PersonPatchDelta](JsonPatchExample/Models/PatchDeltas/PersonPatchDelta.cs) - Shows how a patch delta is defined
