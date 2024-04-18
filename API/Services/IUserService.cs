namespace SharpApi.Services;

public interface IUserService
{
    Task<ServiceResponse<GetUserInfosDto>> GetUserById(int id);
    Task<ServiceResponse<List<GetUserInfosDto>>> GetAllUsers();
}