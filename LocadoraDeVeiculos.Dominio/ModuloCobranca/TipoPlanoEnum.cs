using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCobranca
{
    public enum TipoPlanoEnum
    {
        [Description(" ")]
        Nenhum,

        [Description("Plano Diário")]
        PlanoDiario,

        [Description("Plano Controlador")]
        PlanoControlador,

        [Description("Plano Livre")]
        PlanoLivre
    }
}
