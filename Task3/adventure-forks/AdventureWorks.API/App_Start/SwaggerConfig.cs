using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using WebActivatorEx;
using AdventureWorks.API;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace AdventureWorks.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>c.SingleApiVersion("v1", "AdventureWorks.API"))
                        .EnableSwaggerUi();
        }
    }

}