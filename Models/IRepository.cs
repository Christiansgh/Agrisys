namespace Agrisys.Models {
    public interface IRepository {
        IQueryable<User> Users { get; }
    }
}