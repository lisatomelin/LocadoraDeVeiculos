namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface IContextoPersistencia
    {
        public void DesfazerAlteracoes();

        public void GravarDados();
    }
}
