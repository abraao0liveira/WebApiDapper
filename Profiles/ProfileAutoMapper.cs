using AutoMapper;
using WebApiDapper.DTO;
using WebApiDapper.Models;

namespace WebApiDapper.Profiles
{
  public class ProfileAutoMapper : Profile
  {
    public ProfileAutoMapper()
    {
      CreateMap<User, UserListDTO>(); //mapeamento de User para UserListDTO
    }
  }
}