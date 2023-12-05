using Agrisys.Models;
using Microsoft.EntityFrameworkCore;

namespace Agrisys.Data;

public class EFRepository : IRepository {
    private readonly DatabaseContext _context;

    public EFRepository(DatabaseContext context) {
        _context = context;
    }

    public async Task<List<Farm>> GetAllFarmsAsync() {
        return await _context.Farms.ToListAsync();
    }

    public async Task<Farm> GetFarmByIdAsync(int id) {
        return (await _context.Farms.FirstOrDefaultAsync(f => f.Id == id))!;
    }

    public async Task AddFarmAsync(Farm farm) {
        _context.Farms.Add(farm);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateFarmAsync(Farm farm) {
        _context.Farms.Update(farm);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFarmAsync(int id) {
        var farm = await _context.Farms.FindAsync(id);
        if (farm != null) {
            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AssignUserToFarm(string userId, int farmId) {
        var farmUser = new FarmUser { UserId = userId, FarmId = farmId };
        _context.FarmUsers.Add(farmUser);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveUserFromFarm(string userId, int farmId) {
        var farmUser = await _context.FarmUsers.FirstOrDefaultAsync(fu => fu.UserId == userId && fu.FarmId == farmId);
        if (farmUser != null) {
            _context.FarmUsers.Remove(farmUser);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Farm>> GetFarmsByUserId(string userId) {
        return await _context.FarmUsers
            .Where(fu => fu.UserId == userId)
            .Select(fu => fu.Farm)
            .ToListAsync();
    }
}