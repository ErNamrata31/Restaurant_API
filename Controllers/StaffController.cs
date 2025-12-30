using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models.DTOs;
using RestaurantAPI.Models.Entities;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly BranchCodeService _branchCodeService;
        private readonly PasswordService _passwordService;
        private readonly IMapper _mapper;
        public StaffController(AppDbContext context, BranchCodeService branchCodeService, PasswordService passwordService, IMapper mapper)
        {
            _dbContext = context;
            _branchCodeService = branchCodeService;
            _passwordService = passwordService;
            _mapper = mapper;
        }
        [HttpGet("GetEmpRole")]
        public async Task<ActionResult> GetEmpRole()
        {
            try
            {
                var result = _dbContext.EmployeeRoles.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetEmployees")]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                var result = await _dbContext.Employees
                .Where(x => x.IsDeleted == false).Include(x => x.EmployeeRole)
                 .Select(x => new EmployeeReadDTO
                 {
                     Id = x.Id,
                     Name = x.Name,
                     EmailId = x.EmailId,
                     ContactNo = x.ContactNo,
                     Address = x.Address,
                     Position = x.Position,
                     empRoleId = x.empRoleId ?? 0,
                     Salary = x.Salary,
                     RoleName = x.EmployeeRole.RoleName
                 }).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("AddEmployees")]
        public async Task<IActionResult> AddEmployees(EmployeeCreateDTO dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            employee.Password = "12345";
            _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpDelete("DeleteEmp/{Id}")]
        public async Task<IActionResult> DeleteEmp(int Id)
        {
            var employee = await _dbContext.Employees.FindAsync(Id);
            if (employee == null)
                return NotFound();
            employee.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
            return Ok(new { message = "Delete Successful" });
        }
    }
}
