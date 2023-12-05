namespace LocadoraDeVeiculos.WinFormsApp.ModuloCliente
{
    partial class TelaClienteForm
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
            txtNome = new TextBox();
            label7 = new Label();
            label6 = new Label();
            txtBairro = new TextBox();
            label5 = new Label();
            txtEstado = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            label4 = new Label();
            txtEmail = new TextBox();
            rdbFisica = new RadioButton();
            rdbJuridica = new RadioButton();
            label8 = new Label();
            label9 = new Label();
            txtCidade = new TextBox();
            txtRua = new TextBox();
            label10 = new Label();
            txtNumero = new TextBox();
            label11 = new Label();
            txtTelefone = new MaskedTextBox();
            txtCpf = new MaskedTextBox();
            txtCnpj = new MaskedTextBox();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(117, 20);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(230, 23);
            txtNome.TabIndex = 46;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 114);
            label7.Name = "label7";
            label7.Size = new Size(89, 15);
            label7.TabIndex = 45;
            label7.Text = "Tipo de Cliente:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(56, 80);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 43;
            label6.Text = "Telefone:";
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(112, 206);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(235, 23);
            txtBairro.TabIndex = 40;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(65, 209);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 39;
            label5.Text = "Bairro:";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(112, 177);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(48, 23);
            txtEstado.TabIndex = 38;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 180);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 37;
            label3.Text = "Estado: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 151);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 36;
            label2.Text = "CPF:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 23);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 35;
            label1.Text = "Nome:";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(205, 301);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(76, 34);
            btnGravar.TabIndex = 48;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(287, 301);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 34);
            btnCancelar.TabIndex = 47;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 52);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 49;
            label4.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(117, 49);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 23);
            txtEmail.TabIndex = 50;
            // 
            // rdbFisica
            // 
            rdbFisica.AutoSize = true;
            rdbFisica.Location = new Point(117, 112);
            rdbFisica.Name = "rdbFisica";
            rdbFisica.Size = new Size(93, 19);
            rdbFisica.TabIndex = 52;
            rdbFisica.TabStop = true;
            rdbFisica.Text = "Pessoa Física";
            rdbFisica.UseVisualStyleBackColor = true;
            rdbFisica.CheckedChanged += rdbFisica_CheckedChanged;
            // 
            // rdbJuridica
            // 
            rdbJuridica.AutoSize = true;
            rdbJuridica.Location = new Point(222, 114);
            rdbJuridica.Name = "rdbJuridica";
            rdbJuridica.Size = new Size(104, 19);
            rdbJuridica.TabIndex = 53;
            rdbJuridica.TabStop = true;
            rdbJuridica.Text = "Pessoa Jurídica";
            rdbJuridica.UseVisualStyleBackColor = true;
            rdbJuridica.CheckedChanged += rdbJuridica_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(211, 151);
            label8.Name = "label8";
            label8.Size = new Size(37, 15);
            label8.TabIndex = 54;
            label8.Text = "CNPJ:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(166, 180);
            label9.Name = "label9";
            label9.Size = new Size(47, 15);
            label9.TabIndex = 56;
            label9.Text = "Cidade:";
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(222, 177);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(125, 23);
            txtCidade.TabIndex = 57;
            // 
            // txtRua
            // 
            txtRua.Location = new Point(112, 235);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(235, 23);
            txtRua.TabIndex = 59;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(76, 238);
            label10.Name = "label10";
            label10.Size = new Size(30, 15);
            label10.TabIndex = 58;
            label10.Text = "Rua:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(112, 264);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(93, 23);
            txtNumero.TabIndex = 61;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(52, 267);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 60;
            label11.Text = "Número:";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(117, 78);
            txtTelefone.Mask = "(99) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(100, 23);
            txtTelefone.TabIndex = 62;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(112, 148);
            txtCpf.Mask = "999,999,999-99";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(93, 23);
            txtCpf.TabIndex = 63;
            // 
            // txtCnpj
            // 
            txtCnpj.Location = new Point(247, 148);
            txtCnpj.Mask = "99,999,999/9999-99";
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(100, 23);
            txtCnpj.TabIndex = 64;
            // 
            // TelaClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 347);
            Controls.Add(txtCnpj);
            Controls.Add(txtCpf);
            Controls.Add(txtTelefone);
            Controls.Add(txtNumero);
            Controls.Add(label11);
            Controls.Add(txtRua);
            Controls.Add(label10);
            Controls.Add(txtCidade);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(rdbJuridica);
            Controls.Add(rdbFisica);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(txtNome);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtBairro);
            Controls.Add(label5);
            Controls.Add(txtEstado);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaClienteForm";
            Text = "Cadastro de Clientes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private Label label7;
        private Label label6;
        private TextBox txtBairro;
        private Label label5;
        private TextBox txtEstado;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnGravar;
        private Button btnCancelar;
        private Label label4;
        private TextBox txtEmail;
        private RadioButton rdbFisica;
        private RadioButton rdbJuridica;
        private Label label8;
        private Label label9;
        private TextBox txtCidade;
        private TextBox txtRua;
        private Label label10;
        private TextBox txtNumero;
        private Label label11;
        private MaskedTextBox txtCnpj;
        private MaskedTextBox maskedTextBox2;
        private MaskedTextBox txtTelefone;
        private MaskedTextBox txtCpf;
    }
}