using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Models.DTOs;
using RestaurantAPI.Models.Entities;
using RestaurantAPI.Services;
using System.Reflection.Emit;

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
        private readonly IQRCodeService _qrCodeService;
        public AdminController(AppDbContext context, BranchCodeService branchCodeService, PasswordService passwordService, IMapper mapper, IQRCodeService qrCodeService)
        {
            _dbContext = context;
            _branchCodeService = branchCodeService;
            _passwordService = passwordService;
            _mapper = mapper;
            _qrCodeService = qrCodeService;
        }
        [HttpGet("GetBranch")]
        public async Task<ActionResult> GetBranch()
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
        public async Task<IActionResult> GetProductById(int id)
        
        
        {
            try
            {
                var product = await _dbContext.Product.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
                if (product == null)
                    return NotFound("Product not found");

                var result = _mapper.Map<ProductReadDTO>(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct([FromForm] ProductCreateDTO dto, IFormFile file)
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

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct([FromForm] ProductCreateDTO dto, IFormFile? file)
        {
            try
            {
                string filepath = "images/Product/";
                var product = await _dbContext.Product.FindAsync(dto.Id);
                if (product == null) return NotFound();

                product.ProductName = dto.ProductName;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.ImageUrl = dto.ImageUrl;
                product.CategoryId = dto.CategoryId;
                product.IsActive = dto.IsActive;
                _dbContext.Product.Update(product);
                await _dbContext.SaveChangesAsync();
                return Ok();
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

        [HttpGet("GetTable")]
        public async Task<IActionResult> GetTable()
        {
            var tables = await _dbContext.TableRecords
             .Where(t => !t.IsDeleted)
             .Select(t => new TableRecordReadDTO
             {
                 Id = t.Id,
                 TableNumber = t.TableNumber,
                 BranchCode = t.BranchCode,
                 SeatingCapacity = t.SeatingCapacity,
                 TableQRCode = Convert.ToBase64String(_qrCodeService.GenerateQrCode(t.TableQRCode)),
                 IsOccupied = t.IsOccupied
             })
             .ToListAsync();
            var result = _mapper.Map<List<TableRecordReadDTO>>(tables);
            return Ok(result);


        }
        [HttpGet("GetTableById/{Id}")]
        public async Task<IActionResult> GetTableById(int Id)
        {
            var tables = await _dbContext.TableRecords
             .Where(t => !t.IsDeleted && t.Id == Id)
             .Select(t => new TableRecordReadDTO
             {
                 Id = t.Id,
                 TableNumber = t.TableNumber,
                 BranchCode = t.BranchCode,
                 SeatingCapacity = t.SeatingCapacity,
                 TableQRCode = Convert.ToBase64String(_qrCodeService.GenerateQrCode(t.TableQRCode)),
                 IsOccupied = t.IsOccupied
             }).ToListAsync();
            var result = _mapper.Map<List<TableRecordReadDTO>>(tables);
            return Ok(result);


        }
        [HttpPost("AddTable")]
        public async Task<ActionResult> AddTable(TableRecordCreateDTO dto)
        {
            try
            {
                bool tableExists = await _dbContext.TableRecords.AnyAsync(x => x.IsDeleted == false && x.TableNumber == dto.TableNumber);
                if (tableExists)
                    return BadRequest(new ApiResponse<TableRecordReadDTO>(400,"Table Number already exists",null ));

                var table = _mapper.Map<TableRecord>(dto);
                table.TableQRCode = $"http://localhost:4200/products={table.TableNumber}";
                _dbContext.TableRecords.Add(table);
                await _dbContext.SaveChangesAsync();
                return Ok(new ApiResponse<TableRecordReadDTO>(200,"Add Successfull",null));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("TableRemove/{Id}")]
        public async Task<ActionResult> TableRemove(int Id)
        {
            try
            {
                var table = await _dbContext.TableRecords.FindAsync(Id);
                if (table == null) return NotFound();
                table.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("UpdateTable")]
        public async Task<ActionResult> UpdateTable(TableRecordCreateDTO dto)
        {
            try
            {
                var table = await _dbContext.TableRecords.FindAsync(dto.Id);
                if (table == null) return NotFound();
                table.TableNumber = dto.TableNumber;
                table.BranchCode = dto.BranchCode;
                table.SeatingCapacity = dto.SeatingCapacity;
                table.IsOccupied = dto.IsOccupied;
                table.IsModified = true;
                table.modifiedBy = dto.modifiedBy;
                _dbContext.TableRecords.Update(table);
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
