using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWeb.Data;
using ApiWeb.Models;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeContactsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeContacts
        [HttpGet]
        public List<EmployeeContact> GetEmployeeContacts()
        {
            return _context.EmployeeContacts.ToList();
        }

        // GET: api/EmployeeContacts/5
        [HttpGet("{id}")]
        public IActionResult GetEmployeeContact(int id)
        {
            var employeeContact = _context.EmployeeContacts.Find(id);

            if (employeeContact == null)
            {
                return NotFound();
            }

            return Ok(employeeContact);
        }

        // PUT: api/EmployeeContacts/5
        [HttpPut("{id}")]
        public IActionResult PutEmployeeContact(int id, EmployeeContact employeeContact)
        {
            if (id != employeeContact.Id)
            {
                return BadRequest();
            }
            _context.Update(employeeContact);
            _context.SaveChanges();



            return Ok();
        }

        // POST: api/EmployeeContacts

        [HttpPost]
        public ActionResult PostEmployeeContact(EmployeeContact employeeContact)
        {
            _context.EmployeeContacts.Add(employeeContact);
            _context.SaveChanges();
            return Ok(employeeContact);

        }

     
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeContact(int id)
        {
            var employeeContact = _context.EmployeeContacts.Find(id);
            if (employeeContact == null)
            {
                return NotFound();
            }

            _context.EmployeeContacts.Remove(employeeContact);
            _context.SaveChanges();

            return Ok();
        }


    }
}