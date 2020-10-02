using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Something.Application;
using Something.Security;

namespace SomethingUI.Controllers
{
    [Authorize]
    [ApiController]
    public class ElseController : ControllerBase
    {
        private readonly ISomethingElseCreateInteractor createElseInteractor;
        private readonly ISomethingElseReadInteractor readElseInteractor;
        private readonly ISomethingElseUpdateInteractor updateInteractor;
        private readonly ISomethingElseDeleteInteractor deleteInteractor;

        public ElseController(ISomethingElseCreateInteractor createElseInteractor, ISomethingElseReadInteractor readElseInteractor, ISomethingElseUpdateInteractor updateInteractor, ISomethingElseDeleteInteractor deleteInteractor)
        {
            this.createElseInteractor = createElseInteractor;
            this.readElseInteractor = readElseInteractor;
            this.updateInteractor = updateInteractor;
            this.deleteInteractor = deleteInteractor;
        }
        [HttpPost]
        [Route("api/thingselse")]
        public ActionResult CreateElse([FromForm] string name, [FromForm] string[] othername)
        {
            if (name.Length < 1)
                return GetAllSomethingElseIncludeSomething();

            createElseInteractor.CreateSomethingElse(name, othername);
            return GetAllSomethingElseIncludeSomething();
        }
        [HttpPut]
        [Route("api/thingselse/{id}")]
        public ActionResult Put(int id, [FromForm] string othername)
        {
            if (id < 1)
                return GetAllSomethingElseIncludeSomething();

            updateInteractor.UpdateSomethingElseAddSomething(id, othername);
            return GetAllSomethingElseIncludeSomething();
        }
        [HttpDelete]
        [Route("api/thingselse/{else_id}/{something_id}")]
        public ActionResult Delete(int else_id, int something_id)
        {
            if (else_id < 1 || something_id < 1)
                return GetAllSomethingElseIncludeSomething();

            updateInteractor.UpdateSomethingElseDeleteSomething(else_id, something_id);
            return GetAllSomethingElseIncludeSomething();
        }
        [HttpDelete]
        [Route("api/thingselse/{else_id}")]
        public ActionResult Delete(int else_id)
        {
            if (else_id < 1)
                return GetAllSomethingElseIncludeSomething();

            deleteInteractor.DeleteSomethingElse(else_id);
            return GetAllSomethingElseIncludeSomething();
        }
        [HttpGet]
        [Route("api/thingselse")]
        public ActionResult GetElseList()
        {
            return GetAllSomethingElseIncludeSomething();
        }
        private ActionResult GetAllSomethingElseIncludeSomething()
        {
            var result = readElseInteractor.GetSomethingElseIncludingSomethingsList();
            return Ok(result);
        }
    }
}
