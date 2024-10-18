using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Models;

namespace FormulariosDinamicosServer.Schemas
{
    public class FormDTO
    {
        public Guid id { get; set; }
        public required string Name {get; set;}
        public string Description { get; set; } = "";
        ICollection<FormFieldDTO> Fields { get; set; } = new List<FormFieldDTO>();

        


    }
}