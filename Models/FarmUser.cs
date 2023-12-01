namespace Agrisys.Models; 

public class FarmUser {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int FarmId { get; set; }
    public Farm Farm { get; set; }
}