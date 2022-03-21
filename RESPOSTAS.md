1 - O projeto foi construído em Asp Net MVC (Model View Controller). 
Para salvar as configurações de cada integração, foi utilizado um banco de dados SQL Server, com uma tabela representando a entidade Integração. Esta entidade em questão é representada no código dentro da Model. Para conexão com o banco de dados, foi utilizado o EntityFramework.

2 - Cada componente e classe da aplicação foi implementada com a intenção de manter um comportamento único, fazendo com que melhorias a serem feitas no futuro sejam aplicadas de forma mais fácil.

3 - Resolveria problemas de resiliência através dos tratamentos de erro, geração de logs ou em últimos casos, exibição de mensagens ao usuário de qual ação tomar na aplicação caso algo ocorra algum problema.

4 - O projeto foi construído utilizando a arquitetura MVC, que propicia uma escalabilidade muito boa nas melhorias que podem vir a serem implementadas. Além disso, procurei também isolar cada função da aplicação em um método que faça somente aquilo, o que evita a duplicação de código no futuro.

5 - Quanto à rastreabilidade, é resolvida tranquilamente devido a utilizar o Git, que nos permite fazer os commits das alterações, sempre colocando algum identificador da tarefa na mensagem. Isso faz com que no futuro, conseguimos identificar facilmente o motivo de uma determinada alteração/implementação ter sido realizada.

6 - Garanti a qualidade da aplicação escrevendo testes unitários e teste de integração (Para a rotina de e-mail e consumo do link).


Para rodar a aplicação:
- O EntityFramework deve estar instalado
- O componente ASP.NET e desenvolvimento Web deve estar instalado no VisualStudio.
- Abrir o projeto com o VisualStudio
- na Solution Explorer, clicar com o botão direito do mouse sobre a solução e clicar em build.
- Após compilar, basta clicar no IIS Express no topo no Visual Studio, a aplicação irá subir e na primeira vez irá criar o banco de dados automaticamente.
- Agora, já pode ser utilizada.

1 - Ao abrir a aplicação, irá aparecer a Home onde são informados os dados do usuário para realizar a integraçã.
2 - Antes de realizar a integração, é necessário cadastrar as integrações desejadas acessando a página pelo link "Configurar integrações".
3 - Após configuradas as integrações, pode-se retornar à Home para informar os dados do usuário e executar a integração.




