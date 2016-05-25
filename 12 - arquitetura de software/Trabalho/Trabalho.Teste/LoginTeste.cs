using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trabalho.Dados;
using Trabalho.Dados.Dao;
using Trabalho.Dados.Interface;
using Trabalho.Negocios.BO;
using Trabalho.Negocios.Interface;
using Trabalho.Helpers;


namespace Trabalho.Teste
{
    [TestClass]
    public class LoginTeste
    {
        /// <summary>
        /// Teste - realiza o login
        /// </summary>
        [TestMethod]
        public void testeLogin()
        {
            ILoginBO loginBO = new LoginBO();
            LOGIN login = new LOGIN();
            Retorno retorno = new Retorno();

            string senha = "123456";
            string usuario = "adm";

            retorno = loginBO.logar(usuario, senha);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }
        /// <summary>
        /// Teste - salva dados de acesso
        /// </summary>
        [TestMethod]
        public void testeSalvar()
        {
            ILoginBO loginBO = new LoginBO();
            LOGIN login = new LOGIN();
            Retorno retorno = new Retorno();

            login.NOME = "Renato Bueno da Silva";
            login.SENHA = "123456";
            login.USUARIO = "renato";

            retorno = loginBO.salvar(login);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }

        /// <summary>
        /// Teste - Altera dados de acesso
        /// </summary>
        [TestMethod]
        public void testeAlterar()
        {
            ILoginBO loginBO = new LoginBO();
            LOGIN login = new LOGIN();
            Retorno retorno = new Retorno();

            login.ID = 1;
            login.NOME = "Renato Bueno da Silva";
            login.SENHA = "123456";
            login.USUARIO = "renato.bueno";

            retorno = loginBO.salvar(login);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }

        /// <summary>
        /// Teste - consulta dados de acesso
        /// </summary>
        [TestMethod]
        public void testeConsultar()
        {
            ILoginBO loginBO = new LoginBO();
            LOGIN login = new LOGIN();
            Retorno retorno = new Retorno();

            retorno = loginBO.consultar(1);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }

        /// <summary>
        /// Teste - lista dados de acesso
        /// </summary>
        [TestMethod]
        public void testeListar()
        {
            ILoginBO loginBO = new LoginBO();
            LOGIN login = new LOGIN();
            Retorno retorno = new Retorno();

            retorno = loginBO.listar();

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }
    }
}
