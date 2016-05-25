using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.Dados.Interface
{
    public interface ILoginDAO
    {
        List<LOGIN> logar(string usuario, string senha);

        long salvar(LOGIN login);

        void atualizar(LOGIN login);

        LOGIN consultar(long id);

        List<LOGIN> listar();

        List<LOGIN> testarUsuario(string usuario);
    }
}
