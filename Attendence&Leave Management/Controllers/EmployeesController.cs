using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Attendence_Leave_Management.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Attendence_Leave_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Attendance_Leave_Context _context;
        private readonly IConfiguration _configuration;

        public EmployeesController(Attendance_Leave_Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployeeData()
        {
          if (_context.EmployeeData == null)
          {
              return NotFound();
          }
            return await _context.EmployeeData.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployees(int id)
        {
          if (_context.EmployeeData == null)
          {
              return NotFound();
          }
            var employees = await _context.EmployeeData.FindAsync(id);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees(int id, Employees employees)
        {
            if (id != employees.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployees(Employees employees)
        {
          if (_context.EmployeeData == null)
          {
              return Problem("Entity set 'Attendance_Leave_Context.EmployeeData'  is null.");
          }
            _context.EmployeeData.Add(employees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployees", new { id = employees.EmployeeId }, employees);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            if (_context.EmployeeData == null)
            {
                return NotFound();
            }
            var employees = await _context.EmployeeData.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.EmployeeData.Remove(employees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesExists(int id)
        {
            return (_context.EmployeeData?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }

        //Login For Employee using Jwt

        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] EmployeeLogin employeeLoginModel)
        {
            var currentEmployee = _context.EmployeeData.FirstOrDefault(x => x.UserName == employeeLoginModel.UserName && x.Password == employeeLoginModel.Password);
            if (currentEmployee == null)
            {
                return NotFound("Invalid UserName or Password");
            }
            var token = GenerateToken(currentEmployee);
            if (token == null)
            {
                return NotFound("Invalid Credentials");
            }
            return Ok(token);
        }

        [NonAction]
        public string GenerateToken(Employees employee)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var myClaims = new List<Claim>
            {

                new Claim(ClaimTypes.Name,employee.EmployeeName),
                new Claim(ClaimTypes.Email,employee.EmployeeEmail),
                

            };
            var token = new JwtSecurityToken(issuer: _configuration["JWT:issuer"],
                                             audience: _configuration["JWT:audience"],
                                             claims: myClaims,
                                             expires: DateTime.Now.AddDays(1),
                                             signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);




        }
    }
}
