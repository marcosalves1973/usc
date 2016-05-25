using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.Dados.Interface
{
    public interface IGanhadorDAO
    {
        List<long> listaRestauranteId(List<DateTime> dias);

        List<GANHADOR> getGanhador(DateTime dias);

        long salvar(GANHADOR ganhador);
    }
}
