using EFLazyLoadingRepository.Dao;
using Microsoft.EntityFrameworkCore;

namespace EFLazyLoadingRepository;

public class PocDbContext : DbContext
{
    public DbSet<BlogDao> Blogs { get; set; }
    public DbSet<PostDao> Posts { get; set; }

    public PocDbContext(DbContextOptions<PocDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}