using Agrisys.Models;

namespace Agrisys.Data; 

public interface IRepository {
    Task<List<Farm>> GetAllFarmsAsync();
    Task<Farm> GetFarmByIdAsync(int id);
    Task AddFarmAsync(Farm farm);
    Task UpdateFarmAsync(Farm farm);
    Task DeleteFarmAsync(int id);
    Task AssignUserToFarm(string userId, int farmId);
    Task RemoveUserFromFarm(string userId, int farmId);
    Task<IEnumerable<Farm>> GetFarmsByUserId(string userId);
}