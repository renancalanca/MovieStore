using AutoMapper;
using MovieStore.Dto;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //No construtor Gerar o Mapping do DTO para o Model para não ter que fazer na mão sempre.
            // Ele utiliza reflection para fazer esse mapping
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}