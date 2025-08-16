using Lab.Mediator.ValidationExample.Core.DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Mediator.ValidationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult Create([FromBody] WriteUserDto writeUser)
        {
            return Created();
        }
    }
}
