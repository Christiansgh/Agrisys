using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agrisys.Models;

public class FarmViewModel {
    public int Id { get; set; }
    public string? Name { get; set; }
}