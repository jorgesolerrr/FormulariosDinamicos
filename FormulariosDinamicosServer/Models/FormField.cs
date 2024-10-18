using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Models;


namespace FormulariosDinamicosServer.Models
{
    public class FormField
    {
        public Guid id { get; set; }

        public int FormId { get; set; }

        public Form Form { get; set; } = null!;
                
        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }

        public int FieldTypeId { get; set; }

        public  FieldType Type { get; set; } = null!;

        public bool isRequired { get; set; } = false;
    

    }
}