using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.Dados.Interface
{
    public interface IRelatorioDAO
    {
        List<VOTACOES> getVotacaoParcialByData(DateTime dia);

        List<GANHADORES> getGanhadoresByDates(List<DateTime> dias);

        List<MAIS_VOTADOS> getGanhadoresMaisVotados();
    }
}
