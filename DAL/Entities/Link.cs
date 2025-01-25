namespace DAL.Entities;

public class Link
{
    public int Id { get; set; }
    public string InitialUrl { get; set; }
    public string ProccessedUrl { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
