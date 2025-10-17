using AutoMapper;
using BEFinal.Dtos;
using BEFinal.Models;

namespace BEFinal.Mappings
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<ExamCreateDto, Exam>();
            CreateMap<ExamUpdateDto, Exam>();
            CreateMap<Exam, ExamResponseDto>();
        }
    }
}
