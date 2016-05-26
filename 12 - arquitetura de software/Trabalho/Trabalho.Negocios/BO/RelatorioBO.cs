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
    public class RelatorioBO : IRelatorioBO
    {
        public Retorno getVotacaoParcialByData(DateTime dia)
        {
            Retorno retorno = new Retorno();
            IRelatorioDAO relatorioDAO = new RelatorioDAO();

            retorno.status = true;
            try
            {
                List<VOTACOES> resultado = relatorioDAO.getVotacaoParcialByData(dia);
                retorno.objeto = resultado;
                if( resultado.Count() > 0 ){
                    retorno.mensagem = "Listagem realizado com sucesso.";                   
                }
                else
                {
                    retorno.mensagem = "Nenhum restaurante votado hoje.";
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }

            return retorno;
        }

        public Retorno getGanhadoresSemanaAnterior()
        {
            Retorno retorno = new Retorno();
            IRelatorioDAO relatorioDAO = new RelatorioDAO();
            DataVotacao dataVotacao = new DataVotacao();

            retorno.status = true;
            try
            {
                List<DateTime> dias = dataVotacao.retornaDataSemanaPassada();
                List<GANHADORES> resultado = relatorioDAO.getGanhadoresByDates(dias);
                retorno.objeto = resultado;
                if (resultado.Count() > 0)
                {
                    retorno.mensagem = "Listagem realizado com sucesso.";
                }
                else
                {
                    retorno.mensagem = "Nenhum restaurante ganhou semana passada.";
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }
        }

        public Retorno getGanhadoresMaisVotados()
        {
            Retorno retorno = new Retorno();
            IRelatorioDAO relatorioDAO = new RelatorioDAO();

            retorno.status = true;
            try
            {
                List<MAIS_VOTADOS> resultado = relatorioDAO.getGanhadoresMaisVotados();
                retorno.objeto = resultado;
                if (resultado.Count() > 0)
                {
                    retorno.mensagem = "Listagem realizado com sucesso.";
                }
                else
                {
                    retorno.mensagem = "Nenhum restaurante ganhou.";
                }

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
