# Desafio MYRP ☁

**Proposta**
> Desenvolva uma aplicação de cadastro de usuário que integre de forma flexível e configuravel com vários outros sistemas/serviços
- De alguma forma (por exemplo via uma api ou via interface), receba os dados de cadastro de usuário com as seguintes informações: nome, idade, telefone, e-mail
- Dado o recebimento de cadastro de um usuário, o sistema deve executar as integrações configuradas
- Deve haver uma forma para cadastrar/configurar as integrações (via api, via interface, via arquivo de configuração, etc)
- Cada uma das integrações configuradas deve observar as seguintes condições
  - os dados a serem utilizados na integração devem ser configuráveis (nome, idade, telefone, e-mail)
  - o formato a ser utilizado na integração deve ser configurável (json, csv, xml)
  - deve-se permitir a configuração de uma condição para a execução da integração (por exemplo, executar a integração somente para usuários com mais de 30 anos)
  - a ação da integração deve ser configurável, com as seguintes opções:
    - enviar um email com as seguinte configurações:
	  - com um anexo (pode ser para o próprio usuário ou um novo destinatário configurável)
	  - destinatário (podendo utilizar o próprio email do cadastro ou outro fixo)
	  - título do email
	  - corpo do email, utilizando algum método de template, por exemplo, substituíndo as informações {nome), {idade), {telefone), {e-mail)
	  - anexo (pode ser o json, csv ou xml)
    - consumir um link com as seguintes configurações: url, metodo(get, post), payload (json, csv, xml)

**Teste de mesa**
> Dada a aplicação desenvolvida, deve ser possível realizar várias integrações, como por exemplo as integrações abaixo:
- Ao cadastrar novo usuário, enviar nome e telefone em formato json para o link (https://httpbin.org/post)
- Ao cadastrar novo usuário, enviar um email de Bem vindo para o usuário, somente se usuário for maior de 18 anos
- Ao cadastrar novo usuário, enviar um email para comercial@exemplo.com com todos os dados do usuário

**Avaliação**
> De princípio, não estamos havaliando conhecimento em cima de uma framework/tecnologia, mas sim, em cima da solução apresentada, ou seja, o mais importante é a modelagem de domínio

- De maneira textual, responda as questões abaixo
1. Descreva/Desenhe a arquitetura utilizada na solução.
2. Descreve como a modelagem de domínio foi implementada de uma maneira que deixa a aplicação flexível.
3. Como você resolveu/resolveria problemas de resiliência na aplicação?
4. Como você resolveu/resolveria problemas de escalabilidade na aplicação?
5. Como você resolveu/resolveria problemas de rastreabilidade na aplicação?
6. Como você garantiu a qualidade da sua aplicação?

**Dicas**
- Espera-se que seja escrito em C#
- Lembre-se de alguns conceitos de design/arquitetura
  - DDD
  - Hexagonal
  - Onion
  - Clean
  - CQRS
- Alguns serviços similares que permitem integrações de forma flexível
  - [IFTTT](https://ifttt.com/)
  - [Zapier](https://zapier.com/)
  - [Flow](https://flow.microsoft.com/)
  - [BeeHive](https://github.com/muesli/beehive)

**Entrega**
- O prazo de entrega é dia **06/08 às 23:59**
- As alterações realizadas após este prazo não serão avaliadas
- Commit o seu projeto neste mesmo projeto github
- Crie um arquivo **Respostas.md** com as respostas das questões e os passos para compilar/executar a aplicação
- Qualquer dúvida, entre em contato pelo email: [dev_erp@myrp.com.br](mailto:dev_erp@myrp.com.br)
