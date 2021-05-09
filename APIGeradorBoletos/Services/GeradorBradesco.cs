using APIGerarBoletos.Models;
using BoletoNet;
using System;
using System.IO;

//BOLETO.NET VERSÃO 1 -- SEM SUPORTE A NET CORE, APENAS A NET FRAMEWORK
namespace APIGerarBoletos.Services
{
    public class GeradorBradesco : GeradorBase
    {
        public MemoryStream GerarBoleto(BoletoIn boletoIn)
        {
            DateTime vencimento = Convert.ToDateTime(boletoIn.Vencimento);
            Instrucao_Bradesco item = new Instrucao_Bradesco(9, 5);

            Cedente cedente = new Cedente(boletoIn.Cedente.CNPJ, boletoIn.Cedente.Nome,
                boletoIn.Cedente.Agencia, boletoIn.Cedente.DigitoAgencia, boletoIn.Cedente.Conta, boletoIn.Cedente.DigitoConta);
            cedente.Codigo = boletoIn.Cedente.Codigo;

            //Carteiras 
            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 
                Convert.ToDecimal(boletoIn.Valor), "09", boletoIn.Numero, cedente);

            b.ValorMulta = 0.10m;
            b.ValorCobrado = 1.10m;
            b.NumeroDocumento = boletoIn.Numero;
            //b.DataVencimento = new DateTime(2015, 09, 12);

            b.Sacado = new Sacado(boletoIn.Sacado.CNPJ,boletoIn.Sacado.Nome);
            b.Sacado.Endereco.End = boletoIn.Sacado.Endereco;
            b.Sacado.Endereco.Bairro = boletoIn.Sacado.Bairro;
            b.Sacado.Endereco.Cidade = boletoIn.Sacado.Cidade;
            b.Sacado.Endereco.CEP = boletoIn.Sacado.CEP;
            b.Sacado.Endereco.UF = boletoIn.Sacado.UF;

            item.Descricao += " após " + item.QuantidadeDias.ToString() + " dias corridos do vencimento.";
            b.Instrucoes.Add(item); //"Não Receber após o vencimento");

            var boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 237;
            boletoBancario.MostrarContraApresentacaoNaDataVencimento = true;

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            try
            {
                return SaveBoletoPDF(boletoBancario.MontaBytesPDF());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MemoryStream GerarBoletoTeste(BoletoIn paramsBoleto)
        {
            DateTime vencimento = DateTime.Now.AddDays(10);
            Instrucao_Bradesco item = new Instrucao_Bradesco(9, 5);

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado",
                "1234", "5", "123456", "7");
            c.Codigo = "13000";

            //Carteiras 
            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 1.00m, "09", "01000000001", c);
            b.ValorMulta = 0.10m;
            b.ValorCobrado = 1.10m;
            b.NumeroDocumento = "01000000001";
            b.DataVencimento = new DateTime(2015, 09, 12);

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            item.Descricao += " após " + item.QuantidadeDias.ToString() + " dias corridos do vencimento.";
            b.Instrucoes.Add(item); //"Não Receber após o vencimento");

            Instrucao i = new Instrucao(237);
            i.Descricao = "Nova Instrução";
            b.Instrucoes.Add(i);

            /* A data de vencimento não é usada
             * Usado para mostrar no lugar da data de vencimento o termo "Contra Apresentação";
             * Usado na carteira 06 */

            var boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 237;
            boletoBancario.MostrarContraApresentacaoNaDataVencimento = true;
            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            try
            {
                //return SaveBoletoPDF(boleto_bancario.MontaBytesPDF(), false);
                return SaveBoletoPDF(boletoBancario.MontaBytesPDF(), true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
