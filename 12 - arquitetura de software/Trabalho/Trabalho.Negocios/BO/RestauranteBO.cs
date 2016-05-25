using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados;
using Trabalho.Dados.Dao;
using Trabalho.Dados.Interface;
using Trabalho.Helpers;
using Trabalho.Negocios.Interface;

namespace Trabalho.Negocios.BO
{
    public class RestauranteBO : IRestauranteBO
    {
        public Retorno salvar(RESTAURANTE restaurante)
        {
            IRestauranteDAO restauranteDao = new RestauranteDAO();
            Retorno retorno = new Retorno();
            long id = 0;

            try
            {
                id = restaurante.ID;
                retorno.status = true;
                if(string.IsNullOrEmpty(restaurante.NOME))
                {
                    retorno.status = false;
                    retorno.mensagem = "Preencha o nome do restaurante.";
                    return retorno;
                }

                if(restaurante.ID == 0)
                {
                    id = restauranteDao.salvar(restaurante);
                    restaurante = new RESTAURANTE();
                    retorno.objeto = restaurante.ID = id;
                }
                else
                {
                    restauranteDao.atualizar(restaurante);
                }

                retorno.mensagem = "Registro salvo com sucesso.";
                return retorno;
            }
            catch(Exception ex){
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }
        }

        public Retorno consultar(long id)
        {
            IRestauranteDAO restauranteDao = new RestauranteDAO();
            Retorno retorno = new Retorno();

            try
            {
                retorno.status = true;
                if (id == 0)
                {
                    retorno.status = false;
                    retorno.mensagem = "Informe um id para realizar a consulta.";
                }

                retorno.objeto = restauranteDao.consultar(id);
                retorno.mensagem = "Consulta realizada com sucesso.";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }
        }

        public Retorno listar()
        {
            IRestauranteDAO restauranteDao = new RestauranteDAO();
            Retorno retorno = new Retorno();

            try
            {
                retorno.status = true;
                retorno.objeto = restauranteDao.listar();
                retorno.mensagem = "Listagem realizada com sucesso.";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }
        }
    }
}
