using Microsoft.AspNetCore.Http.HttpResults;

namespace SharpApi.Controllers;

public static class ResponseManager
{
    public static Task<ActionResult<ServiceResponse<T>>> GetResponse<T>(ServiceResponse<T> packet)
    {
        return packet.EErrorType switch
        {
            EErrorType.NULL => Task.FromResult<ActionResult<ServiceResponse<T>>>(new NotFoundObjectResult(packet)),
            EErrorType.SUCCESS => Task.FromResult<ActionResult<ServiceResponse<T>>>(new OkObjectResult(packet)),
            EErrorType.UNAUTHORIZED => Task.FromResult<ActionResult<ServiceResponse<T>>>(new UnauthorizedObjectResult(packet)),
            EErrorType.BAD => Task.FromResult<ActionResult<ServiceResponse<T>>>(new BadRequestObjectResult(packet)),
            EErrorType.INTERNAL => Task.FromResult<ActionResult<ServiceResponse<T>>>(new StatusCodeResult(500)),
            _ => Task.FromResult<ActionResult<ServiceResponse<T>>>(new BadRequestObjectResult(packet)),
        };
    }
}