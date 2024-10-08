using AutoMapper;
using ExpenseManager.Models.Entities;
using ExpenseManager.Service.Dtos.ExpenseDetails;
using ExpenseManager.Service.Dtos.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for ExpenseDetail
            CreateMap<ExpenseDetail, ExpenseDetailResponseDto>();  // Entity to DTO
            CreateMap<ExpenseDetailCreateDto, ExpenseDetail>();    // DTO to Entity

            // Mapping for Expense
            CreateMap<Expense, ExpenseResponseDto>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))  // Directly map EmployeeId
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.ExpenseDetails.Sum(ed => ed.Amount))) // Calculate total amount
                .ForMember(dest => dest.ExpenseDetails, opt => opt.MapFrom(src => src.ExpenseDetails)); // Map collection

            CreateMap<ExpenseCreateDto, Expense>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId)) // Map EmployeeId as string
                .ForMember(dest => dest.SubmissionDate, opt => opt.MapFrom(src => src.SubmissionDate)) // Map SubmissionDate
                .ForMember(dest => dest.Employee, opt => opt.Ignore());  // Ignore Employee navigation property

        }
    }
}
