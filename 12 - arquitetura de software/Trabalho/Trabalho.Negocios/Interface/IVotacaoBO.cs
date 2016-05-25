using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados;
using Trabalho.Helpers;

namespace Trabalho.Negocios.Interface
{
    public interface IVotacaoBO
    {
        Retorno listarRestaurante(long usuario_id);

        Retorno votar(VOTACAO votacao);
    }
}
