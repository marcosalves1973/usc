using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados.Interface;

namespace Trabalho.Dados.Dao
{
    public class LoginDAO : ILoginDAO
    {
        /// <summary>
        /// Responsável por realizar a consulta do login
        /// </summary>
        /// <param name="usuario"> usuario desejado </param>
        /// /// <param name="senha"> senha do usuario </param>
        /// <returns></returns>
        public List<LOGIN> logar(string usuario, string senha)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from login in ctxTrabalho.LOGIN
                                  where
                                  login.USUARIO == usuario
                                  && login.SENHA == senha
                                  select login).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Responsável por testar se o usuario já existe no banco
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<LOGIN> testarUsuario(string usuario)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from login in ctxTrabalho.LOGIN
                                  where
                                  login.USUARIO == usuario
                                  select login).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Resposável por salvar os dados do usuário
        /// </summary>
        /// <param name="login"> objeto login </param>
        /// <returns> long </returns>
        public long salvar(LOGIN login)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    ctxTrabalho.LOGIN.Add(login);
                    ctxTrabalho.SaveChanges();
                    return login.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Responsável por atualizar os dados do usuário
        /// </summary>
        /// <param name="login"> objeto login </param>
        public void atualizar(LOGIN login)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    ctxTrabalho.LOGIN.Attach(login);
                    ctxTrabalho.Entry(login).State = EntityState.Modified;
                    ctxTrabalho.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Responsável por retornar os dados de um usuário
        /// </summary>
        /// <param name="id"> id do login </param>
        /// <returns> objeto login </returns>
        public LOGIN consultar(long id)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    //var result = ctxTrabalho.LOGIN.Where(l => l.ID == id).FirstOrDefault();

                    var result = (from login in ctxTrabalho.LOGIN
                                  where
                                  login.ID == id
                                  select login).FirstOrDefault();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Responsável por retornar todos os dados de todos os usuário
        /// </summary>
        /// <returns> objeto login </returns>
        public List<LOGIN> listar()
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from login in ctxTrabalho.LOGIN
                                  select login).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
