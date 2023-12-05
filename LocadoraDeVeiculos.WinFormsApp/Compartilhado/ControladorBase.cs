namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado
{
    public abstract class ControladorBase
    {
        protected string mensagemRodape;

        public abstract void Inserir();

        public abstract void Editar();

        public abstract void Excluir();

        public virtual void Precos()
        {

        }

        public virtual void Filtrar()
        {

        }

        public virtual void Devolucao()
        {

        }

        public virtual void Pdf()
        {

        }

        public virtual void Email()
        {

        }

        public abstract UserControl ObtemListagem();

        public abstract ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox();

        public string ObterMensagemRodape()
        {
            return mensagemRodape;
        }
    }
}
