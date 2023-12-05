using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario
{
    public class ConfiguracaoToolBoxFuncionario : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Funcionario";

        public override string TooltipInserir => "Inserir Funcionario";

        public override string TooltipEditar => "Editar Funcionario";

        public override string TooltipExcluir => "Excluir Funcionario";

        public override bool FiltrarHabilitado { get { return false; } }

        public override bool PrecoHabilitado { get { return false; } }

        public override bool DevolucaoHabilitado { get { return false; } }

        public override bool EmailHabilitado { get { return false; } }

        public override bool PdfHabilitado { get { return false; } }
    }
}
