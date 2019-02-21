using System;
using System.Collections.Generic;
using JsonPatchExample.Models.Entity;
using JsonPatchExample.Models.PatchDeltas;
using Microsoft.AspNetCore.JsonPatch;

namespace JsonPatchExample.BusinessLogic
{
    public class PersonLogic
    {
        public PersonPatchEntity Patch(JsonPatchDocument<PersonPatchEntity> patchDocument)
        {
            var original = GetPerson();

            var delta = new PersonPatchDelta(original, patchDocument);

            if (delta.LastName.HasChanged && delta.LastName.NewValue == "Doe")
            {
                throw new Exception("Last name cannot be 'Doe'");
            }

            if (delta.Address.Town.HasChanged && delta.Address.Town.NewValue == "Grimsby")
            {
                throw new Exception("Nobody wants to move there");
            }

            return delta.Patched;
        }

        private static PersonPatchEntity GetPerson()
        {
            var original = new PersonPatchEntity()
            {
                FirstName = "John",
                LastName = "Smith",
                DateOfBirth = new DateTime(1990, 01, 02),
                FavouriteNumbers = new List<int>() {7, 11, 42},
                MobileNumber = "07777777777",
                TelephoneNumber = "01111 888888",
                Address = new AddressPatchEntity()
                {
                    Street = "10, New Road",
                    Location = "Hamlington",
                    Town = "London",
                    PostalCode = "NW1 4UP"
                }
            };
            return original;
        }
    }
}