using Owin;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SimpleWebServer
{
    public class Startup
    {
        /// <summary>
        /// WebApp.Start 함수
        /// </summary>
        /// <param name="appBuilder"></param>
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            appBuilder.UseWebApi(config);
        }
    }
}
