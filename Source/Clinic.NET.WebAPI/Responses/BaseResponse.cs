namespace Clinic.NET.WebAPI.Responses
{
    public class BaseResponse(int statusCode, string message)
    {
        public int StatusCode { get; set; } = statusCode;

        public string Message { get; set; } = message;
    }
}

