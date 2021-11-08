using EFLazyLoadingRepository.Dao;
using Microsoft.EntityFrameworkCore;

namespace EFLazyLoadingRepository;

public class DbContextRepository
{
    private readonly PocLazyLoadingDbContext _lazyLoadingDbContext;

    public DbContextRepository(DbContextFactory dbContextFactory) => _lazyLoadingDbContext = dbContextFactory.Create();

    public IEnumerable<Blog> GetBlogs(int index, int number) => _lazyLoadingDbContext.Blogs.Select(b => b).OrderBy(b => b.Id).Skip(index).Take(number).AsEnumerable();
    public IEnumerable<Blog> GetBlogsWithPosts(int index, int number) => _lazyLoadingDbContext.Blogs.Select(b => b).OrderBy(b => b.Id).Skip(index).Take(number).Include(b => b.Posts).AsEnumerable();

    public void AddRandomBlogs()
    {
        const int linesToAdd = 100000;
        for (var i = 0; i < linesToAdd; i++)
        {
            var blog = new Blog { Name = $"blogName : {Guid.NewGuid()}" };
            _lazyLoadingDbContext.Blogs.Add(blog);
        }
        _lazyLoadingDbContext.SaveChanges();

        var blogIds = _lazyLoadingDbContext.Blogs.Select(b => b.Id).ToList();
        foreach (var blogId in blogIds.OrderBy(_ => Guid.NewGuid()))
        {
            var posts = new List<Post>
            {
                new() { Title = Guid.NewGuid().ToString(), Content = Guid.NewGuid().ToString(), BlogId = blogId }, 
                new() { Title = Guid.NewGuid().ToString(), Content = Guid.NewGuid().ToString(), BlogId = blogId },
            };
            _lazyLoadingDbContext.Posts.AddRange(posts);
        }
        _lazyLoadingDbContext.SaveChanges();
    }
}