using System.Web.Http;
using JsonPatchExample.BusinessLogic;
using JsonPatchExample.Models.DTO;
using JsonPatchExample.Models.Entity;
using JsonPatchExample.Models.Mappers;
using Microsoft.AspNetCore.JsonPatch;

namespace JsonPatchExample.Controllers
{
    [RoutePrefix("api/person")]
    public class PersonController : ApiController
    {
        [Route("{id}")]
        [HttpPatch]
        public IHttpActionResult PatchPerson(JsonPatchDocument<PersonPatchDto> patchDocument)
        {
            var mapper = new PersonPatchMapper();
            JsonPatchDocument<PersonPatchEntity> entityPatch = mapper.Map(patchDocument);

            var logic = new PersonLogic();
            PersonPatchEntity result = logic.Patch(entityPatch);

            return Ok(result);
        }
    }
}
