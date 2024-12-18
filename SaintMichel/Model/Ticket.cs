namespace SaintMichel.Model;

public class Ticket
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }

    public string StatusColor => Status.ToLower() switch
    {
        "open" => "Green",
        "closed" => "Red",
        "in progress" => "Orange",
        _ => "Gray",
    };
}