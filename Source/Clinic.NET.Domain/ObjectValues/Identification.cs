using System.Text.RegularExpressions;
using Clinic.NET.Domain.ReturnType;

namespace Clinic.NET.Domain.ObjectValues
{
    public partial record Identification
    {
        public int ValueIdentification { get; init; }

        private const string ValidationIdentificationPattern = @"^([0-9]){250}$";

        private Identification(int valueIdentification)
        {
            this.ValueIdentification = valueIdentification;
        }

        public static DomainReturn<Identification> New(int valueIdentification)
        {
            var errorsList = new List<string>();

            // If the identification has a length of "1" and a value of "0" then it means
            // the request has an empty identification field
            if (valueIdentification.ToString().Length == 1)
            {
                errorsList.Add("Identification is required");
                return new DomainReturn<Identification>(null, errorsList);
            }
            else if (ValidateIdentification().Match(ValidationIdentificationPattern).Success == false)
            {
                errorsList.Add("Identification is invalid");
                return new DomainReturn<Identification>(null, errorsList);
            }
            else
            {
                return new DomainReturn<Identification>(new Identification(valueIdentification), errorsList, true);
            }
        }

        [GeneratedRegex(ValidationIdentificationPattern)]
        private static partial Regex ValidateIdentification();
    }
}