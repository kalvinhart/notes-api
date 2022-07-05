using AutoMapper;
using NotesApi.DTOs.Categories;
using NotesApi.DTOs.Notes;
using NotesApi.Models;

namespace NotesApi.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<EditCategoryDTO, Category>();

            CreateMap<CreateNoteDTO, Note>();
            CreateMap<UpdateNoteDTO, Note>();
        }
    }
}
