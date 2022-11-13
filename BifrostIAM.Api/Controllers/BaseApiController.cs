using Microsoft.AspNetCore.Mvc;
using BifrostIAM.Api.Filter;

namespace BifrostIAM.Api.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
