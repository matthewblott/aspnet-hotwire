namespace aspnet_hotwire.Data;

public class Todo
{
  public int Id { get; set; }
  public string Name { get; set; }
}

public class Todos : List<Todo>
{
  private Todos() { }
  private static Todos _Instance = null;
  public static Todos Instance
  {
    get
    {
      if (_Instance == null)
      {
        _Instance = new Todos();

        for (var i = 0; i < 2; i++)
        {
          _Instance.Add(new Todo { Id = i + 1, Name = $"Todo {i + 1}" });
        }
      }
      return _Instance;
    }
  }
}
