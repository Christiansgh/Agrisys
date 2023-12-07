using Agrisys.Models;

namespace Agrisys.Data;

public class EFHomeRepository : IHomeRepository {
    private readonly HomeDbContext _context;

    public EFHomeRepository(HomeDbContext context) {
        _context = context;
    }

    public HomeViewModel GetHomeViewModel() {
       // var query = _context.HomeViewModels?
       //     .OrderByDescending(p => p.HomeViewModelId)
       //     .LastOrDefault();
        
        var test = _context.HomeViewModels.Max(x => x.HomeViewModelId);
        HomeViewModel _test = _context.HomeViewModels.FirstOrDefault(x => x.HomeViewModelId == test);
        Console.WriteLine($"============================================================================");
        Console.WriteLine($"{_context.HomeViewModels.Count()}");
        Console.WriteLine($"============================================================================");
        return _test;
    }
}
