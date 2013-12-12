namespace ByndyuSoft.Infrastructure.Web.ActionResults
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    internal class MyJsonResult : JsonResult
    {
        public MyJsonResult(object data, string contentType, Encoding contentEncoding)
        {
            Data = data;
            ContentType = contentType;
            ContentEncoding = contentEncoding;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType)
                                       ? ContentType
                                       : "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Data == null)
                return;

            WriteJson(Data, response.Output);
        }

        private static void WriteJson(object value, TextWriter textWriter)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            settings.Converters.Add(new StringEnumConverter());
            settings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "d" });
            JsonSerializer.Create(settings).Serialize(textWriter, value);
        }
    }
}