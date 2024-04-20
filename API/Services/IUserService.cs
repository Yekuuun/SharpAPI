namespace SharpApi.Services;

public interface IUserService
{
    Task<ServiceResponse<GetUserInfosDto>> GetUserById(int id);
    Task<ServiceResponse<List<GetUserInfosDto>>> GetAllUsers();
    Task<ServiceResponse<GetUserInfosDto>> AddUser(AddUserDto user);
    Task<ServiceResponse<UpdateUserDto>> UpdateUser(UpdateUserDto user_dto);
    
    //pagination
    Task<ServiceResponse<BasePaginationResponseDto<GetUserInfosDto>>> GetUsersWithPagination(int page);
}