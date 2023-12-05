using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloParceiro
{
    internal class ConfiguracaoToolBoxParceiro : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Parceiro";

        public override string TooltipInserir => "Inserir novo Parceiro";

        public override string TooltipEditar => "Editar um Parceiro existente";

        public override string TooltipExcluir => "Excluir um Parceiro existente";

        public override bool FiltrarHabilitado { get { return false; } }

        public override bool PrecoHabilitado { get { return false; } }

        public override bool DevolucaoHabilitado { get { return false; } }

        public override bool EmailHabilitado { get { return false; } }

        public override bool PdfHabilitado { get { return false; } }
    }
}
