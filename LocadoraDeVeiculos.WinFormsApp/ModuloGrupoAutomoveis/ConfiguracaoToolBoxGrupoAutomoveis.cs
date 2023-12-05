using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoAutomoveis
{
    public class ConfiguracaoToolBoxGrupoAutomoveis : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Grupo de Automóveis";

        public override string TooltipInserir => "Inserir novo Grupo de Automóveis";

        public override string TooltipEditar => "Editar um Grupo de Automóveis";

        public override string TooltipExcluir => "Excluir um Grupo de Automóveis";

        public override bool FiltrarHabilitado { get { return false; } }

        public override bool PrecoHabilitado { get { return false; } }

        public override bool DevolucaoHabilitado { get { return false; } }

        public override bool EmailHabilitado { get { return false; } }

        public override bool PdfHabilitado { get { return false; } }
    }
}
