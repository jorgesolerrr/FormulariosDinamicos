using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulariosDinamicosServer.DTOs
{
    public class FormDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public ICollection<FormFieldDTO> Fields { get; set; } = new List<FormFieldDTO>();
    
        public ICollection<FormValueDTO> FormValues { get; set; } = new List<FormValueDTO>();
    }

    public class FormUpdateDTO
    {
        public required string Name { get; set; }
        public string Description { get; set; } = "";

    }
    
}