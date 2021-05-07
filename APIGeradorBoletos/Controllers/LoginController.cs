using APIGerarBoletos.Models;
using APIGerarBoletos.Services;
using System;
using System.Web.Http;

namespace APIGeradorBoletos.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public string Login(string user, string password)
        {
            return "Logado com Sucesso";
        }
    }
}