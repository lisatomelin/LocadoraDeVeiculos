namespace LocadoraDeVeiculos.WinFormsApp.ModuloCondutor
{
    partial class TelaCondutorForm
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
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            cbCliente = new ComboBox();
            chEhCondutor = new CheckBox();
            label4 = new Label();
            label6 = new Label();
            dateValidade = new DateTimePicker();
            label7 = new Label();
            txtEmail = new TextBox();
            txtNome = new TextBox();
            txtCnh = new MaskedTextBox();
            txtCpf = new MaskedTextBox();
            txtTelefone = new MaskedTextBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 144);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 66;
            label5.Text = "Telefone:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 115);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 64;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 86);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 63;
            label2.Text = "Nome:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 29);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 62;
            label1.Text = "Cliente:";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(217, 258);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(76, 34);
            btnGravar.TabIndex = 86;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(299, 258);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 34);
            btnCancelar.TabIndex = 85;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // cbCliente
            // 
            cbCliente.FormattingEnabled = true;
            cbCliente.Location = new Point(86, 26);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(230, 23);
            cbCliente.TabIndex = 87;
            cbCliente.SelectedIndexChanged += cbCliente_SelectedIndexChanged_1;
            // 
            // chEhCondutor
            // 
            chEhCondutor.AutoSize = true;
            chEhCondutor.Location = new Point(86, 58);
            chEhCondutor.Name = "chEhCondutor";
            chEhCondutor.Size = new Size(124, 19);
            chEhCondutor.TabIndex = 88;
            chEhCondutor.Text = "Cliente é condutor";
            chEhCondutor.UseVisualStyleBackColor = true;
            chEhCondutor.CheckedChanged += chEhCondutor_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(192, 144);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 89;
            label4.Text = "CPF:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 173);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 91;
            label6.Text = "CNH:";
            // 
            // dateValidade
            // 
            dateValidade.Format = DateTimePickerFormat.Short;
            dateValidade.Location = new Point(86, 199);
            dateValidade.Name = "dateValidade";
            dateValidade.Size = new Size(100, 23);
            dateValidade.TabIndex = 93;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 203);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 94;
            label7.Text = "Validade:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(86, 112);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 23);
            txtEmail.TabIndex = 95;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(86, 83);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(230, 23);
            txtNome.TabIndex = 96;
            // 
            // txtCnh
            // 
            txtCnh.Location = new Point(86, 170);
            txtCnh.Mask = "99,999,999/9999-99";
            txtCnh.Name = "txtCnh";
            txtCnh.Size = new Size(100, 23);
            txtCnh.TabIndex = 99;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(223, 141);
            txtCpf.Mask = "999,999,999-99";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(93, 23);
            txtCpf.TabIndex = 98;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(86, 141);
            txtTelefone.Mask = "(99) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(100, 23);
            txtTelefone.TabIndex = 97;
            // 
            // TelaCondutorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 304);
            Controls.Add(txtCnh);
            Controls.Add(txtCpf);
            Controls.Add(txtTelefone);
            Controls.Add(txtNome);
            Controls.Add(txtEmail);
            Controls.Add(label7);
            Controls.Add(dateValidade);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(chEhCondutor);
            Controls.Add(cbCliente);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaCondutorForm";
            Text = "Cadastro de Condutor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtCidade;
        private Label label9;
        private TextBox txtCnpj;
        private Label label8;
        private RadioButton rdbJuridica;
        private RadioButton rdbFisica;
        private TextBox txtBairro;
        private Label label5;
        private TextBox txtEstado;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnGravar;
        private Button btnCancelar;
        private ComboBox cbCliente;
        private CheckBox chEhCondutor;
        private Label label4;
        private Label label6;
        private DateTimePicker dateValidade;
        private Label label7;
        private TextBox txtEmail;
        private TextBox txtNome;
        private MaskedTextBox txtCnh;
        private MaskedTextBox txtCpf;
        private MaskedTextBox txtTelefone;
    }
}