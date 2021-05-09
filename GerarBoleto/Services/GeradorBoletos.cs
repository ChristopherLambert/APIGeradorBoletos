using BoletoNet;
using GerarBoleto.Models;
using System;
using System.IO;

//BOLETO.NET VERSÃO 1 -- SEM SUPORTE A NET CORE, APENAS A NET FRAMEWORK
namespace GeradorBoleto.Services
{
    public class GeradorBoletos : GeradorBase
    {
        public MemoryStream GerarBoleto(BoletoIn boletoIn)
        {
            Cedente cedente = new Cedente(boletoIn.Cedente.CPF, boletoIn.Cedente.Nome,
                boletoIn.Cedente.Agencia, boletoIn.Cedente.Conta, boletoIn.Cedente.DigitoConta);
            cedente.Codigo = Convert.ToInt32(boletoIn.Cedente.Codigo).ToString();

            Boleto boleto = new Boleto(Convert.ToDateTime(boletoIn.Vencimento),
                   Convert.ToDecimal(boletoIn.Valor), "109", boletoIn.Cedente.NumeroBoleto, cedente);
            boleto.NumeroDocumento = boletoIn.Numero;

            Sacado sacado = new Sacado(boletoIn.Sacado.CPF, boletoIn.Sacado.Nome);
            boleto.Sacado = sacado;
            boleto.Sacado.Endereco.End = boletoIn.Sacado.Endereco;
            boleto.Sacado.Endereco.Bairro = boletoIn.Sacado.Bairro;
            boleto.Sacado.Endereco.Cidade = boletoIn.Sacado.Cidade;
            boleto.Sacado.Endereco.CEP = boletoIn.Sacado.CEP;
            boleto.Sacado.Endereco.UF = boletoIn.Sacado.UF;

            Instrucao_Itau instrucao = new Instrucao_Itau();
            instrucao.Descricao = "Não Receber após o vencimento";

            boleto.Instrucoes.Add(instrucao);

            EspecieDocumento_Itau especieItau = new EspecieDocumento_Itau("99");
            EspecieDocumento_Bradesco especieBradesco = new EspecieDocumento_Bradesco("16");

            BoletoBancario boleto_bancario = new BoletoBancario();
            // ITAU ou BRADESCO
            if (boletoIn.isItau)
            {
                boleto.EspecieDocumento = especieItau;
                boleto_bancario.CodigoBanco = 341;
            }
            else if (boletoIn.isBradesco)
            {
                boleto.EspecieDocumento = especieBradesco;
                boleto_bancario.CodigoBanco = 237;
                //boleto.Carteira = "02";
                //boleto.Carteira = "19";
                //boleto_bancario = GerarBoletoCarteira16();
            }

            //boleto_bancario.Boleto = boleto;
            boleto_bancario.MostrarCodigoCarteira = true;
            //boleto_bancario.Boleto.Valida();
            boleto_bancario.MostrarComprovanteEntrega = true;

            try
            {
                var stream = SaveBoletoPDF(boleto_bancario.MontaBytesPDF());
                GerarRemessa(cedente, boleto);
                return stream;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return null;
            }
        }
    }
}
