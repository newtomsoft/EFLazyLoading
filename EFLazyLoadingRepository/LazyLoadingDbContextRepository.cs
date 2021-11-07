namespace EFLazyLoadingRepository;

public class LazyLoadingDbContextRepository
{
    private readonly LazyLoadingDbContextFactory _lazyLoadingDbContextFactory;

    public LazyLoadingDbContextRepository(LazyLoadingDbContextFactory lazyLoadingDbContextFactory)
    {
        _lazyLoadingDbContextFactory = lazyLoadingDbContextFactory;
    }
}