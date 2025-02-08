using System.Text.RegularExpressions;
using Clinic.NET.Domain.ReturnType;

namespace Clinic.NET.Domain.ObjectValues
{
    public partial record PhoneNumber
    {
        private const string ValidatePhoneNumberRegex = @"^([0-9]){2,3}[0,9]{6,9}$"; 
        
        public int ValuePhoneNumber { get; init; } 
            
        
        private PhoneNumber(int valuePhoneNumber)
        {
            this.ValuePhoneNumber = valuePhoneNumber; 
        }

        public static DomainReturn<PhoneNumber> New(string valuePhoneNumber)
        {
            var errorsList = new List<string>(); 
            
            if (string.IsNullOrEmpty(valuePhoneNumber))
            {
                errorsList.Add( "Phone number cannot be empty");
                return new DomainReturn<PhoneNumber>(null,errorsList);
            }
            else if (ValidatePhoneNumber().Match(valuePhoneNumber.ToString()).Success == false)
            {
                errorsList.Add("Invalid phone number");
                return new DomainReturn<PhoneNumber>(null, errorsList);
            }
            else
            {
                int parsedPhoneNumber = int.Parse(valuePhoneNumber);
                return new DomainReturn<PhoneNumber>(new PhoneNumber(parsedPhoneNumber),errorsList,true); 
            }
        }

        [GeneratedRegex(ValidatePhoneNumberRegex)]
        private static partial Regex ValidatePhoneNumber();
    }
}

