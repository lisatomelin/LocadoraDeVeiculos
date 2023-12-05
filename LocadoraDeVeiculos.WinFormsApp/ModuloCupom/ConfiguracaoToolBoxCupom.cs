using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCupom
{
    public class ConfiguracaoToolBoxCupom : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Cupom";

        public override string TooltipInserir => "Inserir Cupom";

        public override string TooltipEditar => "Editar Cupom";

        public override string TooltipExcluir => "Excluir Cupom";

        public override bool FiltrarHabilitado { get { return false; } }

        public override bool PrecoHabilitado { get { return false; } }

        public override bool DevolucaoHabilitado { get { return false; } }

        public override bool EmailHabilitado { get { return false; } }

        public override bool PdfHabilitado { get { return false; } }
    }
}
