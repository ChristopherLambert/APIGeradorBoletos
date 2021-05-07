using APIGerarBoletos.Models;
using APIGerarBoletos.Services;
using System;
using System.Web.Http;

namespace APIGeradorBoletos.Controllers
{
    public class ItauController : ApiController
    {
        [HttpPost]
        //[ActionName("PostItau")]
        public BoletoOut PostItau(BoletoIn boletoIn)
        {
            GeradorItau geradorItau = new GeradorItau();
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
                    boletoOut.Boleto = geradorItau.GerarBoletoTeste(boletoIn);
                else
                    boletoOut.Boleto = geradorItau.GerarBoleto(boletoIn);

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