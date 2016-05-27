# USC - arquitetura de software
Repositório do trabalho do Enedy

####Subindo o dump

  - Execute primeiramente o "CREATE DATABASE"
  - Depois execute o "USE"
  - Depois execute todos os "CREATE TABLE" (Pode executar todos juntos)
  - Depois execute todos os "CREATE VIEW" (Execute um por um, sim, o SQL é chato xD)
  - Depois execute todos os "INSERTS" (Pode executar todos juntos)

####Configurando o projeto
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

**Não use o Internet Explorer, usei o Google Chrome para testar o projeto, não garanto que funcione em outros navegadores**

####Configurando o Google Chrome
Para não ter o problema de carregamento "Cross Domain" por carregar arquivos por ajax, realize a seguinte configuração:

  - Clique com o botão direito do mouse no icone do Google Chrome
  - Clique com o botão direito do mouse no Google Chrome do menu que abrir
  - Clique em Propriedades
  - No campo "Destino", coloque no final: " --allow-file-access-from-files"
  - Clique em aplicar e fechar
  - Reinicie o Google Chrome

  
####Executando o projeto
#####Cconfirme a Url do WebService
Primeiramente confirme se o endereço gerado para o WebService é "localhost:61748", para verificar basta ir no projeto no Visual Studio e clicar com o botão direito en: "Servico->Trabalho", abrir as propriedades e abrir a aba "Web". NO campo "Project Url" estará a url executada pelo navegador para abrir o projeto. Ou de uma maneira mais simples, execute o projeto e ao abrir o navegador veja qual url o browser está executando.

#####Se a url não for "localhost:61748
Abra o arquivo "cliente->js->all.js" e altere a url na primeira linha do projeto.

#####Executando (finalmente \o/)
Abra o arquivo "cliente->index.html" no navegador. (Como informado a cima, projeto testado apenas no Google Chrome realizando a configuração de cross-domain)
  - Pode logar com o usuário "adm" e senha "123456".
  - Ao logar abrirá a tela de votação seguinto as especificações:
    * Antes das 11:30
      * votação estará aberta, ou seja, mostrará a listagem de restaurantes e o botão "votar" na direita
      * Se já tiver realizado a votação, o usuário receberá uma mensagem informando que o mesmo já votou e deverá aguardar o fim da votação.
    * Apartir das 11:30 até as 23:59
      * Se ao menos um restaurante tiver sido votado no dia, mostrará o restaurante ganhador
      * Se não tiver sido votado nenhum restaurante, mostrará uma mensagem informando que não houve votação naquele determinado dia.

######Menu Usuário
  - Lista com todos os usuários do sistema.
  - Pode-se cadastrar um novo
    * Se o usuário digitado já estiver sendo utilizado, o sistema não permite que crie um usuário duplicado
  - Edição de usuário
  
######Menu Restaurante
  - Lista com todos os restaurantes do sistema.
  - Pode-se cadastrar um novo restaurante
  - Edição de restaurantes existentes

######Menu Relatório
  - Ranking Parcial
    * Mostra quem já votou e em qual restaurante
  - Restaurantes da semana passada
    * Abre o relatório dos restaurantes ganhadores da semana passada
  - Restaurantes mais votados
    * Lista os 10 restaurantes que mais ganharam a votação e a quantidade de vezes que ganhou


####Web service
Login
  - POST api/login/logar
    * Serviço responsável por realizar o login
  - GET api/login/consultar/{id}
    * Serviço responsável por consultar o usuário através do id
  - GET api/login/listar
    * Serviço responsável por listar os usuários
  - POST api/login/salvar
    * Serviço responsável por salvar os dados do usuário
  - PUT api/login/alterar
    * Serviço responsável por alterar os dados do usuário
    
Restaurante
  - GET api/restaurante/consultar/{id}
    * Serviço responsável por consultar o restaurante através do id
  - GET api/restaurante/listar
    * Serviço responsável por listar todos os restaurante
  - POST api/restaurante/salvar
    * Serviço responsável por salvar os dados do restaurante
  - PUT api/restaurante/alterar
    * Serviço responsável por alterar os dados do restaurante

Relatorio
  - GET api/relatorio/pacial
    * Serviço responsável por consultar o relatorio parcial do dia
  - GET api/relatorio/semanaPassada
    * Serviço responsável por consultar o relatorio dos restaurantes ganhadores da semana passada
  - GET api/relatorio/maisVotado
    * Serviço responsável por consultar o relatorio dos 10 restaurantes que mais ganhou a votação

Votacao
  - GET api/votacao/listar/restaurantes/{usuario_id}
    * Serviço responsável por listar os restaurante com a regra necessaria para a votacao
  - POST api/votacao/votar
    * Serviço responsável por salvar os dados da votacao
