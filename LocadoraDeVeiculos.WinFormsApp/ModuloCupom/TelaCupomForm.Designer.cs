namespace LocadoraDeVeiculos.WinFormsApp.ModuloCupom
{
    partial class TelaCupomForm
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
            label7 = new Label();
            dateValidade = new DateTimePicker();
            txtValor = new TextBox();
            label6 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            txtNome = new TextBox();
            label5 = new Label();
            label1 = new Label();
            cbParceiro = new ComboBox();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 87);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 104;
            label7.Text = "Validade:";
            // 
            // dateValidade
            // 
            dateValidade.Format = DateTimePickerFormat.Short;
            dateValidade.Location = new Point(84, 83);
            dateValidade.Name = "dateValidade";
            dateValidade.Size = new Size(124, 23);
            dateValidade.TabIndex = 103;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(84, 54);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(124, 23);
            txtValor.TabIndex = 102;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 57);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 101;
            label6.Text = "Valor:";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(60, 163);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(76, 34);
            btnGravar.TabIndex = 98;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(142, 163);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 34);
            btnCancelar.TabIndex = 97;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(84, 25);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(124, 23);
            txtNome.TabIndex = 96;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 28);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 95;
            label5.Text = "Nome:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 117);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 105;
            label1.Text = "Parceiro:";
            // 
            // cbParceiro
            // 
            cbParceiro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbParceiro.FormattingEnabled = true;
            cbParceiro.Location = new Point(84, 114);
            cbParceiro.Name = "cbParceiro";
            cbParceiro.Size = new Size(124, 23);
            cbParceiro.TabIndex = 106;
            // 
            // TelaCupomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(230, 209);
            Controls.Add(cbParceiro);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(dateValidade);
            Controls.Add(txtValor);
            Controls.Add(label6);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(txtNome);
            Controls.Add(label5);
            Name = "TelaCupomForm";
            Text = "Cadastro de Cupom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private DateTimePicker dateValidade;
        private TextBox txtValor;
        private Label label6;
        private Button btnGravar;
        private Button btnCancelar;
        private TextBox txtNome;
        private Label label5;
        private Label label1;
        private ComboBox cbParceiro;
    }
}