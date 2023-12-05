namespace LocadoraDeVeiculos.WinFormsApp.ModuloAluguel
{
    partial class TelaAluguelForm
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
            cbCliente = new ComboBox();
            label6 = new Label();
            txtKmAutomovel = new TextBox();
            cbFuncionario = new ComboBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            cbGrupoAutomoveis = new ComboBox();
            label4 = new Label();
            cbPlanoDeCobranca = new ComboBox();
            label8 = new Label();
            cbCondutor = new ComboBox();
            label9 = new Label();
            cbAutomovel = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            dtLocacao = new DateTimePicker();
            label12 = new Label();
            label13 = new Label();
            dtDevolucaoPrevista = new DateTimePicker();
            label7 = new Label();
            txtValorTotal = new TextBox();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            chListTaxas = new CheckedListBox();
            cbCupom = new ComboBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // cbCliente
            // 
            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCliente.FormattingEnabled = true;
            cbCliente.Location = new Point(149, 43);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(121, 23);
            cbCliente.TabIndex = 46;
            cbCliente.SelectedIndexChanged += cbCliente_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(94, 47);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 45;
            label6.Text = "Cliente:";
            // 
            // txtKmAutomovel
            // 
            txtKmAutomovel.Location = new Point(416, 76);
            txtKmAutomovel.Name = "txtKmAutomovel";
            txtKmAutomovel.ReadOnly = true;
            txtKmAutomovel.Size = new Size(121, 23);
            txtKmAutomovel.TabIndex = 44;
            txtKmAutomovel.TextChanged += txtKmAutomovel_TextChanged;
            // 
            // cbFuncionario
            // 
            cbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuncionario.FormattingEnabled = true;
            cbFuncionario.Location = new Point(149, 14);
            cbFuncionario.Name = "cbFuncionario";
            cbFuncionario.Size = new Size(121, 23);
            cbFuncionario.TabIndex = 43;
            cbFuncionario.SelectedIndexChanged += cbFuncionario_SelectedIndexChanged;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(393, 385);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(76, 34);
            btnGravar.TabIndex = 39;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(475, 385);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 34);
            btnCancelar.TabIndex = 38;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 18);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 35;
            label1.Text = "Funcionário:";
            // 
            // cbGrupoAutomoveis
            // 
            cbGrupoAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupoAutomoveis.FormattingEnabled = true;
            cbGrupoAutomoveis.Location = new Point(149, 72);
            cbGrupoAutomoveis.Name = "cbGrupoAutomoveis";
            cbGrupoAutomoveis.Size = new Size(121, 23);
            cbGrupoAutomoveis.TabIndex = 50;
            cbGrupoAutomoveis.SelectedIndexChanged += cbGrupoAutomoveis_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 75);
            label4.Name = "label4";
            label4.Size = new Size(129, 15);
            label4.TabIndex = 49;
            label4.Text = "Grupo de Automóveis: ";
            // 
            // cbPlanoDeCobranca
            // 
            cbPlanoDeCobranca.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPlanoDeCobranca.FormattingEnabled = true;
            cbPlanoDeCobranca.Location = new Point(149, 101);
            cbPlanoDeCobranca.Name = "cbPlanoDeCobranca";
            cbPlanoDeCobranca.Size = new Size(121, 23);
            cbPlanoDeCobranca.TabIndex = 52;
            cbPlanoDeCobranca.SelectedIndexChanged += cbPlanoDeCobranca_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 104);
            label8.Name = "label8";
            label8.Size = new Size(113, 15);
            label8.TabIndex = 51;
            label8.Text = "Plano de Cobrança: ";
            // 
            // cbCondutor
            // 
            cbCondutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondutor.FormattingEnabled = true;
            cbCondutor.Location = new Point(416, 18);
            cbCondutor.Name = "cbCondutor";
            cbCondutor.Size = new Size(121, 23);
            cbCondutor.TabIndex = 54;
            cbCondutor.SelectedIndexChanged += cbCondutor_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(346, 21);
            label9.Name = "label9";
            label9.Size = new Size(64, 15);
            label9.TabIndex = 53;
            label9.Text = "Condutor: ";
            // 
            // cbAutomovel
            // 
            cbAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAutomovel.Enabled = false;
            cbAutomovel.FormattingEnabled = true;
            cbAutomovel.Location = new Point(416, 47);
            cbAutomovel.Name = "cbAutomovel";
            cbAutomovel.Size = new Size(121, 23);
            cbAutomovel.TabIndex = 56;
            cbAutomovel.SelectedIndexChanged += cbAutomovel_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(338, 50);
            label10.Name = "label10";
            label10.Size = new Size(72, 15);
            label10.TabIndex = 55;
            label10.Text = "Automóvel: ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(300, 81);
            label11.Name = "label11";
            label11.Size = new Size(110, 15);
            label11.TabIndex = 57;
            label11.Text = "KM do Automóvel: ";
            // 
            // dtLocacao
            // 
            dtLocacao.Enabled = false;
            dtLocacao.Format = DateTimePickerFormat.Short;
            dtLocacao.Location = new Point(149, 130);
            dtLocacao.Name = "dtLocacao";
            dtLocacao.Size = new Size(121, 23);
            dtLocacao.TabIndex = 59;
            dtLocacao.ValueChanged += dtLocacao_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(60, 133);
            label12.Name = "label12";
            label12.Size = new Size(81, 15);
            label12.TabIndex = 60;
            label12.Text = "Data Locação:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(33, 162);
            label13.Name = "label13";
            label13.Size = new Size(110, 15);
            label13.TabIndex = 62;
            label13.Text = "Devolução Prevista:";
            // 
            // dtDevolucaoPrevista
            // 
            dtDevolucaoPrevista.Enabled = false;
            dtDevolucaoPrevista.Format = DateTimePickerFormat.Short;
            dtDevolucaoPrevista.Location = new Point(149, 159);
            dtDevolucaoPrevista.Name = "dtDevolucaoPrevista";
            dtDevolucaoPrevista.Size = new Size(121, 23);
            dtDevolucaoPrevista.TabIndex = 61;
            dtDevolucaoPrevista.ValueChanged += dtDevolucaoPrevista_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(355, 108);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 47;
            label7.Text = "Cupom: ";
            // 
            // txtValorTotal
            // 
            txtValorTotal.Location = new Point(135, 392);
            txtValorTotal.Name = "txtValorTotal";
            txtValorTotal.ReadOnly = true;
            txtValorTotal.Size = new Size(121, 23);
            txtValorTotal.TabIndex = 65;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 395);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 64;
            label2.Text = "Valor Total Previsto:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.ImeMode = ImeMode.NoControl;
            tabControl1.Location = new Point(14, 203);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(536, 169);
            tabControl1.TabIndex = 66;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(chListTaxas);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(528, 141);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Taxas Selecionadas";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // chListTaxas
            // 
            chListTaxas.CheckOnClick = true;
            chListTaxas.Enabled = false;
            chListTaxas.FormattingEnabled = true;
            chListTaxas.Location = new Point(15, 15);
            chListTaxas.Name = "chListTaxas";
            chListTaxas.Size = new Size(504, 112);
            chListTaxas.TabIndex = 0;
            chListTaxas.SelectedIndexChanged += chListTaxas_SelectedIndexChanged;
            // 
            // cbCupom
            // 
            cbCupom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCupom.Enabled = false;
            cbCupom.FormattingEnabled = true;
            cbCupom.Location = new Point(414, 104);
            cbCupom.Name = "cbCupom";
            cbCupom.Size = new Size(121, 23);
            cbCupom.TabIndex = 67;
            cbCupom.SelectedIndexChanged += cbCupom_SelectedIndexChanged;
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 431);
            Controls.Add(cbCupom);
            Controls.Add(tabControl1);
            Controls.Add(txtValorTotal);
            Controls.Add(label2);
            Controls.Add(label13);
            Controls.Add(dtDevolucaoPrevista);
            Controls.Add(label12);
            Controls.Add(dtLocacao);
            Controls.Add(label11);
            Controls.Add(cbAutomovel);
            Controls.Add(label10);
            Controls.Add(cbCondutor);
            Controls.Add(label9);
            Controls.Add(cbPlanoDeCobranca);
            Controls.Add(label8);
            Controls.Add(cbGrupoAutomoveis);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(cbCliente);
            Controls.Add(label6);
            Controls.Add(txtKmAutomovel);
            Controls.Add(cbFuncionario);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Name = "TelaAluguelForm";
            Text = "Cadastro de Aluguel";
            Load += TelaAluguelForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cbCliente;
        private Label label6;
        private TextBox txtKmAutomovel;
        private ComboBox cbFuncionario;
        private Button btnGravar;
        private Button btnCancelar;
        private Label label1;
        private ComboBox cbGrupoAutomoveis;
        private Label label4;
        private ComboBox cbPlanoDeCobranca;
        private Label label8;
        private ComboBox cbCondutor;
        private Label label9;
        private ComboBox cbAutomovel;
        private Label label10;
        private Label label11;
        private DateTimePicker dtLocacao;
        private Label label12;
        private Label label13;
        private DateTimePicker dtDevolucaoPrevista;
        private Label label7;
        private TextBox txtValorTotal;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private CheckedListBox chListTaxas;
        private ComboBox cbCupom;
    }
}