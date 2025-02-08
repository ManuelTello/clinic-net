using Clinic.NET.Domain.AggregateRoots.Patient;

namespace Clinic.NET.Domain.RepositoriesInterfaces
{
    public interface IPatientRepository:IDisposable
    {
        public Task CreatePatient(Patient patient);

        public Task SavesChangesAsync();
    }
}