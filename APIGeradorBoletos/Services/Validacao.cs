using APIGerarBoletos.Models;
using System;

namespace APIGerarBoletos.Services
{
    public static class Validacao
    {
        public static string ValidarGeral(BoletoIn boletoIn)
        {
            string MsgError = Validacao.ValidarBoleto(boletoIn.Vencimento, boletoIn.Valor);
            if (!string.IsNullOrEmpty(MsgError))
                return MsgError;

            MsgError = Validacao.ValidarCedente(boletoIn.Cedente);
            if (!string.IsNullOrEmpty(MsgError))
                return MsgError;

            MsgError = Validacao.ValidarSacado(boletoIn.Sacado);
            if (!string.IsNullOrEmpty(MsgError))
                return MsgError;

            return string.Empty;
        }

        public static string ValidarBoleto(string vencimento, string valor)
        {
            DateTime dateVencimento;
            if (!DateTime.TryParse(vencimento, out dateVencimento))
                return "Boleto com Data de Vencimento Invalída ";

            Decimal deciValor;
            if (!Decimal.TryParse(valor, out deciValor))
                return "Boleto com Valor Invalído ";

            return string.Empty;
        }

        public static string ValidarCedente(CedenteIn cedenteIn)
        {
            return string.Empty;
        }

        public static string ValidarSacado(SacadoIn sacadoIn)
        {
            return string.Empty;
        }
    }
}
