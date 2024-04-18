
using AutoMapper;
using SharpApi.Repository;

namespace SharpApi.Service;

public class UserService(IMapper mapper, UserRepository userRepository) : IUserService
{
    private readonly IMapper _mapper = mapper;
    private readonly UserRepository _userRepository = userRepository;

    public async Task<ServiceResponse<List<GetUserInfosDto>>> GetAllUsers()
    {
        ServiceResponse<List<GetUserInfosDto>> response = new();

        try
        {
            List<User> users = await _userRepository.GetAll();

            if(users.Count == 0)
            {
                return ErrorManager.ReturnError<List<GetUserInfosDto>>(EErrorType.NULL, "no users.");
            }

            response.Data = _mapper.Map<List<GetUserInfosDto>>(users);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<List<GetUserInfosDto>>(EErrorType.BAD, ex.Message);
        }
        return response;
    }

    public async Task<ServiceResponse<GetUserInfosDto>> GetUserById(int id)
    {
        ServiceResponse<GetUserInfosDto> response = new();

        try
        {
            User? user = await _userRepository.GetEntityById(id);

            if(user == null)
            {
                return ErrorManager.ReturnError<GetUserInfosDto>(EErrorType.NULL, "user not found.");
            }

            response.Data = _mapper.Map<GetUserInfosDto>(user);
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetUserInfosDto>(EErrorType.BAD, ex.Message);
        }
        return response;
    }
}