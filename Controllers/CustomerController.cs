using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly BranchCodeService _branchCodeService;
        private readonly PasswordService _passwordService;
        private readonly IMapper _mapper;
        public CustomerController(AppDbContext context, BranchCodeService branchCodeService, PasswordService passwordService, IMapper mapper) {
            _dbContext = context;
            _branchCodeService = branchCodeService;
            _passwordService = passwordService;
            _mapper = mapper;
        }
        //public async Task<ActionResult> GetCustomer()
        //{
        //    try
        //    {
        //        var result = _dbContext.Customers.ToList();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
