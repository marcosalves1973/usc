# usc - arquitetura de software
Repositório do trabalho do Enedy

##Subindo o dump

  - Execute primeiramente o "CREATE DATABASE"
  - Depois execute o "USE"
  - Depois execute todos os "CREATE TABLE" (Pode executar todos juntos)
  - Depois execute todos os "CREATE VIEW" (Execute um por um, sim, o SQL é chato xD)
  - Depois execute todos os "INSERTS" (Pode executar todos juntos)

##Configurando o projeto
  - Abra o projeto no Visual Studio 2013
  - Abra o Arquivo: Dados -> Trabalho.Dados -> App.Config, linha 8
    * Encontre o "data source=" e coloque o host da sua máquina
    * Encontre o "user id" e coloque o usuário do seu Sql Server
    * Encontre o "password" e coloque a senha do seu Sql Server
  - Abra o Arquivo: Servico -> Trabalho -> Web.config, linha 12
    * Encontre o "data source=" e coloque o host da sua máquina
    * Encontre o "user id" e coloque o usuário do seu Sql Server
    * Encontre o "password" e coloque a senha do seu Sql Server
  - Abra o Arquivo: Teste -> Trabalho.Teste -> App.config, linha 4
    * Encontre o "data source=" e coloque o host da sua máquina
    * Encontre o "user id" e coloque o usuário do seu Sql Server
    * Encontre o "password" e coloque a senha do seu Sql Server

**Não use o Internet Explorer, use o Google Chrome ou o Safari para testar o projeto**

##Configurando o Google Chrome
Para não ter o problema de carregamento "Cross Domain" por carregar arquivos por ajax, realize a seguinte configuração:

  - Clique com o botão direito do mouse no icone do Google Chrome
  - Clique com o botão direito do mouse no Google Chrome do menu que abrir
  - Clique em Propriedades
  - No campo "Destino", coloque no final: " --allow-file-access-from-files"
  - Clique em aplicar e fechar
  - Reinicie o Google Chrome
