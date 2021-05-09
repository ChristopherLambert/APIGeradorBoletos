using BoletoNet;
using GeradorBoleto.Services;
using GerarBoleto.Models;
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
            GeradorBoletos gb = new GeradorBoletos();
            BoletoIn boletoIn = new BoletoIn();
            boletoIn.Sacado = new SacadoIn();
            boletoIn.Cedente = new CedenteIn();

            boletoIn.Vencimento = txtVencimento.Text;
            boletoIn.Valor = txtValor.Text;
            boletoIn.Numero = "B20005446";

            //Cedente
            boletoIn.Cedente.Codigo = "1111111";
            boletoIn.Cedente.NumeroBoleto = "22222222";
            boletoIn.Cedente.CPF = "123.456.789-01";
            boletoIn.Cedente.Nome = "CHRISTOPHER LAMBERT FRIGERIO DE SOUZA.";
            boletoIn.Cedente.Agencia = "1000";
            boletoIn.Cedente.Conta = "22507";
            boletoIn.Cedente.DigitoConta = "6";

            //Sacado
            boletoIn.Sacado.CNPJ = "000.000.000-00";
            boletoIn.Sacado.Nome = txtSacado.Text;
            boletoIn.Sacado.Endereco = txtMorada.Text;
            boletoIn.Sacado.Bairro = txtBairro.Text;
            boletoIn.Sacado.Cidade = txtCidade.Text;
            boletoIn.Sacado.CEP = txtCEP.Text;
            boletoIn.Sacado.UF = txtUF.Text;

            try
            {
                gb.GerarBoleto(boletoIn);
                MessageBox.Show("Boleto Gerado Com Sucesso em C:/boleto.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao gerar o Arquivo -- " + ex.Message);
            }
        }
    }
}
