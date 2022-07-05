using AutoMapper;
using NotesApi.DTOs.Categories;
using NotesApi.Models;

namespace NotesApi.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCategoryDTO, Category>();
        }
    }
}
