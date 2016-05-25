using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Helpers;

namespace Trabalho.Negocios.Interface
{
    public interface IRelatorioBO
    {
        Retorno getVotacaoParcialByData(DateTime dia);

        Retorno getGanhadoresSemanaAnterior();

        Retorno getGanhadoresMaisVotados();
    }
}
