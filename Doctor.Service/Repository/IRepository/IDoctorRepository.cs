using Doctor.Service.Models.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Service.Repository.IRepository
{
    public interface IDoctorRepository
    {

        public Task<IEnumerable<DoctorInformation>> GetDoctorInformations();

        public Task<DoctorInformation> GetDoctorInformation(int id);


        public Task<DoctorInformation> PutDoctorInformation(int id, DoctorInformation doctorInformation);


        public Task<DoctorInformation> PostDoctorInformation(DoctorInformation doctorInformation);

    }
}
