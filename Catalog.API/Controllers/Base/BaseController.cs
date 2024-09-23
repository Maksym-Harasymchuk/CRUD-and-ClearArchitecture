using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.Base
{
    [Route("api/[controller]/[Action]")]
    //[Authorize]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
