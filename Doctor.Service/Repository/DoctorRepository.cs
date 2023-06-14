using Doctor.Service.Models.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Doctor.Service.Repository.IRepository;

namespace Doctor.Service.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorDbContext _dbContext;
        public DoctorRepository(DoctorDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<DoctorInformation>> GetDoctorInformations()
        {
            return await _dbContext.DoctorInformations.ToListAsync();
        }

        public async Task<DoctorInformation> GetDoctorInformation(int id)
        {
            return await _dbContext.DoctorInformations.FindAsync(id);
        }

        public async Task<DoctorInformation> PutDoctorInformation(int id, DoctorInformation doctorInformation)
        {
            try
            {
                if (DoctorInformationExists(id))
                {
                    DoctorInformation? doctor = GetDoctorInformationById(id);
                    _dbContext.Entry(doctor).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return doctorInformation;
        }

        public async Task<DoctorInformation> PostDoctorInformation(DoctorInformation doctorInformation)
        {
            _dbContext.DoctorInformations.Add(doctorInformation);
            await _dbContext.SaveChangesAsync();

            return doctorInformation;
        }

        public async Task<DoctorInformation> DeleteDoctorInformation(int id)
        {
            var doctorInformation = await _dbContext.DoctorInformations.FindAsync(id);

            _dbContext.DoctorInformations.Remove(doctorInformation);
            await _dbContext.SaveChangesAsync();

            return doctorInformation;
        }

        private DoctorInformation? GetDoctorInformationById(int id)
        {
            return (_dbContext.DoctorInformations?.FirstOrDefault(x => x.Id == id));
        }
        private bool DoctorInformationExists(int id)
        {
            return (_dbContext.DoctorInformations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}