using EFLazyLoadingRepository;
using Microsoft.EntityFrameworkCore;

var lazyLoadingDbContextFactory = new LazyLoadingDbContextFactory("Data Source=D:\\db.sqlite");
var fuseRepository = new LazyLoadingDbContextRepository(lazyLoadingDbContextFactory);

using var lazyLoadingDbContext = lazyLoadingDbContextFactory.Create();

//var linesToAdd = 100000;
//for (var i = 0; i < linesToAdd; i++)
//{
//    var blog = new Blog { Name = $"blogName : {Guid.NewGuid()}" };
//    lazyLoadingDbContext.Blogs.Add(blog);
//}
//lazyLoadingDbContext.SaveChanges();

//var blogIds = lazyLoadingDbContext.Blogs.Select(b => b.Id).ToList();


//foreach (var blogId in blogIds.OrderBy(_ => Guid.NewGuid()))
//{
//    var post1 = new Post { Title = Guid.NewGuid().ToString(), Content = Guid.NewGuid().ToString(), BlogId = blogId };
//    var post2 = new Post { Title = Guid.NewGuid().ToString(), Content = Guid.NewGuid().ToString(), BlogId = blogId };
//    lazyLoadingDbContext.Posts.Add(post1);
//    lazyLoadingDbContext.Posts.Add(post2);
//}
//lazyLoadingDbContext.SaveChanges();

Console.WriteLine("Start Displaying");
foreach (var currentBlog in lazyLoadingDbContext.Blogs)
{
    Console.WriteLine(currentBlog.Name);
    foreach (var currentPost in currentBlog.Posts)
    {
        Console.WriteLine($"  - post title: {currentPost.Title} / content: {currentPost.Content}");
    }
}


