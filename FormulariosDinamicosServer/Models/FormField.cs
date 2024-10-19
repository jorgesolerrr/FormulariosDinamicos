using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Models;


namespace FormulariosDinamicosServer.Models
{
    public class FormField
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FormId { get; set; }

        public Form Form { get; set; } = null!;
                
        public required string Name { get; set; }

        public int FieldTypeId { get; set; }

        public  FieldType Type { get; set; } = null!;

        public bool isRequired { get; set; } = false;
    

    }
}