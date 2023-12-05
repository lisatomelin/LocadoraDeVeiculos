namespace LocadoraDeVeiculos.WinFormsApp.ModuloCobranca
{
    partial class TelaCobrancaForm
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
            txtPrecoDiaria = new TextBox();
            label1 = new Label();
            cbGrupoAutomoveis = new ComboBox();
            groupBox1 = new GroupBox();
            txtKmDisponivel = new TextBox();
            label5 = new Label();
            txtPrecoExtrapolado = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cbTipoPlano = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(192, 201);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(76, 34);
            btnGravar.TabIndex = 13;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(274, 201);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 34);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtPrecoDiaria
            // 
            txtPrecoDiaria.Location = new Point(169, 51);
            txtPrecoDiaria.Name = "txtPrecoDiaria";
            txtPrecoDiaria.Size = new Size(142, 23);
            txtPrecoDiaria.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 15);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 10;
            label1.Text = "Grupo de Automóveis:";
            // 
            // cbGrupoAutomoveis
            // 
            cbGrupoAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupoAutomoveis.FormattingEnabled = true;
            cbGrupoAutomoveis.Location = new Point(150, 12);
            cbGrupoAutomoveis.Name = "cbGrupoAutomoveis";
            cbGrupoAutomoveis.Size = new Size(188, 23);
            cbGrupoAutomoveis.TabIndex = 14;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtKmDisponivel);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtPrecoExtrapolado);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbTipoPlano);
            groupBox1.Controls.Add(txtPrecoDiaria);
            groupBox1.Location = new Point(18, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(317, 148);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuração de Planos";
            // 
            // txtKmDisponivel
            // 
            txtKmDisponivel.Enabled = false;
            txtKmDisponivel.Location = new Point(169, 109);
            txtKmDisponivel.Name = "txtKmDisponivel";
            txtKmDisponivel.Size = new Size(142, 23);
            txtKmDisponivel.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 112);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 20;
            label5.Text = "Km Disponíveis:";
            // 
            // txtPrecoExtrapolado
            // 
            txtPrecoExtrapolado.Enabled = false;
            txtPrecoExtrapolado.Location = new Point(169, 80);
            txtPrecoExtrapolado.Name = "txtPrecoExtrapolado";
            txtPrecoExtrapolado.Size = new Size(142, 23);
            txtPrecoExtrapolado.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 83);
            label4.Name = "label4";
            label4.Size = new Size(156, 15);
            label4.TabIndex = 18;
            label4.Text = "Preço Por Km (Extrapolado):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 52);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 17;
            label3.Text = "Preço Diária:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 25);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 16;
            label2.Text = "Tipo de Plano:";
            // 
            // cbTipoPlano
            // 
            cbTipoPlano.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoPlano.FormattingEnabled = true;
            cbTipoPlano.Location = new Point(169, 22);
            cbTipoPlano.Name = "cbTipoPlano";
            cbTipoPlano.Size = new Size(142, 23);
            cbTipoPlano.TabIndex = 16;
            cbTipoPlano.SelectedIndexChanged += cbTipoPlano_SelectedIndexChanged;
            // 
            // TelaCobrancaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 247);
            Controls.Add(groupBox1);
            Controls.Add(cbGrupoAutomoveis);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Name = "TelaCobrancaForm";
            Text = "Cadastro de Cobranca";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGravar;
        private Button btnCancelar;
        private TextBox txtPrecoDiaria;
        private Label label1;
        private ComboBox cbGrupoAutomoveis;
        private GroupBox groupBox1;
        private Label label2;
        private ComboBox cbTipoPlano;
        private Label label4;
        private Label label3;
        private TextBox txtKmDisponivel;
        private Label label5;
        private TextBox txtPrecoExtrapolado;
    }
}