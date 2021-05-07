using APIGerarBoletos.Models;
using APIGerarBoletos.Services;
using System;
using System.Web.Http;

namespace APIGeradorBoletos.Controllers
{
    //https://localhost:44302/api/Gerador
    //https://localhost:44302/swagger/ui/index
    public class BradescoController : ApiController
    {
        [HttpPost]
        //[ActionName("PostBradesco")]
        public BoletoOut PostBradesco(BoletoIn boletoIn)
        {
            GeradorBradesco geradorBradesco = new GeradorBradesco();
            var boletoOut = new BoletoOut();

            try
            {
                string MsgError = Validacao.ValidarGeral(boletoIn);
                if (!string.IsNullOrEmpty(MsgError))
                {
                    boletoOut.Sucesso = false;
                    boletoOut.Mensagem = MsgError;
                    return boletoOut;
                }

                if (boletoIn.Teste)
                    boletoOut.Boleto = geradorBradesco.GerarBoletoTeste(boletoIn);
                else
                    boletoOut.Boleto = geradorBradesco.GerarBoleto(boletoIn);

                boletoOut.Sucesso = true;
                return boletoOut;
            }
            catch (Exception ex)
            {
                boletoOut.Sucesso = false;
                boletoOut.Mensagem = "Falha Desconhecida: ";
                return boletoOut;
            }
        }
    }
}