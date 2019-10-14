using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace BenchmarksServerDotNetCore3.Controllers
{
    [Route("mvc")]
    public class JsonSerializeController : Controller
    {
        private static readonly DateTimeOffset BaseDateTime = new DateTimeOffset(new DateTime(2019, 04, 23));

        private static Benchmarks.Serializers.Models.ThousandSmallClassList _thousandSmallClassList 
            = new Benchmarks.Serializers.Models.ThousandSmallClassList();

        //[HttpGet("plaintext")]
        //public IActionResult Plaintext()
        //{
        //    return new PlainTextActionResult();
        //}

        //[HttpGet("json")]
        //[Produces("application/json")]
        //public object Json()
        //{
        //    return new { message = "Hello, World!" };
        //}

        //[HttpGet("json2k")]
        //[Produces("application/json")]
        //public object Json2k() => _entries;

        //[HttpPost("jsoninput")]
        //[Consumes("application/json")]
        //public ActionResult JsonInput([FromBody] List<Entry> entry) => Ok();

        //[HttpPost("DeserializeSmallClass")]
        //[Consumes("application/json")]
        //public ActionResult DeserializeSmallClass([FromBody]Benchmarks.Serializers.Models.SmallClass smallClass) => Ok();

        [HttpPost("DeserializeThousandSmallClassList")]
        [Consumes("application/json")]
        public ActionResult DeserializeThousandSmallClassList([FromBody]Benchmarks.Serializers.Models.ThousandSmallClassList obj) => Ok();

        [HttpGet("SerializeThousandSmallClassList")]
        [Produces("application/json")]
        public object SerializeThousandSmallClassList() => _thousandSmallClassList;


        [HttpGet("ccc")]
        public ActionResult ccc() => Ok();

        //[HttpGet("view")]
        //public ViewResult Index()
        //{
        //    return View();
        //}

        //private class PlainTextActionResult : IActionResult
        //{
        //    private static readonly byte[] _helloWorldPayload = Encoding.UTF8.GetBytes("Hello, World!");

        //    public Task ExecuteResultAsync(ActionContext context)
        //    {
        //        var response = context.HttpContext.Response;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.ContentType = "text/plain";
        //        var payloadLength = _helloWorldPayload.Length;
        //        response.ContentLength = payloadLength;
        //        return response.Body.WriteAsync(_helloWorldPayload, 0, payloadLength);
        //    }
        //}
    }

    //public class Entry
    //{
    //    public Attributes Attributes { get; set; }
    //    public string ContentType { get; set; }
    //    public string Id { get; set; }
    //    public bool Managed { get; set; }
    //    public string[] Tags { get; set; }
    //}

    //public class Attributes
    //{
    //    public DateTimeOffset Created { get; set; }
    //    public bool Enabled { get; set; }
    //    public DateTimeOffset Expires { get; set; }
    //    public DateTimeOffset NotBefore { get; set; }
    //    public string RecoveryLevel { get; set; }
    //    public DateTimeOffset Updated { get; set; }
    //}
}