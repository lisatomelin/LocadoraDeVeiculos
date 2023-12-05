namespace LocadoraDeVeiculos.WinFormsApp.ModuloAluguel
{
    partial class TelaEnviarEmailForm
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
            txtCupom = new TextBox();
            txtSenhaEmail = new TextBox();
            txtMensagem = new TextBox();
            label5 = new Label();
            txtAssunto = new TextBox();
            label4 = new Label();
            txtEmailFuncionario = new TextBox();
            label3 = new Label();
            txtEmailCliente = new TextBox();
            txtMostrarPdf = new TextBox();
            label2 = new Label();
            btnSelecionarPdf = new Button();
            btnEnviar = new Button();
            btnCancelar = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtCupom
            // 
            txtCupom.Enabled = false;
            txtCupom.Location = new Point(248, -157);
            txtCupom.Name = "txtCupom";
            txtCupom.Size = new Size(121, 23);
            txtCupom.TabIndex = 96;
            // 
            // txtSenhaEmail
            // 
            txtSenhaEmail.Location = new Point(119, 104);
            txtSenhaEmail.Margin = new Padding(4);
            txtSenhaEmail.Name = "txtSenhaEmail";
            txtSenhaEmail.PlaceholderText = "senha do email";
            txtSenhaEmail.Size = new Size(260, 23);
            txtSenhaEmail.TabIndex = 132;
            // 
            // txtMensagem
            // 
            txtMensagem.Location = new Point(119, 184);
            txtMensagem.Margin = new Padding(4);
            txtMensagem.Multiline = true;
            txtMensagem.Name = "txtMensagem";
            txtMensagem.ScrollBars = ScrollBars.Both;
            txtMensagem.Size = new Size(260, 88);
            txtMensagem.TabIndex = 131;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 215);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 130;
            label5.Text = "Mensagem:";
            // 
            // txtAssunto
            // 
            txtAssunto.Location = new Point(119, 144);
            txtAssunto.Margin = new Padding(4);
            txtAssunto.Name = "txtAssunto";
            txtAssunto.Size = new Size(260, 23);
            txtAssunto.TabIndex = 129;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 145);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 128;
            label4.Text = "Assunto:";
            // 
            // txtEmailFuncionario
            // 
            txtEmailFuncionario.Location = new Point(119, 64);
            txtEmailFuncionario.Margin = new Padding(4);
            txtEmailFuncionario.Name = "txtEmailFuncionario";
            txtEmailFuncionario.PlaceholderText = "email do funcionário";
            txtEmailFuncionario.Size = new Size(260, 23);
            txtEmailFuncionario.TabIndex = 127;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 65);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 126;
            label3.Text = "Funcionário:";
            // 
            // txtEmailCliente
            // 
            txtEmailCliente.Location = new Point(119, 25);
            txtEmailCliente.Margin = new Padding(4);
            txtEmailCliente.Name = "txtEmailCliente";
            txtEmailCliente.PlaceholderText = "email do cliente";
            txtEmailCliente.Size = new Size(260, 23);
            txtEmailCliente.TabIndex = 125;
            // 
            // txtMostrarPdf
            // 
            txtMostrarPdf.Location = new Point(119, 284);
            txtMostrarPdf.Margin = new Padding(4);
            txtMostrarPdf.Name = "txtMostrarPdf";
            txtMostrarPdf.PlaceholderText = "anexo do email";
            txtMostrarPdf.ReadOnly = true;
            txtMostrarPdf.Size = new Size(260, 23);
            txtMostrarPdf.TabIndex = 124;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 285);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 123;
            label2.Text = "Selecionar PDF:";
            // 
            // btnSelecionarPdf
            // 
            btnSelecionarPdf.Location = new Point(119, 324);
            btnSelecionarPdf.Margin = new Padding(4);
            btnSelecionarPdf.Name = "btnSelecionarPdf";
            btnSelecionarPdf.Size = new Size(259, 34);
            btnSelecionarPdf.TabIndex = 122;
            btnSelecionarPdf.Text = "Buscar";
            btnSelecionarPdf.UseVisualStyleBackColor = true;
            btnSelecionarPdf.Click += btnSelecionarPdf_Click;
            // 
            // btnEnviar
            // 
            btnEnviar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEnviar.DialogResult = DialogResult.OK;
            btnEnviar.Location = new Point(119, 366);
            btnEnviar.Margin = new Padding(4);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(126, 42);
            btnEnviar.TabIndex = 119;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(247, 366);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(131, 42);
            btnCancelar.TabIndex = 118;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 28);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 133;
            label6.Text = "Destinatario: ";
            // 
            // TelaEnviarEmailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 435);
            Controls.Add(label6);
            Controls.Add(txtSenhaEmail);
            Controls.Add(txtMensagem);
            Controls.Add(label5);
            Controls.Add(txtAssunto);
            Controls.Add(label4);
            Controls.Add(txtEmailFuncionario);
            Controls.Add(label3);
            Controls.Add(txtEmailCliente);
            Controls.Add(txtMostrarPdf);
            Controls.Add(label2);
            Controls.Add(btnSelecionarPdf);
            Controls.Add(btnEnviar);
            Controls.Add(btnCancelar);
            Controls.Add(txtCupom);
            Name = "TelaEnviarEmailForm";
            Text = "Enviar Email";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCupom;
        private TextBox txtSenhaEmail;
        private TextBox txtMensagem;
        private Label label5;
        private TextBox txtAssunto;
        private Label label4;
        private TextBox txtEmailFuncionario;
        private Label label3;
        private TextBox txtEmailCliente;
        private TextBox txtMostrarPdf;
        private Label label2;
        private Button btnSelecionarPdf;
        private Button btnEnviar;
        private Button btnCancelar;
        private Label label6;
    }
}