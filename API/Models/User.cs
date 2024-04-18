/*

author : yekuuun
github : https://github.com/Yekuuun

BaseEntity - WHY ?
using base entity for common properties accross all the application.

*/

namespace SharpApi.Models;

public class User : BaseEntityId
{
    [Column("username")]
    [Required]
    public string UserName { get; set;} = string.Empty;

    [Column("email")]
    [MaxLength(100)]
    [Required]
    public string Email { get; set;} = string.Empty;

    [Column("password_hash")]
    [Required]
    public byte[] PasswordHash { get; set;} = [];

    [Column("password_salt")]
    [Required]
    public byte[] PasswordSalt {get; set;} = [];

    [Column("firstname")]
    [MaxLength(50)]
    [Required]
    public string Firstname {get; set; } = string.Empty;

    [Column("name")]
    [MaxLength(50)]
    [Required]
    public string Name { get; set; } = string.Empty;

}