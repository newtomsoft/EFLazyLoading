using EFLazyLoadingDomain;

namespace EFLazyLoadingRepository;

public interface IRepository
{
    public Blog GetBlogById(int id);
    public IEnumerable<Blog> GetBlogsRange(int index, int number);
}