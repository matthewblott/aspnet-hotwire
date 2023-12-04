namespace aspnet_hotwire.Data;

public class Note {
  public int Id { get; set; }
  public string Name { get; set; }
}
  
public class Notes : List<Note> {
  private Notes() { }
  private static Notes _Instance = null;
  public static Notes Instance {
    get {
      if(_Instance == null) {
        _Instance = new Notes();
  
        for(var i = 0; i < 2; i++) {
          _Instance.Add(new Note { Id = i + 1, Name = $"Note {i + 1}" });
        }
      }
      return _Instance;
    }
  }
}
