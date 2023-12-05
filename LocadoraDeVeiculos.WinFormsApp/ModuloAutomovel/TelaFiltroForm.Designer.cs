namespace LocadoraDeVeiculos.WinFormsApp.ModuloAutomovel
{
    partial class TelaFiltroForm
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
            txtListaGrupoAutomoveis = new ComboBox();
            label1 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtListaGrupoAutomoveis
            // 
            txtListaGrupoAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
            txtListaGrupoAutomoveis.FormattingEnabled = true;
            txtListaGrupoAutomoveis.Location = new Point(12, 39);
            txtListaGrupoAutomoveis.Name = "txtListaGrupoAutomoveis";
            txtListaGrupoAutomoveis.Size = new Size(255, 23);
            txtListaGrupoAutomoveis.TabIndex = 43;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(184, 15);
            label1.TabIndex = 40;
            label1.Text = "Selecione o Grupo de Automóvel:";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(110, 73);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(76, 34);
            btnGravar.TabIndex = 45;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(192, 73);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 34);
            btnCancelar.TabIndex = 44;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 119);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(txtListaGrupoAutomoveis);
            Controls.Add(label1);
            Name = "TelaFiltroForm";
            Text = "Filtrar Grupo de Automoveis";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox txtListaGrupoAutomoveis;
        private Label label1;
        private Button btnGravar;
        private Button btnCancelar;
    }
}