using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.Dados.Interface
{
    public interface IRestauranteDAO
    {
        long salvar(RESTAURANTE restaurante);

        void atualizar(RESTAURANTE restaurante);

        RESTAURANTE consultar(long id);

        List<RESTAURANTE> listar();

        List<RESTAURANTE> listarPorGanhores(List<long> ganhadores);
    }
}
