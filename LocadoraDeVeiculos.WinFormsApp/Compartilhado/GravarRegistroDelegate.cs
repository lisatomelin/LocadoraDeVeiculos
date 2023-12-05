using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado
{
    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade disciplina)
         where TEntidade : EntidadeBase<TEntidade>;
}
