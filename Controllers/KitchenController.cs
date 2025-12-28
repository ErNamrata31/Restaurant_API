using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly BranchCodeService _branchCodeService;
        private readonly PasswordService _passwordService;
        private readonly IMapper _mapper;
        public KitchenController(AppDbContext context, BranchCodeService branchCodeService, PasswordService passwordService, IMapper mapper)
        {
            _dbContext = context;
            _branchCodeService = branchCodeService;
            _passwordService = passwordService;
            _mapper = mapper;
        }
    }
}
