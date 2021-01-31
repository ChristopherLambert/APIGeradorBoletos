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
            string msgError = "BOLETO: ";
            DateTime dateVencimento;
            if (!DateTime.TryParse(vencimento, out dateVencimento))
                return msgError + "com Data de Vencimento Invalída ";

            Decimal deciValor;
            if (!Decimal.TryParse(valor, out deciValor))
                return msgError + "com Valor Invalído ";

            return string.Empty;
        }

        public static string ValidarCedente(CedenteIn cedenteIn)
        {
            string msgError = "CEDENTE: ";
            if (string.IsNullOrEmpty(cedenteIn.CNPJ) && string.IsNullOrEmpty(cedenteIn.CPF))
                return msgError + "CPF ou CNPJ são Obrigatórios ";

            if (string.IsNullOrEmpty(cedenteIn.Conta))
                return msgError + "Conta é Obrigatório ";

            if (string.IsNullOrEmpty(cedenteIn.Agencia))
                return msgError + "Agencia é Obrigatório ";

            if (string.IsNullOrEmpty(cedenteIn.DigitoConta))
                return msgError + "Digito da Conta é Obrigatório ";

            return string.Empty;
        }

        public static string ValidarSacado(SacadoIn sacadoIn)
        {
            string msgError = "SACADO: ";
            if (string.IsNullOrEmpty(sacadoIn.CNPJ) && string.IsNullOrEmpty(sacadoIn.CPF))
                return msgError + "CPF ou CNPJ são Obrigatórios ";

            return string.Empty;
        }
    }
}
