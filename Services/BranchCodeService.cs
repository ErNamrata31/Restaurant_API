using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.Data;

namespace RestaurantAPI.Services
{
    public class BranchCodeService
    {
        private readonly AppDbContext _context;
        public BranchCodeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> GenerateBranchCodeAsync()
        {
            var lastBranchCode = await _context.Branches.OrderByDescending(x=>x.Id).Select(b=>b.BranchCode).FirstOrDefaultAsync();
            if(string.IsNullOrEmpty(lastBranchCode))
            {
                return "BR001";
            }
            int lastNumber = int.Parse(lastBranchCode.Substring(2));
            return $"BR{(lastNumber + 1):D3}";

        }
    }
}
