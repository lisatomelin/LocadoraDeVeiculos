using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxasServicos
{
    public class ConfiguracaoToolBoxTaxasServicos : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Serviço";

        public override string TooltipInserir => "Inserir Serviço";

        public override string TooltipEditar => "Editar Serviço";

        public override string TooltipExcluir => "Excluir Serviço";

        public override bool FiltrarHabilitado { get { return false; } }

        public override bool PrecoHabilitado { get { return false; } }

        public override bool DevolucaoHabilitado { get { return false; } }

        public override bool EmailHabilitado { get { return false; } }

        public override bool PdfHabilitado { get { return false; } }
    }
}
