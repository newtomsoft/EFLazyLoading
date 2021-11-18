using System.Collections.Generic;

namespace EFLazyLoadingDomain
{
    public sealed class Blog
    {
        public Blog(int id, string name, ICollection<Post> posts)
        {
            Id = id;
            Name = name;
            Posts = posts;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}