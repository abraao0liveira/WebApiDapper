using AutoMapper;
using Dapper;
using MySqlConnector;
using WebApiDapper.DTO;
using WebApiDapper.Models;

namespace WebApiDapper.Services
{
  public class UserService : IUser
  {
    //injeção de dependência
    private readonly IConfiguration _configuration; //propriedade privada do tipo IConfiguration
    private readonly IMapper _mapper;
    public UserService(IConfiguration configuration, IMapper mapper) //construtor
    {
      _configuration = configuration; //atribuição
      _mapper = mapper;
    }

    public async Task<ResponseModel<UserListDTO>> ListUserId(int userId)
    {
      ResponseModel<UserListDTO> response = new ResponseModel<UserListDTO>();

      using (var connection = new MySqlConnection(_configuration.GetConnectionString("Default")))
      {
        var sql = await connection.QueryFirstOrDefaultAsync<User>($"SELECT * FROM Users WHERE Id = {userId}");

        if (sql == null)
        {
          response.Message = "Usuário não encontrado";
          response.Status = false;
          return response;
        }

        var userMapped = _mapper.Map<UserListDTO>(sql);
        response.Data = userMapped;
        response.Message = "Usuário encontrado";
      }
      return response;
    }

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

    public async Task<ResponseModel<List<UserListDTO>>> CreateUser(UserCreateDTO userCreateDTO)
    {
      ResponseModel<List<UserListDTO>> response = new ResponseModel<List<UserListDTO>>();

      using (var connection = new MySqlConnection(_configuration.GetConnectionString("Default")))
      {
        var sql = await connection.ExecuteAsync("INSERT INTO Users (Name, Email, Situation, Password) VALUES (@Name, @Email, @Situation, @Password)", userCreateDTO);

        if (sql == 0)
        {
          response.Message = "Erro ao criar usuário";
          response.Status = false;
          return response;
        }

        var users = await ListUsers(connection);
        var usersMapped = _mapper.Map<List<UserListDTO>>(users);
        response.Data = usersMapped;
        response.Message = "Usuário criado com sucesso";
      }
      return response;
    }

    public async Task<ResponseModel<List<UserListDTO>>> UpdateUser(UserUpdateDTO userUpdateDTO)
    {
      ResponseModel<List<UserListDTO>> response = new ResponseModel<List<UserListDTO>>();

      using (var connection = new MySqlConnection(_configuration.GetConnectionString("Default")))
      {
        var sql = await connection.ExecuteAsync("UPDATE Users SET Name = @Name, Email = @Email, Situation = @Situation WHERE Id = @Id", userUpdateDTO);

        if (sql == 0)
        {
          response.Message = "Erro ao atualizar usuário";
          response.Status = false;
          return response;
        }

        var users = await ListUsers(connection);
        var usersMapped = _mapper.Map<List<UserListDTO>>(users);
        response.Data = usersMapped;
        response.Message = "Usuário atualizado com sucesso";
      }
      return response;
    }







    private static async Task<IEnumerable<User>> ListUsers(MySqlConnection connection)
    {
      return await connection.QueryAsync<User>("SELECT * FROM Users");
    }
  }
}