namespace SharpApi.Models;

public class BaseEntity:BaseEntityId
{
    [Column("creation_date")]
    public DateTime CreationDate { get; set; }
}