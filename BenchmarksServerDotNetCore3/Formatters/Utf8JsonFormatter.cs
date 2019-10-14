using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Utf8Json;

namespace BenchmarksServerDotNetCore3.Formatters
{
    internal sealed class Utf8JsonInputFormatter1 : IInputFormatter
    {
        private readonly IJsonFormatterResolver _resolver;

        public Utf8JsonInputFormatter1() : this(null) { }
        public Utf8JsonInputFormatter1(IJsonFormatterResolver resolver)
        {
            _resolver = resolver ?? JsonSerializer.DefaultResolver;
        }

        public bool CanRead(InputFormatterContext context) => context.HttpContext.Request.ContentType.StartsWith("application/json");

        public async Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Body.CanSeek && request.Body.Length == 0)
                return await InputFormatterResult.NoValueAsync();

            var result = await JsonSerializer.NonGeneric.DeserializeAsync(context.ModelType, request.Body, _resolver);
            return await InputFormatterResult.SuccessAsync(result);
        }
    }

    
    internal sealed class Utf8JsonOutputFormatter1 : IOutputFormatter
    {
        private readonly IJsonFormatterResolver _resolver;

        public Utf8JsonOutputFormatter1() : this(null) { }
        public Utf8JsonOutputFormatter1(IJsonFormatterResolver resolver)
        {
            _resolver = resolver ?? JsonSerializer.DefaultResolver;
        }

        public bool CanWriteResult(OutputFormatterCanWriteContext context) => true;

        
        public async Task WriteAsync(OutputFormatterWriteContext context)
        {
            if (!context.ContentTypeIsServerDefined)
                context.HttpContext.Response.ContentType = "application/json";

            if (context.ObjectType == typeof(object))
            {
                await JsonSerializer.NonGeneric.SerializeAsync(context.HttpContext.Response.Body, context.Object, _resolver);
            }
            else
            {
                await JsonSerializer.NonGeneric.SerializeAsync(context.ObjectType, context.HttpContext.Response.Body, context.Object, _resolver);
            }
        }

    }
}
