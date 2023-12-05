using Agrisys.Models;

namespace Agrisys.Data;

public class EFHomeRepository : IHomeRepository {
    private readonly HomeDbContext _context;

    public EFHomeRepository(HomeDbContext context) {
        _context = context;
    }

    public HomeViewModel GetHomeViewModel() {
        var query = _context.HomeViewModels?
            .OrderByDescending(p => p.HomeViewModelId)
            .LastOrDefault();

        return query;
    }
}
