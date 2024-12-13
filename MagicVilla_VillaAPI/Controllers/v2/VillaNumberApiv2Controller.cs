using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers.v2;

[ApiController]
[Route("api/v{version:apiVersion}/villaNumberAPI")]
[ApiVersion("2.0")]
public class VillaNumberApiv2Controller : ControllerBase
{

    // [MapToApiVersion("2.0")]
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }
}