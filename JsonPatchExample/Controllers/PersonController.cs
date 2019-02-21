using System.Web.Http;
using JsonPatchExample.BusinessLogic;
using JsonPatchExample.Models.DTO;
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
            var entityPatch = mapper.Map(patchDocument);

            var logic = new PersonLogic();
            var result = logic.Patch(entityPatch);

            return Ok(result);
        }
    }
}
