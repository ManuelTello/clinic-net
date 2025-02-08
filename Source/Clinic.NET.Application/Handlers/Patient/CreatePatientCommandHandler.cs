using Clinic.NET.Application.Commands;
using Clinic.NET.Application.Responses;
using Clinic.NET.Domain.AggregateRoots.Patient;
using Clinic.NET.Domain.ObjectValues;
using Clinic.NET.Domain.RepositoriesInterfaces;
using MediatR;

namespace Clinic.NET.Application.Handlers.Patient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, CreatePatientCommandResult>
    {
        private readonly IPatientRepository _patientRepository;

        public CreatePatientCommandHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<CreatePatientCommandResult> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var errorsList = new Dictionary<string, string>();

            var name = FullName.New(request.Name);
            var phoneNumber = PhoneNumber.New(request.PhoneNumber);
            var email = Email.New(request.Email);
            var identification = Identification.New(request.Identification);

            if (!email.IsSuccess)
                errorsList.Add("Email", email.ErrorsList.First());

            if (!phoneNumber.IsSuccess)
                errorsList.Add("PhoneNumber", phoneNumber.ErrorsList.First());

            if (!name.IsSuccess)
                errorsList.Add("Name", name.ErrorsList.First());

            if (!identification.IsSuccess)
                errorsList.Add("Identification", identification.ErrorsList.First());

            if (errorsList.Count == 0)
            {
                var id = new PatientId(Guid.NewGuid());
                var patient = new Domain.AggregateRoots.Patient.Patient(id, name.ResponseData!, request.DateOfBirth, phoneNumber.ResponseData!,
                    email.ResponseData!, identification.ResponseData!, request.InsuranceType!);
                
                await this._patientRepository.CreatePatient(patient);
                await this._patientRepository.SavesChangesAsync();

                return new CreatePatientCommandResult(true,new Dictionary<string, string>());
            }
            else
            {
                return new CreatePatientCommandResult(true, errorsList);
            }
        }
    }
}