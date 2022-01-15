namespace MySqlOnFire.Models;

public class Publisher {
    public int PublisherId { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Book>? Books { get; set; }

    public override string ToString() {
        var txt = new StringBuilder();
        txt.AppendLine($"ID: {PublisherId}");
        txt.AppendLine($"Publisher: {Name}");
        
        return txt.ToString();
    }
}
