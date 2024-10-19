using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulariosDinamicosServer.Models;

namespace FormulariosDinamicosServer.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<FieldType, FieldTypeDTO>().ReverseMap();
            CreateMap<FormField, FormFieldDTO>().ReverseMap();
            CreateMap<FormValue, FormValueDTO>().ReverseMap();
            CreateMap<Form, FormDTO>().ReverseMap();
            CreateMap<Form, FormUpdateDTO>().ReverseMap();
            CreateMap<FormField, FormFieldUpdateDTO>().ReverseMap();
        }
    }
    
}