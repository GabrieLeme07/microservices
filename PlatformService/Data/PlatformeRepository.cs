using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
        => _context = context;
    

    public void CreatePlatform(Platform platform)
        => _context.Platforms.Add(platform);

    public IEnumerable<Platform> GetAllPlatforms()
        => _context.Platforms.ToList();

    public Platform GetPlatformById(int id)
        => _context.Platforms.FirstOrDefault(e => e.Id == id);

    public bool SaveChanges()
        => _context.SaveChanges() >= 0;
}