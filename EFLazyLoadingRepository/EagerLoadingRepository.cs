using EFLazyLoadingDomain;
using Microsoft.EntityFrameworkCore;

namespace EFLazyLoadingRepository;

public class EagerLoadingRepository : IRepository
{
    private readonly PocDbContext _db;

    public EagerLoadingRepository(string connectionString) => _db = new(new DbContextOptionsBuilder<PocDbContext>().UseSqlite(connectionString).Options);

    public Blog GetBlogById(int id) => _db.Blogs.Include(blog => blog.Posts).First(blog => blog.Id == id).ToBlog();

    public IEnumerable<Blog> GetBlogsRange(int index, int number)
    {
        var blogsDao = _db.Blogs.OrderBy(blog => blog.Id).Skip(index).Take(number).Include(blog => blog.Posts).AsEnumerable();
        return blogsDao.Select(blog => blog.ToBlog()).ToList();
    }
}