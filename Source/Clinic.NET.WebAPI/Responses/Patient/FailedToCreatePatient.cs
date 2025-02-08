namespace Clinic.NET.WebAPI.Responses.Patient
{
    public class FailedToCreatePatient:BaseResponse
    {
        public FailedToCreatePatient() : base(400,"Failed to create patient")
        {
             
        }
    }
}

