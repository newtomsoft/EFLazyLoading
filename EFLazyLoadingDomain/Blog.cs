﻿namespace EFLazyLoadingDomain
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}