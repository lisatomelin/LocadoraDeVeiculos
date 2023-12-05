namespace LocadoraDeVeiculos.WinFormsApp.ModuloAluguel
{
    partial class TelaDevolucaoAluguelForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            chListTaxas = new CheckedListBox();
            tabPage2 = new TabPage();
            chTaxasAdicionais = new CheckedListBox();
            txtValorTotal = new TextBox();
            label2 = new Label();
            label13 = new Label();
            dtDevolucaoPrevista = new DateTimePicker();
            label12 = new Label();
            dtLocacao = new DateTimePicker();
            label11 = new Label();
            cbAutomovel = new ComboBox();
            label10 = new Label();
            cbCondutor = new ComboBox();
            label9 = new Label();
            cbPlanoDeCobranca = new ComboBox();
            label8 = new Label();
            cbGrupoAutomoveis = new ComboBox();
            label4 = new Label();
            label7 = new Label();
            cbCliente = new ComboBox();
            label6 = new Label();
            txtKmAutomovel = new TextBox();
            cbFuncionario = new ComboBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label3 = new Label();
            txtKmPercorrido = new TextBox();
            label5 = new Label();
            dtDataDevolucao = new DateTimePicker();
            cbNivelDoTanque = new ComboBox();
            label14 = new Label();
            cbCupom = new ComboBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.ImeMode = ImeMode.NoControl;
            tabControl1.Location = new Point(14, 205);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(536, 169);
            tabControl1.TabIndex = 92;
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
            chListTaxas.FormattingEnabled = true;
            chListTaxas.Location = new Point(15, 15);
            chListTaxas.Name = "chListTaxas";
            chListTaxas.Size = new Size(504, 112);
            chListTaxas.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(chTaxasAdicionais);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(528, 141);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Taxas Adicionais";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // chTaxasAdicionais
            // 
            chTaxasAdicionais.FormattingEnabled = true;
            chTaxasAdicionais.Location = new Point(12, 15);
            chTaxasAdicionais.Name = "chTaxasAdicionais";
            chTaxasAdicionais.Size = new Size(507, 112);
            chTaxasAdicionais.TabIndex = 0;
            // 
            // txtValorTotal
            // 
            txtValorTotal.Location = new Point(135, 394);
            txtValorTotal.Name = "txtValorTotal";
            txtValorTotal.Size = new Size(121, 23);
            txtValorTotal.TabIndex = 91;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 397);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 90;
            label2.Text = "Valor Total Previsto:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(33, 164);
            label13.Name = "label13";
            label13.Size = new Size(110, 15);
            label13.TabIndex = 89;
            label13.Text = "Devolução Prevista:";
            // 
            // dtDevolucaoPrevista
            // 
            dtDevolucaoPrevista.Enabled = false;
            dtDevolucaoPrevista.Format = DateTimePickerFormat.Short;
            dtDevolucaoPrevista.Location = new Point(149, 161);
            dtDevolucaoPrevista.Name = "dtDevolucaoPrevista";
            dtDevolucaoPrevista.Size = new Size(121, 23);
            dtDevolucaoPrevista.TabIndex = 88;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(60, 135);
            label12.Name = "label12";
            label12.Size = new Size(81, 15);
            label12.TabIndex = 87;
            label12.Text = "Data Locação:";
            // 
            // dtLocacao
            // 
            dtLocacao.Enabled = false;
            dtLocacao.Format = DateTimePickerFormat.Short;
            dtLocacao.Location = new Point(149, 132);
            dtLocacao.Name = "dtLocacao";
            dtLocacao.Size = new Size(121, 23);
            dtLocacao.TabIndex = 86;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(300, 75);
            label11.Name = "label11";
            label11.Size = new Size(110, 15);
            label11.TabIndex = 84;
            label11.Text = "KM do Automóvel: ";
            // 
            // cbAutomovel
            // 
            cbAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAutomovel.Enabled = false;
            cbAutomovel.FormattingEnabled = true;
            cbAutomovel.Location = new Point(416, 41);
            cbAutomovel.Name = "cbAutomovel";
            cbAutomovel.Size = new Size(121, 23);
            cbAutomovel.TabIndex = 83;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(338, 44);
            label10.Name = "label10";
            label10.Size = new Size(72, 15);
            label10.TabIndex = 82;
            label10.Text = "Automóvel: ";
            // 
            // cbCondutor
            // 
            cbCondutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondutor.Enabled = false;
            cbCondutor.FormattingEnabled = true;
            cbCondutor.Location = new Point(416, 12);
            cbCondutor.Name = "cbCondutor";
            cbCondutor.Size = new Size(121, 23);
            cbCondutor.TabIndex = 81;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(346, 15);
            label9.Name = "label9";
            label9.Size = new Size(64, 15);
            label9.TabIndex = 80;
            label9.Text = "Condutor: ";
            // 
            // cbPlanoDeCobranca
            // 
            cbPlanoDeCobranca.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPlanoDeCobranca.Enabled = false;
            cbPlanoDeCobranca.FormattingEnabled = true;
            cbPlanoDeCobranca.Location = new Point(149, 103);
            cbPlanoDeCobranca.Name = "cbPlanoDeCobranca";
            cbPlanoDeCobranca.Size = new Size(121, 23);
            cbPlanoDeCobranca.TabIndex = 79;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 106);
            label8.Name = "label8";
            label8.Size = new Size(113, 15);
            label8.TabIndex = 78;
            label8.Text = "Plano de Cobrança: ";
            // 
            // cbGrupoAutomoveis
            // 
            cbGrupoAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupoAutomoveis.Enabled = false;
            cbGrupoAutomoveis.FormattingEnabled = true;
            cbGrupoAutomoveis.Location = new Point(149, 74);
            cbGrupoAutomoveis.Name = "cbGrupoAutomoveis";
            cbGrupoAutomoveis.Size = new Size(121, 23);
            cbGrupoAutomoveis.TabIndex = 77;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 77);
            label4.Name = "label4";
            label4.Size = new Size(129, 15);
            label4.TabIndex = 76;
            label4.Text = "Grupo de Automóveis: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(355, 102);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 75;
            label7.Text = "Cupom: ";
            // 
            // cbCliente
            // 
            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCliente.Enabled = false;
            cbCliente.FormattingEnabled = true;
            cbCliente.Location = new Point(149, 45);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(121, 23);
            cbCliente.TabIndex = 74;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(94, 49);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 73;
            label6.Text = "Cliente:";
            // 
            // txtKmAutomovel
            // 
            txtKmAutomovel.Enabled = false;
            txtKmAutomovel.Location = new Point(416, 70);
            txtKmAutomovel.Name = "txtKmAutomovel";
            txtKmAutomovel.Size = new Size(121, 23);
            txtKmAutomovel.TabIndex = 72;
            // 
            // cbFuncionario
            // 
            cbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuncionario.Enabled = false;
            cbFuncionario.FormattingEnabled = true;
            cbFuncionario.Location = new Point(149, 16);
            cbFuncionario.Name = "cbFuncionario";
            cbFuncionario.Size = new Size(121, 23);
            cbFuncionario.TabIndex = 71;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(391, 384);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(76, 34);
            btnGravar.TabIndex = 70;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(473, 384);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 34);
            btnCancelar.TabIndex = 69;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 20);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 68;
            label1.Text = "Funcionário:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(322, 132);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 95;
            label3.Text = "KM Percorrido:";
            // 
            // txtKmPercorrido
            // 
            txtKmPercorrido.Location = new Point(416, 128);
            txtKmPercorrido.Name = "txtKmPercorrido";
            txtKmPercorrido.Size = new Size(121, 23);
            txtKmPercorrido.TabIndex = 94;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(315, 163);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 97;
            label5.Text = "Data Devolução:";
            // 
            // dtDataDevolucao
            // 
            dtDataDevolucao.Format = DateTimePickerFormat.Short;
            dtDataDevolucao.Location = new Point(416, 157);
            dtDataDevolucao.Name = "dtDataDevolucao";
            dtDataDevolucao.Size = new Size(121, 23);
            dtDataDevolucao.TabIndex = 96;
            // 
            // cbNivelDoTanque
            // 
            cbNivelDoTanque.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNivelDoTanque.FormattingEnabled = true;
            cbNivelDoTanque.Location = new Point(416, 186);
            cbNivelDoTanque.Name = "cbNivelDoTanque";
            cbNivelDoTanque.Size = new Size(121, 23);
            cbNivelDoTanque.TabIndex = 99;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(313, 190);
            label14.Name = "label14";
            label14.Size = new Size(95, 15);
            label14.TabIndex = 98;
            label14.Text = "Nível do Tanque:";
            // 
            // cbCupom
            // 
            cbCupom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCupom.Enabled = false;
            cbCupom.FormattingEnabled = true;
            cbCupom.Location = new Point(416, 99);
            cbCupom.Name = "cbCupom";
            cbCupom.Size = new Size(121, 23);
            cbCupom.TabIndex = 100;
            // 
            // TelaDevolucaoAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 430);
            Controls.Add(cbCupom);
            Controls.Add(cbNivelDoTanque);
            Controls.Add(label14);
            Controls.Add(label5);
            Controls.Add(dtDataDevolucao);
            Controls.Add(label3);
            Controls.Add(txtKmPercorrido);
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
            Name = "TelaDevolucaoAluguelForm";
            Text = "Cadastro de Devolução de Aluguel";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private CheckedListBox chListTaxas;
        private TabPage tabPage2;
        private CheckedListBox chTaxasAdicionais;
        private TextBox txtValorTotal;
        private Label label2;
        private Label label13;
        private DateTimePicker dtDevolucaoPrevista;
        private Label label12;
        private DateTimePicker dtLocacao;
        private Label label11;
        private ComboBox cbAutomovel;
        private Label label10;
        private ComboBox cbCondutor;
        private Label label9;
        private ComboBox cbPlanoDeCobranca;
        private Label label8;
        private ComboBox cbGrupoAutomoveis;
        private Label label4;
        private Label label7;
        private ComboBox cbCliente;
        private Label label6;
        private TextBox txtKmAutomovel;
        private ComboBox cbFuncionario;
        private Button btnGravar;
        private Button btnCancelar;
        private Label label1;
        private Label label3;
        private TextBox txtKmPercorrido;
        private Label label5;
        private DateTimePicker dtDataDevolucao;
        private ComboBox cbNivelDoTanque;
        private Label label14;
        private ComboBox cbCupom;
    }
}