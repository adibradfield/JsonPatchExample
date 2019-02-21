using System;
using JsonPatchExample.Models.Entity;
using JsonPatchHelper;
using Microsoft.AspNetCore.JsonPatch;

namespace JsonPatchExample.Models.PatchDeltas
{
    public class PersonPatchDelta : PatchDelta<PersonPatchEntity>
    {
        public PersonPatchDelta(PersonPatchEntity original, JsonPatchDocument<PersonPatchEntity> patchDocument)
        {
            this.Load(original, patchDocument);
        }

        public PropertyDelta<string> FirstName { get; set; }
        public PropertyDelta<string> LastName { get; set; }
        public PropertyDelta<string> TelephoneNumber { get; set; }
        public PropertyDelta<string> MobileNumber { get; set; }
        public PropertyDelta<DateTime> DateOfBirth { get; set; }
        //public PropertyDelta<List<int>> FavouriteNumbers { get; set; }

        public AddressPatchDelta Address { get; set; }
    }
}