namespace Clinic.NET.Application.Responses
{
    public record CreatePatientCommandResult(
        bool IsSuccess,
        Dictionary<string,string> Errors 
    );
}

