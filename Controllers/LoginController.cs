using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Models.DTOs;
using RestaurantAPI.Models.Entities;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public LoginController(AppDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                if (dto.RoleId != null && dto.RoleId==1)
                {
                    string Emailid = dto.UserName ?? string.Empty;
                    string password = dto.Password ?? string.Empty;
                    int RoleId = dto.RoleId ?? 0;

                    var empdetails = _dbContext.Employees.FirstOrDefault(x => x.EmailId == Emailid &&
                                             x.Password == password && x.IsDeleted == false && RoleId==x.empRoleId );

                    if (empdetails == null)
                        return Unauthorized(new ApiResponse<EmployeeReadDTO>(401, "User not found", null));

                    var empDto = new EmployeeReadDTO
                    {
                        Id = empdetails.Id,
                        EmailId = empdetails.EmailId,
                        empRoleId=empdetails.empRoleId
                    };
                    return Ok(new ApiResponse<EmployeeReadDTO>(200, "Login successful", empDto));
                }
                else if(dto.RoleId != null && dto.RoleId==4)
                {
                    string branchCode = dto.UserName ?? string.Empty;
                    string password = dto.Password ?? string.Empty;

                    var branch = _dbContext.Branches.FirstOrDefault(x => x.BranchCode == branchCode &&
                                             x.Password == password && x.IsDelete == false);

                    if (branch == null)
                        return Unauthorized(new ApiResponse<BranchDTO>(401, "User not found", null));

                    var branchDto = new BranchDTO
                    {
                        Id = branch.Id,
                        BranchCode = branch.BranchCode
                    };
                    return Ok(new ApiResponse<BranchDTO>(200, "Login successful", branchDto));
                }

                return null;
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, ex.Message, null));
            }
        }

    }
}
