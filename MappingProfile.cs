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

        CreateMap<ProductCreateDTO, Products>();
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();
        CreateMap<BranchDTO, Branch>();
        CreateMap<Branch, BranchDTO>();
    }
}
