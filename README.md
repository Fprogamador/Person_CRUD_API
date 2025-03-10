# Person API em .NET

Este é um projeto de API CRUD simples feito em .NET, utilizando o Entity Framework para interagir com um banco de dados SQLite. A API gerencia um conjunto de pessoas, permitindo realizar operações de **Create**, **Read**, **Update** e **Delete**.

## Tecnologias Utilizadas

- **.NET 8**
- **Entity Framework Core**
- **SQLite** como banco de dados
- **Swagger** para documentação da API

## Funcionalidades

- **POST** `/person`: Cria uma nova pessoa.
- **GET** `/person`: Retorna todas as pessoas.
- **PUT** `/person/{id}`: Atualiza o nome de uma pessoa existente.
- **DELETE** `/person/{id}`: Marca uma pessoa como inativa (não a remove do banco de dados).

## Como Rodar o Projeto

### Pré-requisitos

1. **.NET SDK 8.0** ou versão mais recente.
2. **SQLite** (não é necessário instalar, pois é embutido).

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/Fprogamador/Person_CRUD_API.git
   cd Person_CRUD_API
