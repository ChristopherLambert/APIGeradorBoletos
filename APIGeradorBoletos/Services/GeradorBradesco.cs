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
            var vencimento = new DateTime(2020, 6, 8);
            var cedente = new Cedente("00.000.000/0000-00", "Empresa Teste", "0539", "8", "0032463", "9");

            var boleto = new Boleto(vencimento, 5000, "09", "18194", cedente);
            boleto.NumeroDocumento = "18194";
            boleto.ValorMulta = 100;
            boleto.ValorCobrado = 5100;
            
            var boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 237;
            boletoBancario.MostrarCodigoCarteira = false;
            boletoBancario.Boleto = boleto;

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
