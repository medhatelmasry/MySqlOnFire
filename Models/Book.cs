

namespace MySqlOnFire.Models;

public class Book {
    public string? ISBN { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Language { get; set; }
    public int Pages { get; set; }

    public int PublisherId { get; set; }

    [ForeignKey("PublisherId")]
    public virtual Publisher? Publisher { get; set; }

    public override string ToString() {
        var txt = new StringBuilder();
        txt.AppendLine($"ISBN: {ISBN}");
        txt.AppendLine($"Title: {Title}");
        txt.AppendLine($"Author: {Author}");
        txt.AppendLine($"Language: {Language}");
        txt.AppendLine($"Pages: {Pages}");
        txt.AppendLine($"Publisher: {Publisher!.Name}");

        return txt.ToString();
    }
}
