namespace LocadoraDeVeiculos.WinFormsApp.ModuloPrecos
{
    partial class TelaPrecosForm
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
            btnGravar = new Button();
            btnCancelar = new Button();
            txtGasolina = new TextBox();
            label1 = new Label();
            txtGas = new TextBox();
            label2 = new Label();
            txtDiesel = new TextBox();
            label3 = new Label();
            txtAlcool = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(131, 148);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(76, 34);
            btnGravar.TabIndex = 11;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(213, 148);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 34);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtGasolina
            // 
            txtGasolina.Location = new Point(89, 21);
            txtGasolina.Name = "txtGasolina";
            txtGasolina.Size = new Size(201, 23);
            txtGasolina.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 24);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 12;
            label1.Text = "Gasolina:";
            // 
            // txtGas
            // 
            txtGas.Location = new Point(89, 50);
            txtGas.Name = "txtGas";
            txtGas.Size = new Size(201, 23);
            txtGas.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 53);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 14;
            label2.Text = "Gás:";
            // 
            // txtDiesel
            // 
            txtDiesel.Location = new Point(89, 79);
            txtDiesel.Name = "txtDiesel";
            txtDiesel.Size = new Size(201, 23);
            txtDiesel.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 82);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 16;
            label3.Text = "Diesel:";
            // 
            // txtAlcool
            // 
            txtAlcool.Location = new Point(89, 108);
            txtAlcool.Name = "txtAlcool";
            txtAlcool.Size = new Size(201, 23);
            txtAlcool.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 111);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 18;
            label4.Text = "Alcool:";
            // 
            // TelaPrecosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 194);
            Controls.Add(txtAlcool);
            Controls.Add(label4);
            Controls.Add(txtDiesel);
            Controls.Add(label3);
            Controls.Add(txtGas);
            Controls.Add(label2);
            Controls.Add(txtGasolina);
            Controls.Add(label1);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Name = "TelaPrecosForm";
            Text = "Configuração dos Preços";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGravar;
        private Button btnCancelar;
        private TextBox txtGasolina;
        private Label label1;
        private TextBox txtGas;
        private Label label2;
        private TextBox txtDiesel;
        private Label label3;
        private TextBox txtAlcool;
        private Label label4;
    }
}