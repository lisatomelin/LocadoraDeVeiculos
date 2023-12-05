﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;

namespace LocadoraDeVeiculos.Aplicacao.ModuloTaxasServicos
{
    public class ServicoTaxasServicos
    {
        private IRepositorioTaxasServicos repositorioTaxasServicos;
        private IValidadorTaxasServicos validadorTaxasServicos;
        private readonly IContextoPersistencia contextoPersistencia;

        public ServicoTaxasServicos(IRepositorioTaxasServicos repositorioTaxasServicos, IValidadorTaxasServicos validadorTaxasServicos, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioTaxasServicos = repositorioTaxasServicos;
            this.validadorTaxasServicos = validadorTaxasServicos;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(TaxasServicos taxasServicos)
        {
            Log.Debug("Tentando inserir serviço...{@d}", taxasServicos);

            List<string> erros = ValidarTaxasServicos(taxasServicos);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioTaxasServicos.Inserir(taxasServicos);

                contextoPersistencia.GravarDados();

                Log.Debug("Serviço {TaxasServicosId} inserida com sucesso", taxasServicos.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir serviço.";

                Log.Error(exc, msgErro + "{@d}", taxasServicos);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(TaxasServicos taxasServicos)
        {
            Log.Debug("Tentando editar serviço...{@d}", taxasServicos);

            List<string> erros = ValidarTaxasServicos(taxasServicos);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioTaxasServicos.Editar(taxasServicos);

                contextoPersistencia.GravarDados();

                Log.Debug("Serviço {TaxasServicosId} editado com sucesso", taxasServicos.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar serviço.";

                Log.Error(exc, msgErro + "{@d}", taxasServicos);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(TaxasServicos taxasServicos)
        {
            Log.Debug("Tentando excluir serviço...{@d}", taxasServicos);

            try
            {
                bool taxasServicosExiste = repositorioTaxasServicos.Existe(taxasServicos);

                if (taxasServicosExiste == false)
                {
                    Log.Warning("Serviço {TaxasServicosId} não encontrado para excluir", taxasServicos.Id);

                    return Result.Fail("Serviço não encontrada");
                }

                repositorioTaxasServicos.Excluir(taxasServicos);

                contextoPersistencia.GravarDados();

                Log.Debug("Serviço {TaxasServicosId} excluído com sucesso", taxasServicos.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBAluguel_TBTaxasServicos"))
                    msgErro = "Este serviço está relacionado com um aluguel e não pode ser excluído !";
                else
                    msgErro = "Falha ao tentar excluir serviço";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {TaxasServicosId}", taxasServicos.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarTaxasServicos(TaxasServicos taxasServicos)
        {
            var resultadoValidacao = validadorTaxasServicos.Validate(taxasServicos);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(taxasServicos))
                erros.Add($"Este nome '{taxasServicos.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(TaxasServicos taxasServicos)
        {
            TaxasServicos taxasServicosEncontrado = repositorioTaxasServicos.SelecionarPorNome(taxasServicos.Nome);

            if (taxasServicosEncontrado != null &&
                taxasServicosEncontrado.Id != taxasServicos.Id &&
                taxasServicosEncontrado.Nome == taxasServicos.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
