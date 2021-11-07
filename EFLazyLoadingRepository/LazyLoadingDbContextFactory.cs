using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFLazyLoadingRepository;

public class LazyLoadingDbContextFactory : IDesignTimeDbContextFactory<LazyLoadingDbContext>
{
    private readonly DbContextOptions<LazyLoadingDbContext> _options;

    public LazyLoadingDbContextFactory(string connectionString)
        => _options = new DbContextOptionsBuilder<LazyLoadingDbContext>().UseLazyLoadingProxies().UseSqlite(connectionString).Options;
    //=> _options = new DbContextOptionsBuilder<LazyLoadingDbContext>().UseSqlite(connectionString).Options;
    //=> _options = new DbContextOptionsBuilder<LazyLoadingDbContext>().UseSqlServer(connectionString).Options;

    public LazyLoadingDbContext Create() => new(_options);

    public LazyLoadingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LazyLoadingDbContext>();
        optionsBuilder.UseSqlite("Data Source=D:\\db.sqlite");
        return new LazyLoadingDbContext(optionsBuilder.Options);
    }

    public LazyLoadingDbContextFactory()
    {

    }
}