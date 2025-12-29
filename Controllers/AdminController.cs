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
    [ApiController]
    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly BranchCodeService _branchCodeService;
        private readonly PasswordService _passwordService;
        private readonly IMapper _mapper;
        public AdminController(AppDbContext context,BranchCodeService branchCodeService, PasswordService passwordService, IMapper mapper)
        {
            _dbContext = context;
            _branchCodeService = branchCodeService;
            _passwordService = passwordService;
            _mapper = mapper;
        }
        [HttpGet("GetBranch")]
        public async Task<ActionResult > GetBranch()
        {
            try
            {
                var result = await _dbContext.Branches.Where(x => x.IsDelete == false).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        [HttpGet("GetBranchById/{id}")]
        public async Task<ActionResult> GetBranchById(int id)
        {
            try
            {
                var branch = _dbContext.Branches.FindAsync(id);
                if (branch == null)
                    return NotFound();
                return Ok(branch);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("CreateBranch")]
        public async Task<ActionResult> CreateBranch(BranchDTO dto)
        {
            try
            {
                var branch = _mapper.Map<Branch>(dto);
                branch.BranchCode = await _branchCodeService.GenerateBranchCodeAsync();
                branch.Password = "12345";
                _dbContext.Branches.AddAsync(branch);
                await _dbContext.SaveChangesAsync();
                return Ok(new { id = branch.Id, branch });
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        [HttpDelete("DeleteBranch/{Id}")]
        public async Task<ActionResult> DeleteBranch(int Id)
        {
            try
            {
                
                var branch = await _dbContext.Branches.FindAsync(Id);
                if (branch == null)
                    return NotFound();
                branch.IsDelete = true;
                _dbContext.Branches.Update(branch);
                await _dbContext.SaveChangesAsync();
                return Ok(new { message = "Branch deleted successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetCategory")]
        public async Task<ActionResult> GetCategory()
         {
            try
            {
                var category = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
                var result = _mapper.Map<List<CategoryDTO>>(category);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpPost("CreateCategory")]
        public async Task<ActionResult> CreateCategory(CategoryDTO dto)
        {
            try
            {
               var category = _mapper.Map<Category>(dto);
                _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return Ok(new { id = category.Id, category });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("DeleteCategory/{Id}")]
        public async Task<ActionResult> DeleteCategory(int Id)
        {
            try
            {
                var category = await _dbContext.Categories.FindAsync(Id);
                if (category == null) return NotFound();

                category.IsDeleted = true;
               
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetCategoryById/{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = _dbContext.Categories.FindAsync(id);
                if (category == null)
                    return NotFound();
                return Ok(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _dbContext.Product
             .Where(p => !p.IsDeleted)
             .ToListAsync();

            var result = _mapper.Map<List<ProductReadDTO>>(products);
            return Ok(result);
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ProductReadDTO>> GetProductById(int id)
        {
            try
            {
                var product = _dbContext.Product.Find(id);
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(ProductCreateDTO dto)
        {
            try
            {
                var product = _mapper.Map<Products>(dto);
                _dbContext.Product.Add(product);
                await _dbContext.SaveChangesAsync();

                return Ok(product.Id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("DeleteProduct/{Id}")]
        public async Task<ActionResult> DeleteProduct(int Id)
        {
            try
            {
                var product = await _dbContext.Product.FindAsync(Id);
                if (product == null) return NotFound();

                product.IsDeleted = true;
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
