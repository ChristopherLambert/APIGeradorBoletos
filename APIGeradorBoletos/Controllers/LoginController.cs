using APIGerarBoletos.Models;
using APIGerarBoletos.Services;
using System;
using System.Web.Configuration;
using System.Web.Http;

namespace APIGeradorBoletos.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public string Login(string user, string password)
        {
            string userAPI = WebConfigurationManager.AppSettings["userAPI"];
            string passAPI = WebConfigurationManager.AppSettings["passAPI"];

            if (user.Equals(userAPI) && passAPI.Equals(passAPI))
                return "Logado com Sucesso";
            else return "Usuario ou Senha Incorretos";
        }
    }
}