namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxasServicos
{
    partial class TelaTaxasServicosForm
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
            rdbCobranca = new RadioButton();
            rdbPrecoFixo = new RadioButton();
            txtPreco = new TextBox();
            label4 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            txtNome = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // rdbCobranca
            // 
            rdbCobranca.AutoSize = true;
            rdbCobranca.Location = new Point(228, 66);
            rdbCobranca.Margin = new Padding(5, 6, 5, 6);
            rdbCobranca.Name = "rdbCobranca";
            rdbCobranca.Size = new Size(186, 34);
            rdbCobranca.TabIndex = 61;
            rdbCobranca.Text = "Cobrança Diária";
            rdbCobranca.UseVisualStyleBackColor = true;
            // 
            // rdbPrecoFixo
            // 
            rdbPrecoFixo.AutoSize = true;
            rdbPrecoFixo.Location = new Point(48, 62);
            rdbPrecoFixo.Margin = new Padding(5, 6, 5, 6);
            rdbPrecoFixo.Name = "rdbPrecoFixo";
            rdbPrecoFixo.Size = new Size(133, 34);
            rdbPrecoFixo.TabIndex = 60;
            rdbPrecoFixo.Text = "Preço Fixo";
            rdbPrecoFixo.UseVisualStyleBackColor = true;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(120, 104);
            txtPreco.Margin = new Padding(5, 6, 5, 6);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(158, 35);
            txtPreco.TabIndex = 59;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 110);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(70, 30);
            label4.TabIndex = 58;
            label4.Text = "Preço:";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(189, 384);
            btnGravar.Margin = new Padding(5, 6, 5, 6);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(130, 68);
            btnGravar.TabIndex = 57;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(329, 384);
            btnCancelar.Margin = new Padding(5, 6, 5, 6);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 68);
            btnCancelar.TabIndex = 56;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(120, 46);
            txtNome.Margin = new Padding(5, 6, 5, 6);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(330, 35);
            txtNome.TabIndex = 55;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 52);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 30);
            label1.TabIndex = 54;
            label1.Text = "Nome:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbCobranca);
            groupBox1.Controls.Add(rdbPrecoFixo);
            groupBox1.Location = new Point(21, 188);
            groupBox1.Margin = new Padding(5, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 6, 5, 6);
            groupBox1.Size = new Size(432, 146);
            groupBox1.TabIndex = 62;
            groupBox1.TabStop = false;
            groupBox1.Text = "Plano de Calculo";
            // 
            // TelaTaxasServicosForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 476);
            Controls.Add(groupBox1);
            Controls.Add(txtPreco);
            Controls.Add(label4);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "TelaTaxasServicosForm";
            Text = "Cadastro de Taxa e Serviços";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rdbCobranca;
        private RadioButton rdbPrecoFixo;
        private TextBox txtPreco;
        private Label label4;
        private Button btnGravar;
        private Button btnCancelar;
        private TextBox txtNome;
        private Label label1;
        private GroupBox groupBox1;
    }
}