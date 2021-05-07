using APIGerarBoletos.Models;
using BoletoNet;
using System;
using System.IO;

//BOLETO.NET VERSÃO 1 -- SEM SUPORTE A NET CORE, APENAS A NET FRAMEWORK
namespace APIGerarBoletos.Services
{
    public class GeradorBradesco
    {
        public MemoryStream GerarBoleto(BoletoIn boletoIn)
        {
            String vencimento = boletoIn.Vencimento;
            String valorBoleto = boletoIn.Valor;
            String numeroDocumento = "B20005446";

            Cedente cedente = new Cedente(boletoIn.Cedente.CPF,
            boletoIn.Cedente.Nome, boletoIn.Cedente.Agencia, boletoIn.Cedente.Conta, boletoIn.Cedente.DigitoConta);
            cedente.Codigo = Convert.ToInt32(boletoIn.Cedente.Codigo).ToString();

            Boleto boleto = new Boleto(Convert.ToDateTime(vencimento),
                   Convert.ToDecimal(valorBoleto),
                   "109", boletoIn.Cedente.NumeroBoleto, cedente);
            boleto.NumeroDocumento = numeroDocumento;

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
            BoletoBancario boleto_bancario = new BoletoBancario();
            boleto.EspecieDocumento = especieItau;
            boleto_bancario.CodigoBanco = 341;

            boleto_bancario.Boleto = boleto;
            boleto_bancario.MostrarCodigoCarteira = true;
            //boleto_bancario.Boleto.Valida();
            boleto_bancario.MostrarComprovanteEntrega = true;

            try
            {
                return SaveBoletoPDF(boleto_bancario.MontaBytesPDF());
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

            Cedente c = new Cedente("00.000.000/0000-00", "Empresa de Atacado", "1234", "5", "123456", "7");
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

            /* 
             * A data de vencimento não é usada
             * Usado para mostrar no lugar da data de vencimento o termo "Contra Apresentação";
             * Usado na carteira 06
             */

            var boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 237;
            boletoBancario.MostrarContraApresentacaoNaDataVencimento = true;

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            //return null;
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

        private MemoryStream SaveBoletoPDF(byte[] boletoPdf, bool isFile = false)
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(boletoPdf, 0, boletoPdf.Length);
            stream.Seek(0, SeekOrigin.Begin);

            if (isFile)
            {
                if (File.Exists("C:\\boleto.pdf"))
                    File.Delete("C:\\boleto.pdf");

                var fileStream = File.Create("C:\\boleto.pdf");
                stream.CopyTo(fileStream);
                fileStream.Close();
            }

            return stream;
        }
    }
}
