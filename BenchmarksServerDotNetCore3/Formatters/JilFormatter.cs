using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Jil;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace BenchmarksServerDotNetCore3.Formatters
{
    //public class JilFormatter2 : IInputFormatter
    //{
    //    private readonly Options _jilOptions;

    //    public bool CanRead(InputFormatterContext context)
    //    {
    //        if (context.ModelType == null)
    //        {
    //            throw new ArgumentNullException("type");
    //        }
    //        return true;
    //    }

    //    public Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
    //    {
    //        var httpContextRequest = context.HttpContext.Request;

    //        //if (!httpContextRequest.ContentLength.HasValue || httpContextRequest.ContentLength == 0)
    //        //{
    //        //    return await InputFormatterResult.FailureAsync();
    //        //}

    //        using (var reader = context.ReaderFactory(httpContextRequest.Body, Encoding.UTF8))
    //        {
    //            //string readToEndAsync = await reader.ReadToEndAsync();
    //            //blogPost.Content = readToEndAsync;
    //            //return await InputFormatterResult.SuccessAsync(blogPost);
    //            return Task.FromResult(this.DeserializeFromStream(context.ModelType, reader.));
    //        }

    //        return Task.FromResult(this.DeserializeFromStream(context.ModelType, context.));           
    //    }

    //    private object DeserializeFromStream(Type type,Stream readStream)
    //    {
    //        try
    //        {
    //            using (var reader = new StreamReader(readStream))
    //            {
    //                MethodInfo method = typeof(JSON).GetMethod("Deserialize", new Type[] { typeof(TextReader),typeof(Options) });
    //                MethodInfo generic = method.MakeGenericMethod(type);
    //                return generic.Invoke(this, new object[]{reader, _jilOptions});
    //            }
    //        }
    //        catch
    //        {
    //            return null;
    //        }

    //    }
    //}
    public class JilFormatter : MediaTypeFormatter
    {
        private readonly Options _jilOptions;
        public JilFormatter()
        {
            _jilOptions=new Options(dateFormat:DateTimeFormat.ISO8601);
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true));
            SupportedEncodings.Add(new UnicodeEncoding(bigEndian: false, byteOrderMark: true, throwOnInvalidBytes: true));
        }
        public override bool CanReadType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return true;
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
	        return Task.FromResult(this.DeserializeFromStream(type, readStream));           
        }


        private object DeserializeFromStream(Type type,Stream readStream)
        {
            try
            {
                using (var reader = new StreamReader(readStream))
                {
                    MethodInfo method = typeof(JSON).GetMethod("Deserialize", new Type[] { typeof(TextReader),typeof(Options) });
                    MethodInfo generic = method.MakeGenericMethod(type);
                    return generic.Invoke(this, new object[]{reader, _jilOptions});
                }
            }
            catch
            {
                return null;
            }

        }


        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, TransportContext transportContext)
        {
            var streamWriter = new StreamWriter(writeStream);
            JSON.Serialize(value, streamWriter, _jilOptions);
            streamWriter.Flush();
            return Task.FromResult(writeStream);
        }
    }
}
