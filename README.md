# Lista de tarefas

## Descrição
Este projeto é uma aplicação web construída com Angular para o frontend, C# como linguagem de programação para a API, utilizando o Entity Framework (EF) para interagir com um banco de dados PostgreSQL. A aplicação permite que os usuários realizem operações CRUD (Create, Read, Update, Delete) e visualizem suas tarefas diárias.

## Pré-requisitos
- Node.js e npm instalados
- Angular CLI instalado
- Visual Studio ou Visual Studio Code (ou outra IDE para desenvolvimento .NET)
- PostgreSQL instalado e configurado
- Utilização de migration para a criação do database

## Instalação
1. Clone este repositório em sua máquina local.
2. Navegue até o diretório da API.
3. Abra a solução no Visual Studio e restaure os pacotes NuGet, se necessário.
4. Abra o arquivo `appsettings.json` e configure a conexão com o banco de dados PostgreSQL.
5. Execute as migrações do EF para criar o banco de dados:
6. Inicie a API.
7. Navegue até o diretório do frontend:
8. nstale as dependências do Angular:
9. Inicie o servidor de desenvolvimento do Angular:


## Uso
1. Abra seu navegador e acesse `http://localhost:4200`.
2. Você será realocado para a home onde ira aparecer a lista de tarefas que voce tem registrada para o dia de em questão
3. Clique em `Gerenciar Tarefas` para ir para as funcionalidades CRUD
4. Navegue pelas diferentes seções da aplicação para visualizar, criar, atualizar ou excluir tarefas.
5. Explore as funcionalidades CRUD disponíveis.

   # Melhorias Futuras

Além das funcionalidades existentes, algumas melhorias podem ser implementadas para aprimorar ainda mais a aplicação:

- **Envio por Email:** Adicionar a capacidade de enviar tarefas por e-mail, facilitando a comunicação entre os usuários e permitindo que recebam notificações sobre suas tarefas.
  
- **Filtrar por Data:** Implementar a capacidade de filtrar as tarefas com base em datas específicas, permitindo que os usuários visualizem suas tarefas passadas, presentes e futuras de forma mais organizada.
  
- **Adicionar Colaboradores às Tarefas:** Permitir que os usuários adicionem colaboradores às suas tarefas, facilitando a atribuição e o acompanhamento de responsabilidades compartilhadas.

Essas melhorias podem tornar a aplicação mais completa e útil para os usuários, aumentando sua eficiência e usabilidade.


## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir problemas ou enviar solicitações de pull.


## Licença
Este projeto é licenciado sob a [Licença MIT](https://opensource.org/licenses/MIT).





