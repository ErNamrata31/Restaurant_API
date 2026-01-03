using AutoMapper;
using RestaurantAPI.Models.DTOs;
using RestaurantAPI.Models.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Products, ProductReadDTO>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.CategoryName));
        CreateMap<Employee, EmployeeReadDTO>()
           .ForMember(dest => dest.RoleName,
                      opt => opt.MapFrom(src => src.EmployeeRole.RoleName));
        CreateMap<EmployeeCreateDTO, Employee>()
    .ForMember(dest => dest.Id, opt => opt.Ignore());


        CreateMap<ProductCreateDTO, Products>();
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();
        CreateMap<BranchDTO, Branch>();
        CreateMap<Branch, BranchDTO>();
        CreateMap<TableRecord, TableRecordCreateDTO>();
        CreateMap<TableRecord, TableRecordReadDTO>();
        CreateMap<TableRecordCreateDTO, TableRecord>();
        CreateMap<TableRecordReadDTO, TableRecord>();

    }
}
