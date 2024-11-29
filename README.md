# WebApiDapper

## Tecnologias
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MySQL](https://img.shields.io/badge/mysql-4479A1.svg?style=for-the-badge&logo=mysql&logoColor=white)
![Dapper](https://img.shields.io/badge/dapper-%23121011.svg?style=for-the-badge&logo=dapper&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)

## O que é o LibaryBase?
Este projeto é uma Web API desenvolvida com .NET 8, utilizando Dapper para acesso a dados e MySQL como banco de dados. Ele implementa a estrutura básica de CRUD (Create, Read, Update, Delete), permitindo a interação com dados de forma simples e eficiente. O uso do Dapper garante alto desempenho nas operações de banco de dados, enquanto o .NET 8 oferece as últimas melhorias e recursos da plataforma, tornando a API escalável e de fácil manutenção. Ideal para quem busca aprender ou aprimorar suas habilidades no desenvolvimento de APIs com tecnologias modernas.

## Pré-requisitos
- .NET
- MySQL

## Como rodar o Banco de Dados?

1. Abra o MySQL
2. Crie a conexão com o banco de dados
3. Adicione a tabela e os dados de cada coluna

## Como rodar o código?

### [1] Primeiro, rodar os comandos dotnet
```bash
dotnet restore
dotnet build
dotnet clean 
```

### [2] Segundo, intalar package de dependências
```bash
dotnet add package MySql.Data
dotnet add package Dapper
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

### [3] Terceiro, adicionar caminho do Banco de Dados MySQL
- Adicione a rota do seu banco de dados dentro da variável 'connection'
- Crie a conexão
#### Exemplo no método Get ListUsers
```bash
public async Task<ResponseModel<List<UserListDTO>>> ListUsers()
{
  ResponseModel<List<UserListDTO>> response = new ResponseModel<List<UserListDTO>>(); //instância de ResponseModel

  using (var connection = new MySqlConnection(_configuration.GetConnectionString("Default"))) //abre conexão
  {
    var sql = await connection.QueryAsync<User>("SELECT * FROM Users");

    if (sql.Count() == 0)
    {
      response.Message = "Nenhum usuário encontrado";
      response.Status = false;
      return response;
    }

    //mapeamento de User para UserListDTO
    var usersMapped = _mapper.Map<List<UserListDTO>>(sql);
    response.Data = usersMapped;
    response.Message = "Usuários encontrados";
  }
  return response;
}
```

### [4] Quarto, rodar a aplicação
```bash
dotnet run
```
