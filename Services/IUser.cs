using WebApiDapper.DTO;
using WebApiDapper.Models;

namespace WebApiDapper.Services
{
  public interface IUser
  {
    //retorno; nome do método; parâmetros
    Task<ResponseModel<List<UserListDTO>>> ListUsers();
    Task<ResponseModel<UserListDTO>> ListUserId(int userId);
    Task<ResponseModel<List<UserListDTO>>> CreateUser(UserCreateDTO userCreateDTO);
  }
}