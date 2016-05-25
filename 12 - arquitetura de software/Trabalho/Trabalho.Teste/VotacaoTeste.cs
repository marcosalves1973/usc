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
    public class VotacaoTeste
    {
        [TestMethod]
        public void listarRestaurante()
        {
            IVotacaoBO votacaoBO = new VotacaoBO();
            Retorno retorno = new Retorno();

            int usuario = 5;

            retorno = votacaoBO.listarRestaurante(usuario);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }

        /// <summary>
        /// Teste - realiza a votacao
        /// </summary>
        [TestMethod]
        public void testeVotar()
        {
            IVotacaoBO votacaoBO = new VotacaoBO();
            VOTACAO votacao = new VOTACAO();
            Retorno retorno = new Retorno();
          
            votacao.LOGIN_ID = 1;
            votacao.RESTAURANTE_ID = 1;
            //votacao.DATA = DateTime.Now;

            retorno = votacaoBO.votar(votacao);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }
    }
}
