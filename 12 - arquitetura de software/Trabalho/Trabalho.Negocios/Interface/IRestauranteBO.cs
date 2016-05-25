using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados;
using Trabalho.Helpers;

namespace Trabalho.Negocios.Interface
{
    public interface IRestauranteBO
    {
        Retorno salvar(RESTAURANTE restaurante);

        Retorno consultar(long id);

        Retorno listar();
    }
}
