using EFLazyLoadingRepository;

IRepository lazyLoadingRepository = new LazyLoadingRepository("Data Source=db.sqlite");
IRepository eagerLoadingRepository = new EagerLoadingRepository("Data Source=db.sqlite");

var blogsPerRequest = 1000;
Console.WriteLine($"Displaying first {blogsPerRequest} blogs with lazy loading...");
foreach (var currentBlog in lazyLoadingRepository.GetBlogsRange(0, blogsPerRequest))
{
    Console.WriteLine($" blogId: {currentBlog.Id}");
    foreach (var currentPost in currentBlog.Posts)
        Console.WriteLine($"... postId: {currentPost.Id} - post title: {currentPost.Title} - content: {currentPost.Content}");
}

Console.WriteLine("press a key to continue...");
Console.ReadLine();

Console.WriteLine($"Displaying next {blogsPerRequest} blogs with eager loading...");
foreach (var currentBlog in eagerLoadingRepository.GetBlogsRange(blogsPerRequest, blogsPerRequest))
{
    Console.WriteLine($" blogId: {currentBlog.Id}");
    foreach (var currentPost in currentBlog.Posts)
        Console.WriteLine($"... postId: {currentPost.Id} - post title: {currentPost.Title} - content: {currentPost.Content}");
}
