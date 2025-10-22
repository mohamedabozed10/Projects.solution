using AutoMapper;
using Pro.BusinessLogic.DTOS.EmployeeDtos;
using Proj.DataAccess.Data.Repositories.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.BusinessLogic.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest=>dest.Gender,options=>options.MapFrom(src=>src.Gender))
               .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
               .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
               .ForMember(dest => dest.HiringDate, options => options.MapFrom(src =>DateOnly.FromDateTime(src.HiringDate)));

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src =>src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDto, Employee>()
                  .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

        }
    }
}
