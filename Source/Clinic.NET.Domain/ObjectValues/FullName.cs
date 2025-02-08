using System.Text.RegularExpressions;
using Clinic.NET.Domain.ReturnType;

namespace Clinic.NET.Domain.ObjectValues
{
    public partial record FullName
    {
        public string Value { get; init; }

        private const string ValidationPattern = @"^[A-Za-zÀ-ÿ]+([ '-][A-Za-zÀ-ÿ]+)*$";

        private FullName(string value)
        {
            this.Value = value;
        }

        public static DomainReturn<FullName> New(string fullName)
        {
            var errorsList = new List<string>(); 
            
            if (string.IsNullOrEmpty(fullName))
            {
                errorsList.Add("Name cannot be empty");
                return new DomainReturn<FullName>(null,errorsList);
            }
            else if (ValidateName().Match(fullName).Success == false)
            {
                errorsList.Add("Name is not valid");
                return new DomainReturn<FullName>(null,errorsList);
            }
            else
            {
                return new DomainReturn<FullName>(new FullName(fullName),errorsList,true);
            }
        }

        [GeneratedRegex(ValidationPattern)]
        private static partial Regex ValidateName();
    }
}