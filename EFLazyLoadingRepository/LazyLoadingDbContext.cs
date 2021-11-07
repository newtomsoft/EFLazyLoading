using EFLazyLoadingRepository.Dao;
using Microsoft.EntityFrameworkCore;

namespace EFLazyLoadingRepository;

public class LazyLoadingDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public LazyLoadingDbContext(DbContextOptions<LazyLoadingDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}