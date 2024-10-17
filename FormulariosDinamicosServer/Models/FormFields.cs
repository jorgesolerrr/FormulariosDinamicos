using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormulariosDinamicos.Models
{
    public class FormFields
    {
        public int id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }

        [Required]
        public required string Type { get; set; }
        
    }
}