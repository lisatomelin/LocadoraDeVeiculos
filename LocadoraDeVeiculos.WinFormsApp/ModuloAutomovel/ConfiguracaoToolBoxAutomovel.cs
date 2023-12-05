using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloAutomovel
{
    public class ConfiguracaoToolBoxAutomovel : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Automóveis";

        public override string TooltipInserir => "Inserindo novo Automóvel";

        public override string TooltipEditar => "Editar um Automóvel";

        public override string TooltipExcluir => "Excluir um Automóvel";

        public override string TooltipFiltrar => "Filtrar por Grupo de Automóvel";

        public override bool FiltrarHabilitado { get { return true; } }

        public override bool PrecoHabilitado { get { return false; } }

        public override bool DevolucaoHabilitado { get { return false; } }

        public override bool EmailHabilitado { get { return false; } }

        public override bool PdfHabilitado { get { return false; } }
    }
}
