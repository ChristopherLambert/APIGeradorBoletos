using APIGerarBoletos.Models;
using APIGerarBoletos.Services;
using System.Web.Http;

namespace APIGeradorBoletos.Controllers
{
    public class GeradorController : ApiController //https://localhost:44302/api/Gerador
    {
        [HttpPost] 
        public BoletoOut Post(BoletoIn boletoIn)
        {
            GeradorItau geradorItau = new GeradorItau();

            if (boletoIn.Teste)
                geradorItau.GerarBoletoTeste(boletoIn);
            else
               geradorItau.GerarBoleto(boletoIn);

            return new BoletoOut();
        }
    }
}