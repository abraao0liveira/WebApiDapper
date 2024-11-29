namespace WebApiDapper.DTO
{
  public class UserCreateDTO
  {
    public string? Name { get; set; }
    public string? Email { get; set; }
    public bool Situation { get; set; }
    public string? Password { get; set; }
  }
}