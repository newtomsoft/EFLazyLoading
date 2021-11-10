using EFLazyLoadingDomain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLazyLoadingRepository.Dao;

[Table("Posts")]
public class PostDao
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int BlogId { get; set; }

    public virtual BlogDao Blog { get; set; }

    public Post ToPost()
    {
        return new Post
        {
            Id = Id,
            Title = Title,
            Content = Content,
        };
    }
}