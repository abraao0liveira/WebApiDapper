namespace WebApiDapper.Models
{
  public class ResponseModel<T> // Db is a generic type
  {
    public string Message { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    public T? Data { get; set; }
  }
}