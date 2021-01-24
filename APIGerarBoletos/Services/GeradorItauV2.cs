using APIGerarBoletos.Models;
using Boleto2Net;
using System;
using System.IO;
using System.Web;

// BOLETO.NET VERSÃO 2 -- COM SUPORTE A NET FRAMEWORK
namespace APIGerarBoletos.Services
{
    public class GeradorItauV2
    {
        //public void GerarBoleto(BoletoIn boletoIn)
        //{
        //    String vencimento = boletoIn.Vencimento;
        //    String valorBoleto = boletoIn.Valor;
        //    String numeroDocumento = "B20005446";

        //    Cedente cedente = new Cedente(boletoIn.Cedente.CPF,
        //    boletoIn.Cedente.Nome, boletoIn.Cedente.Agencia, boletoIn.Cedente.Conta, boletoIn.Cedente.DigitoConta);
        //    cedente.Codigo = Convert.ToInt32(boletoIn.Cedente.Codigo).ToString();

        //    Boleto boleto = new Boleto(Convert.ToDateTime(vencimento),
        //           Convert.ToDecimal(valorBoleto),
        //           "109", boletoIn.Cedente.NumeroBoleto, cedente);
        //    boleto.NumeroDocumento = numeroDocumento;

        //    Sacado sacado = new Sacado(boletoIn.Sacado.CPF, boletoIn.Sacado.Nome);
        //    boleto.Sacado = sacado;
        //    boleto.Sacado.Endereco.End = boletoIn.Sacado.Endereco;
        //    boleto.Sacado.Endereco.Bairro = boletoIn.Sacado.Bairro;
        //    boleto.Sacado.Endereco.Cidade = boletoIn.Sacado.Cidade;
        //    boleto.Sacado.Endereco.CEP = boletoIn.Sacado.CEP;
        //    boleto.Sacado.Endereco.UF = boletoIn.Sacado.UF;

        //    Instrucao_Itau instrucao = new Instrucao_Itau();
        //    instrucao.Descricao = "Não Receber após o vencimento";
        //    boleto.Instrucoes.Add(instrucao);

        //    EspecieDocumento_Itau especieItau = new EspecieDocumento_Itau("99");
        //    BoletoBancario boleto_bancario = new BoletoBancario();
        //    boleto.EspecieDocumento = especieItau;
        //    boleto_bancario.CodigoBanco = 341;

        //    //boleto_bancario.Boleto = boleto;
        //    boleto_bancario.MostrarCodigoCarteira = true;
        //    //boleto_bancario.Boleto.Valida();
        //    boleto_bancario.MostrarComprovanteEntrega = true;

        //    try
        //    {
        //        //SaveBoletoPDF(boleto_bancario.MontaBytesPDF());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public void GerarBoletoTeste(BoletoIn paramsBoleto)
        {
            String vencimento = paramsBoleto.Vencimento;
            String valorBoleto = paramsBoleto.Valor;
            String numeroDocumento = "B20005446";

            //cedente
            String cedente_codigo = "1111111";
            String cedente_nossoNumeroBoleto = "22222222";
            String cedente_cpfCnpj = "123.456.789-01";
            String cedente_nome = "CHRISTOPHER LAMBERT FRIGERIO DE SOUZA.";
            String cedente_agencia = "1000";
            String cedente_conta = "22507";
            String cedente_digitoConta = "6";

            //sacado
            String sacado_cpfCnpj = "000.000.000-00";
            String sacado_nome = "Christopher Lambert";
            String sacado_endereco = "Rua Domingos da Costa Aroso 149 R/C";
            String sacado_bairro = "Moreira";
            String sacado_cidade = "Cidade";
            String sacado_cep = "4470-313";
            String sacado_uf = "PR";

            ContaBancaria contaBancaria = new ContaBancaria();
            contaBancaria.Agencia = cedente_agencia;
            contaBancaria.Conta = cedente_conta;
            contaBancaria.DigitoConta = cedente_digitoConta;

            Cedente cedente = new Cedente();
            cedente.Codigo = Convert.ToInt32(cedente_codigo).ToString();
            cedente.CPFCNPJ = cedente_cpfCnpj;
            cedente.Nome = cedente_nome;
            cedente.ContaBancaria = contaBancaria;
            cedente.Nome = cedente_nome;

            Sacado sacado = new Sacado();
            sacado.CPFCNPJ = sacado_cpfCnpj;
            sacado.Nome = sacado_nome;
            sacado.Endereco.LogradouroEndereco = sacado_endereco;
            sacado.Endereco.Bairro = sacado_bairro;
            sacado.Endereco.Cidade = sacado_cidade;
            sacado.Endereco.CEP = sacado_cep;

            var _banco = Banco.Instancia(Bancos.Itau);
            var boleto = new Boleto(_banco)
            {
                DataVencimento = Convert.ToDateTime(vencimento),
                ValorTitulo = Convert.ToDecimal(valorBoleto),
                NossoNumero = cedente_nossoNumeroBoleto,
                NumeroDocumento = numeroDocumento,
                EspecieDocumento = TipoEspecieDocumento.DM,
                Sacado = sacado
            };

            boleto.Sacado.Endereco.UF = sacado_uf;
            BoletoBancario boleto_bancario = new BoletoBancario();
            boleto_bancario.Boleto = boleto;
            boleto_bancario.MostrarCodigoCarteira = true;
            //boleto_bancario.Boleto.Valida();
            boleto_bancario.MostrarComprovanteEntrega = true;

            try
            {
                //SaveBoletoPDF(boleto_bancario.MontaBytesPDF(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SaveBoletoPDF(byte[] boletoPdf)
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(boletoPdf, 0, boletoPdf.Length);

            var fileStream = File.Create("C:\\boleto.pdf");
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);
            fileStream.Close();
        }
    }
}
