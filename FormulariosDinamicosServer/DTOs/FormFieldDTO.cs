using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Models;

namespace FormulariosDinamicosServer.DTOs
{
    public class FormFieldDTO
    {

        public int FormId { get; set; }
                
        public required string Name { get; set; }

        public FieldTypeDTO? Type { get; set; }

        public bool isRequired { get; set; } = false;
    }

    public class FormFieldUpdateDTO
    {
        public required string Name { get; set; }

        public FieldTypeDTO? Type { get; set; }

        public bool isRequired { get; set; } = false;
    }
    
}