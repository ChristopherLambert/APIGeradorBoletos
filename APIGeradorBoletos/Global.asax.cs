using APIGeradorBoletos.Configuration;
using System;
using System.Web.Http;

namespace APIGeradorBoletos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(RegisterRouter.Register);
        }
    }
}
