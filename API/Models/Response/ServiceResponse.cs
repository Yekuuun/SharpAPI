namespace SharpApi.Models;

public class ServiceResponse<D>
{
    public D? Data {get; set;}
    public string Message {get; set;} = "successfully called API.";
    public EErrorType EErrorType {get; set;} = EErrorType.SUCCESS;
}