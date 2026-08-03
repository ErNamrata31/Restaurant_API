using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models.DTOs;

namespace RestaurantAPI.Services
{
    public class MenuService
    {
        private readonly AppDbContext _dbContext;
        public MenuService(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<List<NavbarResponseDTO>> MenuList(int? roleId = null)
        {
            try
            {
                var query = from m in _dbContext.MenuMasters
                            join s in _dbContext.SubMenuMasters on m.Id equals s.MenuId
                            join r in _dbContext.RoleRights on s.MenuId equals r.MenuId
                            select new
                            {
                                SubMenuName = s.SubMenuName,
                                MenuName = m.MenuName,
                                Url = s.Url,
                                Icon = s.Icon,
                                RoleId = r.UserId
                            };

                // Optional: Filter by roleId if provided
                if (roleId.HasValue)
                {
                    query = query.Where(x => x.RoleId == roleId.Value);
                }

                // Execute query asynchronously
                var result = await query.ToListAsync();

                // Group and transform to NavbarResponseDTO
                var navbarResponse = result
                    .GroupBy(x => x.MenuName)
                    .Select(g => new NavbarResponseDTO
                    {
                        Title = g.Key,
                        items = g.Select(x => new NavbarDTO
                        {
                            SubMenuName = x.SubMenuName,
                            MenuName = x.MenuName,
                            Icon = x.Icon,
                            Url = x.Url,
                            roleIds = g.Select(r => r.RoleId).Distinct().ToList(),
                            permissions = g.Select(r => r.RoleId).Distinct().ToList()
                        })
                        .DistinctBy(x => new { x.Url, x.SubMenuName }) // Remove duplicates
                        .ToList()
                    })
                    .ToList();

                return navbarResponse;
            }
            catch (Exception ex)
            {
                // Log the exception properly instead of throwing a new one
                // _logger.LogError(ex, "Error occurred while fetching menu list");
                throw; // Re-throw the original exception
            }
        }
    }
}

