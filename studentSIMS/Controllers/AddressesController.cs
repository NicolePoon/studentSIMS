using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentSIMS.Data;
using studentSIMS.Models;

namespace studentSIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly StudentContext _context;

        public AddressesController(StudentContext context)
        {
            _context = context;
        }

        // Get addresses of a particular student with his/her studentId
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Address.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddressWithStudentId(int studentId)
        {
            var address = await _context.Address.Where(a => a.StudentId == studentId).ToListAsync();

            if (address == null || !address.Any())
            {
                return NotFound();
            }

            return address;
        }


        //Create an API method that changes the address of a student using his/her StudentId. (MSA requirement)
        [HttpPut("address/{addressId}/student/{studentId}")]
        public async Task<IActionResult> PutAddress(int addressId, int studentId, AddressDTO addressDTO)
        {
            var address = await _context.Address.FindAsync(addressId);

            if (address == null)
            {
                return NotFound();
            };

            if (address.StudentId != studentId)
            {
                return BadRequest();
            }

            address.Postcode = addressDTO.Postcode;
            address.Street = addressDTO.Street;
            address.StreetNumber = addressDTO.StreetNumber;
            address.Suburb = addressDTO.Suburb;
            address.Country = addressDTO.Country;
            address.City = addressDTO.City;

            _context.Entry(address).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // Create an API method that adds new address for a student using his/her StudentId.(MSA requirement)
        [HttpPost("studentid/{studentId}")]
        public async Task<ActionResult<Address>> PostAddress(int studentId, AddressDTO addressDTO)
        {
            Address address = new Address() 
            {
                StudentId = studentId
            };

            address.Postcode = addressDTO.Postcode;
            address.Street = addressDTO.Street;
            address.StreetNumber = addressDTO.StreetNumber;
            address.Suburb = addressDTO.Suburb;
            address.Country = addressDTO.Country;
            address.City = addressDTO.City;

            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
