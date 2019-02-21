using System;
using System.Collections.Generic;

namespace JsonPatchExample.Models.DTO
{
    public class PersonPatchDto
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> FavouriteNumbers { get; set; }
        public AddressPatchDto Address { get; set; }
    }
}