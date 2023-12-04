namespace Agrisys.Models; 

public class Farm {
    public int Id { get; set; }
    public string Name { get; set; }

    public Farm(string name) {
        Name = name;
    }
}