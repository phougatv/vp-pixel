namespace VP.Pixel.Core.Persistence.Base;

using System.ComponentModel.DataAnnotations;

public abstract class BaseEntity
{
    /// <summary>The id</summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>The created on</summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>The updated on</summary>
    public DateTime? UpdatedOn { get; set; }
}
