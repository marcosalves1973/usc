using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Helpers;

namespace Trabalho.Dados.Interface
{
    public interface IVotacaoDAO
    {
        long getRestauranteGanhador(DateTime dias);

        long salvar(VOTACAO votacao);

        List<VOTACAO> getVotacaoPorUsuarioDia(long login_id, DateTime dia);
        
    }
}
