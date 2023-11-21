using Agrisys.Models;

namespace Agrisys.Data {
    public interface IRepository {
        IQueryable<User> Users { get; }
    }
}