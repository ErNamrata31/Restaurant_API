using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                var result = _dbContext.Employees.ToList();
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
            var employee= _mapper.Map<Employee>(dto);
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
            return Ok(new {message="Delete Successful"});
        }
    }
}
