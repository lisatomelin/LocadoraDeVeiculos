namespace LocadoraDeVeiculos.WinFormsApp.ModuloAluguel
{
    partial class TelaGerarPdfForm
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
            btnGravar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            btnDiretorio = new Button();
            txtDiretorio = new TextBox();
            rdbDevolucao = new RadioButton();
            rdbLocacao = new RadioButton();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtCupom
            // 
            txtCupom.Enabled = false;
            txtCupom.Location = new Point(283, -209);
            txtCupom.Margin = new Padding(3, 4, 3, 4);
            txtCupom.Name = "txtCupom";
            txtCupom.Size = new Size(138, 27);
            txtCupom.TabIndex = 96;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(186, 229);
            btnGravar.Margin = new Padding(3, 4, 3, 4);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(87, 45);
            btnGravar.TabIndex = 95;
            btnGravar.Text = "Gerar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGerar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(280, 229);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(87, 45);
            btnCancelar.TabIndex = 94;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(14, 116);
            label1.Name = "label1";
            label1.Size = new Size(171, 23);
            label1.TabIndex = 102;
            label1.Text = "Escolha um diretorio:";
            // 
            // btnDiretorio
            // 
            btnDiretorio.BackColor = Color.Transparent;
            btnDiretorio.Location = new Point(191, 108);
            btnDiretorio.Margin = new Padding(3, 4, 3, 4);
            btnDiretorio.Name = "btnDiretorio";
            btnDiretorio.Size = new Size(160, 41);
            btnDiretorio.TabIndex = 101;
            btnDiretorio.Text = "Diretório";
            btnDiretorio.UseVisualStyleBackColor = false;
            btnDiretorio.Click += btnDiretorio_Click;
            // 
            // txtDiretorio
            // 
            txtDiretorio.Location = new Point(14, 157);
            txtDiretorio.Margin = new Padding(3, 4, 3, 4);
            txtDiretorio.Name = "txtDiretorio";
            txtDiretorio.Size = new Size(337, 27);
            txtDiretorio.TabIndex = 100;
            // 
            // rdbDevolucao
            // 
            rdbDevolucao.AutoSize = true;
            rdbDevolucao.Location = new Point(211, 59);
            rdbDevolucao.Margin = new Padding(3, 4, 3, 4);
            rdbDevolucao.Name = "rdbDevolucao";
            rdbDevolucao.Size = new Size(101, 24);
            rdbDevolucao.TabIndex = 105;
            rdbDevolucao.TabStop = true;
            rdbDevolucao.Text = "Devolução";
            rdbDevolucao.UseVisualStyleBackColor = true;
            // 
            // rdbLocacao
            // 
            rdbLocacao.AutoSize = true;
            rdbLocacao.Location = new Point(211, 27);
            rdbLocacao.Margin = new Padding(3, 4, 3, 4);
            rdbLocacao.Name = "rdbLocacao";
            rdbLocacao.Size = new Size(89, 24);
            rdbLocacao.TabIndex = 104;
            rdbLocacao.TabStop = true;
            rdbLocacao.Text = "Locação ";
            rdbLocacao.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(14, 28);
            label2.Name = "label2";
            label2.Size = new Size(200, 23);
            label2.TabIndex = 103;
            label2.Text = "Escolha uma das opções:";
            // 
            // TelaGerarPdfForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 290);
            Controls.Add(rdbDevolucao);
            Controls.Add(rdbLocacao);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDiretorio);
            Controls.Add(txtDiretorio);
            Controls.Add(txtCupom);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaGerarPdfForm";
            Text = "Gerar PDF";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCupom;
        private Button btnGravar;
        private Button btnCancelar;
        private Label label1;
        private Button btnDiretorio;
        private TextBox txtDiretorio;
        private RadioButton rdbDevolucao;
        private RadioButton rdbLocacao;
        private Label label2;
    }
}