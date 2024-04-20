namespace SharpApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Getting all users.
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<ActionResult<ServiceResponse<List<GetUserInfosDto>>>> GetAllUsers()
    {
        ServiceResponse<List<GetUserInfosDto>> response = await _userService.GetAllUsers();
        ActionResult<ServiceResponse<List<GetUserInfosDto>>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Getting a specific user based on his id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetUserInfosDto>>> GetUserById(int id)
    {
        ServiceResponse<GetUserInfosDto> response = await _userService.GetUserById(id);
        ActionResult<ServiceResponse<GetUserInfosDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Adding a new user to Database
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<ActionResult<ServiceResponse<GetUserInfosDto>>> AddUser(User user)
    {
        ServiceResponse<GetUserInfosDto> response = await _userService.AddUser(user);
        ActionResult<ServiceResponse<GetUserInfosDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }

    /// <summary>
    /// Update single user informations.
    /// </summary>
    /// <param name="update_infos"></param>
    /// <returns></returns>
    [HttpPut("")]
    public async Task<ActionResult<ServiceResponse<UpdateUserDto>>> UpdateUser(UpdateUserDto update_infos)
    {
        ServiceResponse<UpdateUserDto> response = await _userService.UpdateUser(update_infos);
        ActionResult<ServiceResponse<UpdateUserDto>> result = await ResponseManager.GetResponse(response);
        return result;
    }
}