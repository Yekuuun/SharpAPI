
using AutoMapper;
using Azure;
using SharpApi.Repository;

namespace SharpApi.Service;

public class UserService(IMapper mapper, UserRepository userRepository, DataContext context) : IUserService
{
    private readonly IMapper _mapper = mapper;
    private readonly UserRepository _userRepository = userRepository;
    private readonly DataContext _context = context;

    public async Task<ServiceResponse<GetUserInfosDto>> AddUser(User user)
    {
        ServiceResponse<GetUserInfosDto> response = new();
        try
        {
            User new_user = await _userRepository.InsertEntity(user);
            response.Data = _mapper.Map<GetUserInfosDto>(new_user);
            return response;
        }
        catch (Exception ex)
        {
            return ErrorManager.ReturnError<GetUserInfosDto>(EErrorType.BAD, ex.Message);
        }
    }

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

    public async Task<ServiceResponse<BasePaginationResponseDto<GetUserInfosDto>>> GetUsersWithPagination(int page)
    {
        ServiceResponse<BasePaginationResponseDto<GetUserInfosDto>> response = new();

        int batch_size = 15;
        try
        {
            page = page == 0 ? page++ : page;

            //total users
            int total_users = await _context.Users.CountAsync();

            //list of users
            int total_pages = (int)Math.Ceiling((double)total_users / batch_size);

            if(page > total_pages)
            {
                return ErrorManager.ReturnError<BasePaginationResponseDto<GetUserInfosDto>>(EErrorType.BAD, "page out of range");
            }

            List<GetUserInfosDto> users = await _context.Users
                .OrderBy(u => u.Id)
                .Skip((page - 1) * batch_size)
                .Take(batch_size)
                .Select(u => new GetUserInfosDto(u.Id, u.UserName, u.Name, u.Firstname))
                .ToListAsync();
            
            BasePaginationResponseDto<GetUserInfosDto> result = new()
            {
                Elements = users,
                TotalPages = total_pages,
                BatchSize = batch_size,
                Page = page
            };

            response.Data = result;
            return response;
        }
        catch(Exception ex)
        {
            return ErrorManager.ReturnError<BasePaginationResponseDto<GetUserInfosDto>>(EErrorType.BAD, ex.Message);
        }
    }

    public async Task<ServiceResponse<UpdateUserDto>> UpdateUser(UpdateUserDto user_dto)
    {
        ServiceResponse<UpdateUserDto> response = new();

        try
        {
            User? user= await _userRepository.GetEntityById(user_dto.UserId);
            if(user == null)
            {
                return ErrorManager.ReturnError<UpdateUserDto>(EErrorType.NULL, "user not found.");;
            }

            user.UserName = user_dto.UserName;
            user.Firstname = user_dto.Firstname;
            user.Email = user_dto.Email;
            user.Name = user_dto.Name;

            await _context.SaveChangesAsync();
            response.Data = user_dto;

            return response;
        }
        catch(Exception ex)
        {
            return ErrorManager.ReturnError<UpdateUserDto>(EErrorType.BAD, ex.Message);
        }
    }
}