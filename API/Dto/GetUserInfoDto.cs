namespace SharpApi.Dtos;

public class GetUserInfosDto(int id, string email, string name, string firstname)
{
    public int Id { get; set; } = id;
    public string Email { get; set; } = email;
    public string Name { get; set; } = name;
    public string FirstName { get; set; } = firstname;
}