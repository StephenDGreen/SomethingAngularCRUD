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

        public ElseController(ISomethingElseCreateInteractor createElseInteractor, ISomethingElseReadInteractor readElseInteractor, ISomethingElseUpdateInteractor updateInteractor)
        {
            this.createElseInteractor = createElseInteractor;
            this.readElseInteractor = readElseInteractor;
            this.updateInteractor = updateInteractor;
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
