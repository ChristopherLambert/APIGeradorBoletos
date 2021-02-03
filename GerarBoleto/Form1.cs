using BoletoNet;
using System;
using System.IO;
using System.Windows.Forms;

namespace GerarBoleto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtVencimento.Text = "30/12/2020";
            txtValor.Text = "5890";
            txtSacado.Text = "Christopher Lambert";
            txtMorada.Text = "Bairro Novo - Curitiba";
            txtBairro.Text = "Bairro Novo";
            txtCidade.Text = "Curitiba";
            txtCEP.Text = "81270-070";
            txtUF.Text = "PR";
            this.rdItau.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vencimento = txtVencimento.Text;
            String valorBoleto = txtValor.Text;
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
            String sacado_nome = txtSacado.Text;
            String sacado_endereco = txtMorada.Text;
            String sacado_bairro = txtBairro.Text;
            String sacado_cidade = txtCidade.Text;
            String sacado_cep = txtCEP.Text;
            String sacado_uf = txtUF.Text;

            Cedente cedente = new Cedente(cedente_cpfCnpj,
            cedente_nome,
            cedente_agencia,
            cedente_conta,
            cedente_digitoConta);
            cedente.Codigo = Convert.ToInt32(cedente_codigo).ToString();

            Boleto boleto = new Boleto(Convert.ToDateTime(vencimento),
                   Convert.ToDecimal(valorBoleto),
                   "109",
                   cedente_nossoNumeroBoleto, cedente);
            boleto.NumeroDocumento = numeroDocumento;

            Sacado sacado = new Sacado(sacado_cpfCnpj, sacado_nome);
            boleto.Sacado = sacado;
            boleto.Sacado.Endereco.End = sacado_endereco;
            boleto.Sacado.Endereco.Bairro = sacado_bairro;
            boleto.Sacado.Endereco.Cidade = sacado_cidade;
            boleto.Sacado.Endereco.CEP = sacado_cep;
            boleto.Sacado.Endereco.UF = sacado_uf;

            Instrucao_Itau instrucao = new Instrucao_Itau();
            instrucao.Descricao = "Não Receber após o vencimento";

            boleto.Instrucoes.Add(instrucao);

            EspecieDocumento_Itau especieItau = new EspecieDocumento_Itau("99");
            EspecieDocumento_Bradesco especieBradesco = new EspecieDocumento_Bradesco("16");

            BoletoBancario boleto_bancario = new BoletoBancario();
            // ITAU ou BRADESCO
            if (this.rdItau.Checked)
            {
                boleto.EspecieDocumento = especieItau;
                boleto_bancario.CodigoBanco = 341;
            }
            else if (this.rdBradesco.Checked)
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
                SaveBoletoPDF(boleto_bancario.MontaBytesPDF());
                GerarRemessa(cedente, boleto);
                MessageBox.Show("Boleto Gerado Com Sucesso em C:/boleto.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao gerar o Arquivo -- " + ex.Message);
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
        private void GerarRemessa(Cedente cedente, Boleto boleto)
        {
            //Gerar Remessa
            Boletos boletos = new Boletos();
            boletos.Add(boleto);

            var objRemessa = new ArquivoRemessa(TipoArquivo.CNAB400);
            var memoryStr = new MemoryStream();
            objRemessa.GerarArquivoRemessa("09", new Banco(341), cedente, boletos, memoryStr, 1000);
        }

        private BoletoBancario GerarBoletoCarteira16() // Bradesco
        {
            var vencimento = new DateTime(2015, 7, 20);
            var cedente = new Cedente("00.000.000/0000-00", "Empresa Teste", "0413", "8", "0002916", "5");
            var boleto = new Boleto(vencimento, 123, "16", "00970171092", cedente);
            boleto.NumeroDocumento = "970171092";

            var boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 237;
            boletoBancario.Boleto = boleto;

            return boletoBancario;
        }
    }
}
