using EFLazyLoadingRepository.Dao;
using Microsoft.EntityFrameworkCore;

namespace EFLazyLoadingRepository;

public class PocDbContext : DbContext
{
    public DbSet<BlogDao> Blogs { get; set; }
    public DbSet<PostDao> Posts { get; set; }

#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public PocDbContext(DbContextOptions<PocDbContext> options) : base(options){ }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}