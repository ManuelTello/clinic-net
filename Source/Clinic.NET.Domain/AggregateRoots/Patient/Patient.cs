using Clinic.NET.Domain.ObjectValues;

namespace Clinic.NET.Domain.AggregateRoots.Patient;

public sealed class Patient
{
    public PatientId Id { get; private set; }

    public FullName FullName { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }
        
    public Email Email { get; private set; }

    public Identification Identification { get; private set; }

    public string InsuranceType { get; private set; }

    public Patient(PatientId id, FullName fullName, DateTime dateOfBirth, PhoneNumber phoneNumber,
        Email email, Identification identification, string insuranceType)
    {
        this.Id = id;
        this.FullName = fullName;
        this.DateOfBirth = dateOfBirth;
        this.PhoneNumber = phoneNumber;
        this.Email = email;
        this.Identification = identification;
        this.InsuranceType = insuranceType;
    }

    private Patient()
    {
    }
}