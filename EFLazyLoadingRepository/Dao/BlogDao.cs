using EFLazyLoadingDomain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLazyLoadingRepository.Dao;

[Table("Blogs")]
public class BlogDao
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<PostDao>? Posts { get; set; }


    public BlogDao(string name)
    {
        Name = name;
    }

    public Blog ToBlog()
    {
        return new Blog(id: Id, name: Name, posts: (from postDao in Posts select postDao.ToPost()).ToList());
    }
}