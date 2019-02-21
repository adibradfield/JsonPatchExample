using JsonPatchExample.Models.DTO;
using JsonPatchExample.Models.Entity;
using JsonPatchHelper;

namespace JsonPatchExample.Models.Mappers
{
    public class PersonPatchMapper : JsonPatchMapper<PersonPatchDto, PersonPatchEntity>
    {
        public PersonPatchMapper()
        {
            MappingOverrides.AddMapping("/surname", "/lastName", SurnameConverter);
            MappingOverrides.AddMapping("/phoneNumber", "/telephoneNumber");
            MappingOverrides.AddMapping("/address/postCode", "/address/postalCode");
        }

        private object SurnameConverter(object value)
        {
            if (value is string surname)
            {
                return surname + "-Barreled";
            }

            return null;
        }
    }
}