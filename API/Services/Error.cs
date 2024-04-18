namespace SharpApi.Services;

public static class ErrorManager
{
    public static ServiceResponse<T> ReturnError<T>(EErrorType error_type, string message)
    {
        ServiceResponse<T> error_response = new()
        {
            EErrorType = error_type,
            Message = message,
        };

        return error_response;
    }
}