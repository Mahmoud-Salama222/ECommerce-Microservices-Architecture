using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{

    [ApiVersion("1")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
