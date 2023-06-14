using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doctor.Service.Models.EntityModel;
using Doctor.Service.Repository.IRepository;

namespace Doctor.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorInformationsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorInformationsController(IDoctorRepository doctorRepository)=>_doctorRepository = doctorRepository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorInformation>>> GetDoctorInformations()
        {
            try
            {
                var doctorInformations = await _doctorRepository.GetDoctorInformations();
                return Ok(doctorInformations); //CreatedAtAction("GetDoctorInformation", new { doctorInformations });
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<DoctorInformation>> GetDoctorInformation(int id)
        //{
        //  if (_context.DoctorInformations == null)
        //  {
        //      return NotFound();
        //  }
        //    var doctorInformation = await _context.DoctorInformations.FindAsync(id);

        //    if (doctorInformation == null)
        //    {
        //        return NotFound();
        //    }

        //    return doctorInformation;
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<DoctorInformation>> PutDoctorInformation(int id, DoctorInformation doctorInformation)
        {
            var doctor = await _doctorRepository.PutDoctorInformation(id,doctorInformation);
            if(doctor == null)
                return NotFound();
            else
                return Ok(doctor);
        }
        //[HttpPost]
        //public async Task<ActionResult<DoctorInformation>> PostDoctorInformation(DoctorInformation doctorInformation)
        //{
        //  if (_context.DoctorInformations == null)
        //  {
        //      return Problem("Entity set 'DoctorDbContext.DoctorInformations'  is null.");
        //  }
        //    _context.DoctorInformations.Add(doctorInformation);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDoctorInformation", new { id = doctorInformation.Id }, doctorInformation);
        //}

        //// DELETE: api/DoctorInformations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDoctorInformation(int id)
        //{
        //    if (_context.DoctorInformations == null)
        //    {
        //        return NotFound();
        //    }
        //    var doctorInformation = await _context.DoctorInformations.FindAsync(id);
        //    if (doctorInformation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DoctorInformations.Remove(doctorInformation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
