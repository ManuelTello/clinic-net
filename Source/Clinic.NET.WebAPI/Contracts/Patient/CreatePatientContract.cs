using System.Text.Json.Serialization;

namespace Clinic.NET.WebAPI.Contracts.Patient
{
    public class CreatePatientContract
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        
        [JsonPropertyName("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        
        [JsonPropertyName("identification")]
        public int Identification { get; set; }
        
        [JsonPropertyName("insurance_type")]
        public string? InsuranceType { get; set; }
    }
}

