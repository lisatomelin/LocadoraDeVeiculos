namespace LocadoraDeVeiculos.WinFormsApp
{
    partial class TelaPrincipalForm
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
            menuStrip1 = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            aluguelToolStripMenuItem = new ToolStripMenuItem();
            taxasEServiçosToolStripMenuItem1 = new ToolStripMenuItem();
            cupomToolStripMenuItem1 = new ToolStripMenuItem();
            parceiroToolStripMenuItem1 = new ToolStripMenuItem();
            aluguelToolStripMenuItem1 = new ToolStripMenuItem();
            automóvelToolStripMenuItem = new ToolStripMenuItem();
            grupoDeAutomóveisToolStripMenuItem1 = new ToolStripMenuItem();
            pToolStripMenuItem = new ToolStripMenuItem();
            automóvelToolStripMenuItem1 = new ToolStripMenuItem();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            condutorToolStripMenuItem1 = new ToolStripMenuItem();
            clienteToolStripMenuItem1 = new ToolStripMenuItem();
            funcionárioToolStripMenuItem = new ToolStripMenuItem();
            panelRegistros = new Panel();
            statusStrip1 = new StatusStrip();
            labelRodape = new ToolStripStatusLabel();
            btnAdicionar = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDevolucao = new ToolStripButton();
            btnPrecos = new ToolStripButton();
            btnFiltrar = new ToolStripButton();
            btnPdf = new ToolStripButton();
            btnEmail = new ToolStripButton();
            lblTipoCadastro = new ToolStripLabel();
            toolBox = new ToolStrip();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolBox.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.PowderBlue;
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(567, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aluguelToolStripMenuItem, automóvelToolStripMenuItem, clienteToolStripMenuItem, funcionárioToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // aluguelToolStripMenuItem
            // 
            aluguelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { taxasEServiçosToolStripMenuItem1, cupomToolStripMenuItem1, parceiroToolStripMenuItem1, aluguelToolStripMenuItem1 });
            aluguelToolStripMenuItem.Name = "aluguelToolStripMenuItem";
            aluguelToolStripMenuItem.Size = new Size(137, 22);
            aluguelToolStripMenuItem.Text = "Aluguel";
            // 
            // taxasEServiçosToolStripMenuItem1
            // 
            taxasEServiçosToolStripMenuItem1.Name = "taxasEServiçosToolStripMenuItem1";
            taxasEServiçosToolStripMenuItem1.Size = new Size(157, 22);
            taxasEServiçosToolStripMenuItem1.Text = "Taxas e Serviços";
            taxasEServiçosToolStripMenuItem1.Click += taxasEServiçosToolStripMenuItem1_Click;
            // 
            // cupomToolStripMenuItem1
            // 
            cupomToolStripMenuItem1.Name = "cupomToolStripMenuItem1";
            cupomToolStripMenuItem1.Size = new Size(157, 22);
            cupomToolStripMenuItem1.Text = "Cupons";
            cupomToolStripMenuItem1.Click += cupomToolStripMenuItem1_Click;
            // 
            // parceiroToolStripMenuItem1
            // 
            parceiroToolStripMenuItem1.Name = "parceiroToolStripMenuItem1";
            parceiroToolStripMenuItem1.Size = new Size(157, 22);
            parceiroToolStripMenuItem1.Text = "Parceiros";
            parceiroToolStripMenuItem1.Click += parceiroToolStripMenuItem1_Click;
            // 
            // aluguelToolStripMenuItem1
            // 
            aluguelToolStripMenuItem1.Name = "aluguelToolStripMenuItem1";
            aluguelToolStripMenuItem1.Size = new Size(157, 22);
            aluguelToolStripMenuItem1.Text = "Aluguéis";
            aluguelToolStripMenuItem1.Click += aluguelToolStripMenuItem1_Click;
            // 
            // automóvelToolStripMenuItem
            // 
            automóvelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { grupoDeAutomóveisToolStripMenuItem1, pToolStripMenuItem, automóvelToolStripMenuItem1 });
            automóvelToolStripMenuItem.Name = "automóvelToolStripMenuItem";
            automóvelToolStripMenuItem.Size = new Size(137, 22);
            automóvelToolStripMenuItem.Text = "Automóvel";
            // 
            // grupoDeAutomóveisToolStripMenuItem1
            // 
            grupoDeAutomóveisToolStripMenuItem1.Name = "grupoDeAutomóveisToolStripMenuItem1";
            grupoDeAutomóveisToolStripMenuItem1.Size = new Size(190, 22);
            grupoDeAutomóveisToolStripMenuItem1.Text = "Grupo de Automóveis";
            grupoDeAutomóveisToolStripMenuItem1.Click += grupoDeAutomóveisToolStripMenuItem1_Click;
            // 
            // pToolStripMenuItem
            // 
            pToolStripMenuItem.Name = "pToolStripMenuItem";
            pToolStripMenuItem.Size = new Size(190, 22);
            pToolStripMenuItem.Text = "Planos de Cobrança";
            pToolStripMenuItem.Click += pToolStripMenuItem_Click;
            // 
            // automóvelToolStripMenuItem1
            // 
            automóvelToolStripMenuItem1.Name = "automóvelToolStripMenuItem1";
            automóvelToolStripMenuItem1.Size = new Size(190, 22);
            automóvelToolStripMenuItem1.Text = "Automóveis";
            automóvelToolStripMenuItem1.Click += automóvelToolStripMenuItem1_Click;
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { condutorToolStripMenuItem1, clienteToolStripMenuItem1 });
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(137, 22);
            clienteToolStripMenuItem.Text = "Cliente";
            // 
            // condutorToolStripMenuItem1
            // 
            condutorToolStripMenuItem1.Name = "condutorToolStripMenuItem1";
            condutorToolStripMenuItem1.Size = new Size(125, 22);
            condutorToolStripMenuItem1.Text = "Condutor";
            condutorToolStripMenuItem1.Click += condutorToolStripMenuItem1_Click;
            // 
            // clienteToolStripMenuItem1
            // 
            clienteToolStripMenuItem1.Name = "clienteToolStripMenuItem1";
            clienteToolStripMenuItem1.Size = new Size(125, 22);
            clienteToolStripMenuItem1.Text = "Clientes";
            clienteToolStripMenuItem1.Click += clienteToolStripMenuItem1_Click;
            // 
            // funcionárioToolStripMenuItem
            // 
            funcionárioToolStripMenuItem.Name = "funcionárioToolStripMenuItem";
            funcionárioToolStripMenuItem.Size = new Size(137, 22);
            funcionárioToolStripMenuItem.Text = "Funcionário";
            funcionárioToolStripMenuItem.Click += funcionárioToolStripMenuItem_Click;
            // 
            // panelRegistros
            // 
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 69);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(567, 280);
            panelRegistros.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelRodape });
            statusStrip1.Location = new Point(0, 327);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(567, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new Size(52, 17);
            labelRodape.Text = "[rodapé]";
            // 
            // btnAdicionar
            // 
            btnAdicionar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdicionar.Image = Properties.Resources.adicionar__1_;
            btnAdicionar.ImageScaling = ToolStripItemImageScaling.None;
            btnAdicionar.ImageTransparentColor = Color.Magenta;
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Padding = new Padding(7);
            btnAdicionar.Size = new Size(42, 42);
            btnAdicionar.ToolTipText = "\r\n";
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Image = Properties.Resources.editar;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(7);
            btnEditar.Size = new Size(42, 42);
            btnEditar.ToolTipText = "\r\n";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Image = Properties.Resources.excluir;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(7);
            btnExcluir.Size = new Size(42, 42);
            btnExcluir.ToolTipText = "\r\n";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 45);
            // 
            // btnDevolucao
            // 
            btnDevolucao.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDevolucao.Image = Properties.Resources.retorno_do_vizitante__1_;
            btnDevolucao.ImageScaling = ToolStripItemImageScaling.None;
            btnDevolucao.ImageTransparentColor = Color.Magenta;
            btnDevolucao.Name = "btnDevolucao";
            btnDevolucao.Padding = new Padding(7);
            btnDevolucao.Size = new Size(42, 42);
            btnDevolucao.ToolTipText = "\r\n";
            btnDevolucao.Click += btnDevolucao_Click;
            // 
            // btnPrecos
            // 
            btnPrecos.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrecos.Image = Properties.Resources.posto_de_gasolina__1_;
            btnPrecos.ImageScaling = ToolStripItemImageScaling.None;
            btnPrecos.ImageTransparentColor = Color.Magenta;
            btnPrecos.Name = "btnPrecos";
            btnPrecos.Padding = new Padding(7);
            btnPrecos.Size = new Size(42, 42);
            btnPrecos.Click += btnPrecos_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFiltrar.Image = Properties.Resources.filtro__1_;
            btnFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Padding = new Padding(7);
            btnFiltrar.Size = new Size(42, 42);
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnPdf
            // 
            btnPdf.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPdf.Image = Properties.Resources.pdf__1_;
            btnPdf.ImageScaling = ToolStripItemImageScaling.None;
            btnPdf.ImageTransparentColor = Color.Magenta;
            btnPdf.Name = "btnPdf";
            btnPdf.Padding = new Padding(7);
            btnPdf.Size = new Size(42, 42);
            btnPdf.Click += btnPdf_Click;
            // 
            // btnEmail
            // 
            btnEmail.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEmail.Image = Properties.Resources.o_email__1_;
            btnEmail.ImageScaling = ToolStripItemImageScaling.None;
            btnEmail.ImageTransparentColor = Color.Magenta;
            btnEmail.Name = "btnEmail";
            btnEmail.Padding = new Padding(7);
            btnEmail.Size = new Size(42, 42);
            btnEmail.Click += btnEmail_Click;
            // 
            // lblTipoCadastro
            // 
            lblTipoCadastro.Name = "lblTipoCadastro";
            lblTipoCadastro.Size = new Size(77, 42);
            lblTipoCadastro.Text = "TipoCadastro";
            // 
            // toolBox
            // 
            toolBox.Enabled = false;
            toolBox.Items.AddRange(new ToolStripItem[] { btnAdicionar, btnEditar, btnExcluir, toolStripSeparator1, btnDevolucao, btnPrecos, btnFiltrar, btnPdf, btnEmail, lblTipoCadastro });
            toolBox.Location = new Point(0, 24);
            toolBox.Name = "toolBox";
            toolBox.Size = new Size(567, 45);
            toolBox.TabIndex = 1;
            toolBox.Text = "toolStrip1";
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 349);
            Controls.Add(statusStrip1);
            Controls.Add(panelRegistros);
            Controls.Add(toolBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            Text = "Locadora De Automóveis";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolBox.ResumeLayout(false);
            toolBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private Panel panelRegistros;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelRodape;
        private ToolStripMenuItem aluguelToolStripMenuItem;
        private ToolStripMenuItem automóvelToolStripMenuItem;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem funcionárioToolStripMenuItem;
        private ToolStripMenuItem taxasEServiçosToolStripMenuItem1;
        private ToolStripMenuItem cupomToolStripMenuItem1;
        private ToolStripMenuItem parceiroToolStripMenuItem1;
        private ToolStripMenuItem grupoDeAutomóveisToolStripMenuItem1;
        private ToolStripMenuItem condutorToolStripMenuItem1;
        private ToolStripMenuItem pToolStripMenuItem;
        private ToolStripMenuItem aluguelToolStripMenuItem1;
        private ToolStripMenuItem automóvelToolStripMenuItem1;
        private ToolStripMenuItem clienteToolStripMenuItem1;
        private ToolStripButton btnAdicionar;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDevolucao;
        private ToolStripButton btnPrecos;
        private ToolStripButton btnFiltrar;
        private ToolStripButton btnPdf;
        private ToolStripButton btnEmail;
        private ToolStripLabel lblTipoCadastro;
        private ToolStrip toolBox;
    }
}