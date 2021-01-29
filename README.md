## Requisitos

* [.Net Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core)
* [PostgreSQL](https://www.postgresql.org/download/)
* [Postman](https://www.postman.com/downloads/) ou qualquer software equivalente

## Configurando o projeto

- Com o projeto baixado, alterar a connection string do projeto apontando para o Postgre local, se necessário, incluir usuário e senha

- Com o projeto aberto, gerar o banco de dados e as tabelas via migrations com o comando Update-Database, apontando para o projeto FHT_Bank.Application 

- Opcional: executar o script para popular o banco de dados para facilitar os testes
  

## Testando a aplicação

​	Será disponibilizado uma collection com exemplos de requisições. A mesma poderá ser aberta no Postman, ou em algum software similar.

 1. Para testar o  saldo, a rota /account/{accountNumber}  deverá ser chamada, passando o número da conta

 2. Para testar o saque, a rota /account/withdraw deverá ser chamada, passando a conta e o valor no body. 

 3. Para testar o deposito, a rota /account/deposit deverá ser chamado, passando a conta destino e o valor no body.

    















