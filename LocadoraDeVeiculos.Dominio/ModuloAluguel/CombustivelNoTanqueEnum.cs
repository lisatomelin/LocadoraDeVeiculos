using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public enum CombustivelNoTanqueEnum
    {
        [Description("Vazio")]
        Vazio = 0,

        [Description("1/4")]
        UmQuarto = 25,

        [Description("1/2")]
        Meio = 50,

        [Description("3/4")]
        TresQuartos = 75,

        [Description("Cheio")]
        Cheio = 100
    }
}

