using EFLazyLoadingRepository;

var lazyLoadingRepository = new DbContextRepository(new DbContextFactory("Data Source=D:\\db.sqlite", lazyLoading: true));
var eagerLoadingRepository = new DbContextRepository(new DbContextFactory("Data Source=D:\\db.sqlite", lazyLoading: false));

int blogsPerRequest = 5000;
Console.WriteLine("Displaying first 1000 blogs with lazyloading...");
foreach (var currentBlog in lazyLoadingRepository.GetBlogs(0, blogsPerRequest))
{
    Console.WriteLine($" blogId: {currentBlog.Id}");
    foreach (var currentPost in currentBlog.Posts)
        Console.WriteLine($"... postId: {currentPost.Id} - post title: {currentPost.Title} - content: {currentPost.Content}");
}

Console.WriteLine("press a key to continue...");
Console.ReadLine();

Console.WriteLine("Displaying next 1000 blogs without lazyloading...");
foreach (var currentBlog in eagerLoadingRepository.GetBlogsWithPosts(blogsPerRequest, blogsPerRequest))
{
    Console.WriteLine($" blogId: {currentBlog.Id}");
    foreach (var currentPost in currentBlog.Posts)
        Console.WriteLine($"... postId: {currentPost.Id} - post title: {currentPost.Title} - content: {currentPost.Content}");
}
