using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCliente
{
    public class ConfiguracaoToolBoxCliente : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Clientes";

        public override string TooltipInserir => "Inserir Cliente";

        public override string TooltipEditar => "Editar Cliente";

        public override string TooltipExcluir => "Excluir Cliente";

        public override bool FiltrarHabilitado { get { return false; } }

        public override bool PrecoHabilitado { get { return false; } }

        public override bool DevolucaoHabilitado { get { return false; } }

        public override bool EmailHabilitado { get { return false; } }

        public override bool PdfHabilitado { get { return false; } }
    }
}
