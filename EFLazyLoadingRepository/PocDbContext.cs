using EFLazyLoadingRepository.Dao;
using Microsoft.EntityFrameworkCore;

namespace EFLazyLoadingRepository;

public class PocDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public PocDbContext(DbContextOptions<PocDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}