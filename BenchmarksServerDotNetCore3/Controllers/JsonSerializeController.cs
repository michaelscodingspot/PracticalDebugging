using Microsoft.AspNetCore.Mvc;

namespace BenchmarksServerDotNetCore3.Controllers
{
[Route("mvc")]
public class JsonSerializeController : Controller
{

    private static Benchmarks.Serializers.Models.ThousandSmallClassList _thousandSmallClassList 
        = new Benchmarks.Serializers.Models.ThousandSmallClassList(); 
    
    [HttpPost("DeserializeThousandSmallClassList")]
    [Consumes("application/json")]
    public ActionResult DeserializeThousandSmallClassList([FromBody]Benchmarks.Serializers.Models.ThousandSmallClassList obj) => Ok();

    [HttpGet("SerializeThousandSmallClassList")]
    [Produces("application/json")]
    public object SerializeThousandSmallClassList() => _thousandSmallClassList;
}
}