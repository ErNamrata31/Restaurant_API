using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Models.DTOs;
using RestaurantAPI.Services;
using System.Text.Json;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleRightController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly MenuService _menuService;
        private readonly IMapper _mapper;
        public RoleRightController(AppDbContext context, IMapper mapper, MenuService menuService)
        {
            _dbContext = context;
            _mapper = mapper;
            _menuService = menuService;
        }
        [HttpGet("GetMenuList")]
        public async Task<ActionResult> GetMenuList()
        {
            try
            {
                var menuList = await _menuService.MenuList();

                // Add this to see what's being returned
                var json = JsonSerializer.Serialize(menuList, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                Console.WriteLine(json);
                return Ok(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
