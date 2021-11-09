using EFLazyLoadingRepository.Dao;
using Microsoft.EntityFrameworkCore;

namespace EFLazyLoadingRepository;

public class LazyLoadingRepository : IDbContextRepository
{
    private readonly PocDbContext _db;
    
    public LazyLoadingRepository(string connectionString) => _db = new(new DbContextOptionsBuilder<PocDbContext>().UseLazyLoadingProxies().UseSqlite(connectionString).Options);

    public IEnumerable<Blog> GetBlogsRange(int index, int number) => _db.Blogs.Select(b => b).OrderBy(b => b.Id).Skip(index).Take(number).AsEnumerable();


    public void AddRandomBlogs()
    {
        const int linesToAdd = 100000;
        for (var i = 0; i < linesToAdd; i++)
        {
            var blog = new Blog { Name = $"blogName : {Guid.NewGuid()}" };
            _db.Blogs.Add(blog);
        }
        _db.SaveChanges();

        var blogIds = _db.Blogs.Select(b => b.Id).ToList();
        foreach (var blogId in blogIds.OrderBy(_ => Guid.NewGuid()))
        {
            var posts = new List<Post>
            {
                new() { Title = Guid.NewGuid().ToString(), Content = Guid.NewGuid().ToString(), BlogId = blogId }, 
                new() { Title = Guid.NewGuid().ToString(), Content = Guid.NewGuid().ToString(), BlogId = blogId },
            };
            _db.Posts.AddRange(posts);
        }
        _db.SaveChanges();
    }
}