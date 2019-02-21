using System;
using System.Collections.Generic;

namespace JsonPatchExample.Models.Entity
{
    public class PersonPatchEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> FavouriteNumbers { get; set; }
        public AddressPatchEntity Address { get; set; }
    }
}