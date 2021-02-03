namespace GerarBoleto
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtVencimento = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtSacado = new System.Windows.Forms.TextBox();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.rdItau = new System.Windows.Forms.RadioButton();
            this.rdBradesco = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Gerar Boleto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtVencimento
            // 
            this.txtVencimento.Location = new System.Drawing.Point(44, 12);
            this.txtVencimento.Name = "txtVencimento";
            this.txtVencimento.Size = new System.Drawing.Size(138, 20);
            this.txtVencimento.TabIndex = 1;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(282, 12);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(138, 20);
            this.txtValor.TabIndex = 2;
            // 
            // txtSacado
            // 
            this.txtSacado.Location = new System.Drawing.Point(44, 53);
            this.txtSacado.Name = "txtSacado";
            this.txtSacado.Size = new System.Drawing.Size(138, 20);
            this.txtSacado.TabIndex = 3;
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(282, 53);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(138, 20);
            this.txtMorada.TabIndex = 4;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(44, 92);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(138, 20);
            this.txtBairro.TabIndex = 5;
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(282, 92);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(138, 20);
            this.txtCidade.TabIndex = 6;
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(44, 130);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(138, 20);
            this.txtCEP.TabIndex = 7;
            // 
            // txtUF
            // 
            this.txtUF.Location = new System.Drawing.Point(282, 130);
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(138, 20);
            this.txtUF.TabIndex = 8;
            // 
            // rdItau
            // 
            this.rdItau.AutoSize = true;
            this.rdItau.Location = new System.Drawing.Point(44, 169);
            this.rdItau.Name = "rdItau";
            this.rdItau.Size = new System.Drawing.Size(50, 17);
            this.rdItau.TabIndex = 9;
            this.rdItau.TabStop = true;
            this.rdItau.Text = "ITAU";
            this.rdItau.UseVisualStyleBackColor = true;
            // 
            // rdBradesco
            // 
            this.rdBradesco.AutoSize = true;
            this.rdBradesco.Location = new System.Drawing.Point(44, 192);
            this.rdBradesco.Name = "rdBradesco";
            this.rdBradesco.Size = new System.Drawing.Size(70, 17);
            this.rdBradesco.TabIndex = 10;
            this.rdBradesco.TabStop = true;
            this.rdBradesco.Text = "Bradesco";
            this.rdBradesco.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 226);
            this.Controls.Add(this.rdBradesco);
            this.Controls.Add(this.rdItau);
            this.Controls.Add(this.txtUF);
            this.Controls.Add(this.txtCEP);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtMorada);
            this.Controls.Add(this.txtSacado);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtVencimento);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtVencimento;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtSacado;
        private System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.RadioButton rdItau;
        private System.Windows.Forms.RadioButton rdBradesco;
    }
}

