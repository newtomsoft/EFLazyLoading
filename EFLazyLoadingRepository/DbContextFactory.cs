using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFLazyLoadingRepository;

public class DbContextFactory : IDesignTimeDbContextFactory<PocLazyLoadingDbContext>
{
    private readonly DbContextOptions<PocLazyLoadingDbContext> _options;

    public DbContextFactory(string connectionString, bool lazyLoading) => 
        _options = lazyLoading ? 
            new DbContextOptionsBuilder<PocLazyLoadingDbContext>().UseLazyLoadingProxies().UseSqlite(connectionString).Options :
            new DbContextOptionsBuilder<PocLazyLoadingDbContext>().UseSqlite(connectionString).Options;

    public PocLazyLoadingDbContext Create() => new(_options);

    public PocLazyLoadingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PocLazyLoadingDbContext>();
        optionsBuilder.UseSqlite("Data Source=D:\\db.sqlite");
        return new PocLazyLoadingDbContext(optionsBuilder.Options);
    }

    public DbContextFactory()
    {

    }
}