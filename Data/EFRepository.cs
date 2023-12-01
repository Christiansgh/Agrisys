using Agrisys.Models;

namespace Agrisys.Data; 

public class EFRepository : IRepository {
    private DatabaseContext context;
    public EFRepository(DatabaseContext ctx) {
        context = ctx;
    }

}