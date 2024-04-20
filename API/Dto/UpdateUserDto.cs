namespace SharpApi.Dtos;

public class UpdateUserDto
{
    public int UserId { get; set; }
    public string UserName { get; set;} = string.Empty;
    public string Email { get; set;} = string.Empty;
    public string Name { get; set;} = string.Empty;
    public string Firstname { get; set;} = string.Empty;
}