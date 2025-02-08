using System.Text.RegularExpressions;
using Clinic.NET.Domain.ReturnType;

namespace Clinic.NET.Domain.ObjectValues
{
    public partial record Email
    {
        public string ValueEmail { get; init; }

        private const string ValidationEmailPattern = @"";

        private Email(string valueEmail)
        {
            this.ValueEmail = valueEmail;
        }

        public static DomainReturn<Email> New(string valueEmail)
        {
            var errorsList = new List<string>();
            
            if (string.IsNullOrEmpty(valueEmail))
            {
                errorsList.Add("Email cannot be empty");
                return new DomainReturn<Email>(null, errorsList);
            }
            else if (ValidateEmail().Match(ValidationEmailPattern).Success == false)
            {
                errorsList.Add("Email is not a valid address");
                return new DomainReturn<Email>(null, errorsList);
            }
            else
            {
                return new DomainReturn<Email>(new Email(valueEmail),errorsList,true);
            }
        }

        [GeneratedRegex(ValidationEmailPattern)]
        private static partial Regex ValidateEmail();
    }
}