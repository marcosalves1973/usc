using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados;
using Trabalho.Dados.Interface;
using Trabalho.Dados.Dao;
using Trabalho.Helpers;
using Trabalho.Negocios.Interface;


namespace Trabalho.Negocios.BO
{
    public class LoginBO : ILoginBO
    {
        public Retorno logar(string usuario, string senha)
        {
            ILoginDAO loginDAO = new LoginDAO();
            Retorno retorno = new Retorno();

            try
            {
                retorno.status = true;

                if (string.IsNullOrEmpty(usuario))
                {
                    retorno.status = false;
                    retorno.mensagem = "Preencha o usuário.";
                    return retorno;
                }

                if (string.IsNullOrEmpty(senha))
                {
                    retorno.status = false;
                    retorno.mensagem = "Preencha a senha.";
                    return retorno;
                }

                senha = Criptografia.criptografar(senha);

                List<LOGIN> usuarios = loginDAO.logar(usuario, senha);

                if (usuarios.Count() == 0)
                {
                    retorno.status = false;
                    retorno.mensagem = "Usuário ou senha inválido.";
                    return retorno;
                }
                else if (usuarios.Count() > 1)
                {
                    retorno.status = false;
                    retorno.mensagem = "Ocorreu um erro no login, por gentileza informe o administrador.";
                    return retorno;
                }

                String token = usuarios[0].USUARIO + usuarios[0].SENHA; 
                token = Criptografia.criptografar(token);
                usuarios[0].TOKEN = token.ToUpper();
                loginDAO.atualizar(usuarios[0]);

                retorno.objeto = usuarios[0];
                retorno.mensagem = "Consulta realizada com sucesso";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }
        }

        public Retorno salvar(LOGIN login)
        {
            ILoginDAO loginDAO = new LoginDAO();
            Retorno retorno = new Retorno();
            long id = 0;

            try
            {
                id = login.ID;
                retorno.status = true;

                if(string.IsNullOrEmpty(login.NOME))
                {
                    retorno.status = false;
                    retorno.mensagem = "Preencha o nome do usuário.";
                    return retorno;
                }

                if (string.IsNullOrEmpty(login.USUARIO))
                {
                    retorno.status = false;
                    retorno.mensagem = "Preencha o usuário.";
                    return retorno;
                }

                if (string.IsNullOrEmpty(login.SENHA))
                {
                    retorno.status = false;
                    retorno.mensagem = "Preencha a senha.";
                    return retorno;
                }

                //testa se a senha eh a mesma
                if (login.ID == 0)
                {
                    login.SENHA = Criptografia.criptografar(login.SENHA);
                }
                else
                {
                    LOGIN thisLogin = loginDAO.consultar(login.ID);

                    if (thisLogin.SENHA != login.SENHA)
                    {
                        login.SENHA = Criptografia.criptografar(login.SENHA);
                    }
                }


                List<LOGIN> testeUsuario = loginDAO.testarUsuario(login.USUARIO);

                if (login.ID == 0)
                {
                    if (testeUsuario.Count() > 0)
                    {
                        retorno.status = false;
                        retorno.mensagem = "Usuário já existe.";
                        return retorno;
                    }

                    id = loginDAO.salvar(login);
                    login = new LOGIN();
                    retorno.objeto = login.ID = id;
                }
                else
                {
                    if (testeUsuario.Count() > 1)
                    {
                        retorno.status = false;
                        retorno.mensagem = "Usuário já existe.";
                        return retorno;
                    }

                    loginDAO.atualizar(login);
                }

                retorno.mensagem = "Registro salvo com sucesso.";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }

        }

        public Retorno consultar(long id)
        {
            ILoginDAO loginDAO = new LoginDAO();
            Retorno retorno = new Retorno();

            try
            {
                retorno.status = true;

                if(id == 0){
                    retorno.status = false;
                    retorno.mensagem = "Informe um id para realizar a consulta.";
                }

                retorno.objeto = loginDAO.consultar(id);
                retorno.mensagem = "Consulta realizada com sucesso";
                return retorno;
            }
            catch(Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }
        }

        public Retorno listar()
        {
            ILoginDAO loginDAO = new LoginDAO();
            Retorno retorno = new Retorno();

            try
            {
                retorno.status = true;
                retorno.objeto = loginDAO.listar();
                retorno.mensagem = "Listagem realizada com sucesso";
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
