namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado
{
    public abstract class ConfiguracaoToolBoxBase
    {
        #region tooltips dos botões

        public abstract string TipoCadastro { get; }

        public abstract string TooltipInserir { get; }

        public abstract string TooltipEditar { get; }

        public abstract string TooltipExcluir { get; }

        public virtual string TooltipPrecos { get; }

        public virtual string TooltipFiltrar { get; }

        public virtual string TooltipDevolucao { get; }

        public virtual string TooltipPdf { get; }

        public virtual string TooltipEmail { get; }

        #endregion

        #region estados dos botões
        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool PrecoHabilitado { get { return false; } }

        public virtual bool FiltrarHabilitado { get { return false; } }

        public virtual bool DevolucaoHabilitado { get { return false; } }

        public virtual bool PdfHabilitado { get { return false; } }

        public virtual bool EmailHabilitado { get { return false; } }

        #endregion
    }
}
