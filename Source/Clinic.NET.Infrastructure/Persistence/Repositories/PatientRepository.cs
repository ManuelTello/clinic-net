using Clinic.NET.Domain.AggregateRoots.Patient;
using Clinic.NET.Domain.RepositoriesInterfaces;
using Clinic.NET.Infrastructure.Persistence.Contexts;

namespace Clinic.NET.Infrastructure.Persistence.Repositories
{
    public class PatientRepository:IPatientRepository, IDisposable
    {
        private readonly ApplicationContext _context;

        public PatientRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public void Dispose()
        {
        }

        public async Task CreatePatient(Patient patient)
        {
            await this._context.Patients.AddAsync(patient);
        }

        public async Task SavesChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}

