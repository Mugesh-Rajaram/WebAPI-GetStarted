using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;

namespace WebAPIGetStarted
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //Step:- 1
            //config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));
            //config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            //Step: -2
            //var jsonMediaTypeFormatter = new JsonMediaTypeFormatter();
            //config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonMediaTypeFormatter));
            //Step:- 3
            //var xmlMediaTypeFormatter = new XmlMediaTypeFormatter();
            //config.Services.Replace(typeof(IContentNegotiator), new XmlContentNegotiator(xmlMediaTypeFormatter));
        }
    }

    //Step:- 4
    //This operation can be at Controller level
    //Reference URL for the below code : https://stackoverflow.com/questions/17791619/force-xml-return-on-some-web-api-controllers-while-maintaining-default-json
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MyControllerConfigAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            // yes, this instance is from the global formatters
            XmlMediaTypeFormatter globalXmlFormatterInstance = controllerSettings.Formatters.XmlFormatter;

            controllerSettings.Formatters.Clear();

            // NOTE: do not make any changes to this formatter instance as it reference to the instance from the global formatters.
            // if you need custom settings for a particular controller(s), then create a new instance of Xml formatter and change its settings.
            controllerSettings.Formatters.Add(globalXmlFormatterInstance);
        }
    }

    //This operation will be performed globally
    //Reference URL for below code : https://www.strathweb.com/2013/06/supporting-only-json-in-asp-net-web-api-the-right-way/
    public class JsonContentNegotiator : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter _jsonFormatter;

        public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
        {
            _jsonFormatter = formatter;
        }

        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            var result = new ContentNegotiationResult(_jsonFormatter, new MediaTypeHeaderValue("application/json"));
            return result;
        }
    }
    //This operation will be performed globally
    //Reference URL for below code : https://www.strathweb.com/2013/06/supporting-only-json-in-asp-net-web-api-the-right-way/
    public class XmlContentNegotiator : IContentNegotiator
    {
        private readonly XmlMediaTypeFormatter _xmlFormatter;

        public XmlContentNegotiator(XmlMediaTypeFormatter formatter)
        {
            _xmlFormatter = formatter;
        }

        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            var result = new ContentNegotiationResult(_xmlFormatter, new MediaTypeHeaderValue("application/xml"));
            return result;
        }
    }
}
