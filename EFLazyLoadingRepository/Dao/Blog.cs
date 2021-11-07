using System.ComponentModel.DataAnnotations;

namespace EFLazyLoadingRepository.Dao;

public class Blog
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
}