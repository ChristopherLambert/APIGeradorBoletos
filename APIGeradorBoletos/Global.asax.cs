using APIGeradorBoletos.Configuration;
using Swashbuckle.Application;
using System;
using System.Web.Http;
using System.Web.Routing;

namespace APIGeradorBoletos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //https://localhost:44302/api/Gerador
        //https://localhost:44302/swagger/ui/index
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(RegisterRouter.Register);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Swagger
            GlobalConfiguration.Configuration
                 .EnableSwagger(c =>
                 {
                     c.SingleApiVersion("v1", "API Geradora de Boletos Bancario");
                 }).EnableSwaggerUi();
        }
    }
}
