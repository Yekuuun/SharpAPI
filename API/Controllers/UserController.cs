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
}