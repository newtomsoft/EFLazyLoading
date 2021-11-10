using EFLazyLoadingDomain;

namespace EFLazyLoadingRepository;

public interface IDbContextRepository
{
    public IEnumerable<Blog> GetBlogsRange(int index, int number);
}