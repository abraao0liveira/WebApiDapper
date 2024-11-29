namespace WebApiDapper.DTO
{
  public class UserUpdateDTO
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public bool Situation { get; set; }
  }
}