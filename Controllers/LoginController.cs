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
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, ex.Message, null));
            }
        }

    }
}
