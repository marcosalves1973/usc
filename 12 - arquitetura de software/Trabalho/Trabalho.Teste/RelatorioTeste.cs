using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trabalho.Helpers;
using Trabalho.Negocios.Interface;
using Trabalho.Negocios.BO;

namespace Trabalho.Teste
{
    [TestClass]
    public class RelatorioTeste
    {
        [TestMethod]
        public void testeParcial()
        {
            Retorno retorno = new Retorno();
            IRelatorioBO relatorioBO = new RelatorioBO();
            DateTime thisDay = DateTime.Now;

            retorno = relatorioBO.getVotacaoParcialByData(thisDay);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }

        [TestMethod]
        public void getGanhadoresSemanaAnterior()
        {
            Retorno retorno = new Retorno();
            IRelatorioBO relatorioBO = new RelatorioBO();

            retorno = relatorioBO.getGanhadoresSemanaAnterior();

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }

        [TestMethod]
        public void getGanhadoresMaisVotados()
        {
            Retorno retorno = new Retorno();
            IRelatorioBO relatorioBO = new RelatorioBO();

            retorno = relatorioBO.getGanhadoresMaisVotados();

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }
    }
}
