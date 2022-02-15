namespace VP.Pixel.Core.Persistence.Base;

using System.ComponentModel.DataAnnotations;

public abstract class Entity<TId>
    where TId : struct, IEquatable<TId>
{
    /// <summary>The id</summary>
    [Key]
    public TId Id { get; set; }

    /// <summary>The created on</summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>The updated on</summary>
    public DateTime? UpdatedOn { get; set; }
}
