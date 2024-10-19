using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace FormulariosDinamicosServer.Models
{
    public class FieldType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public ICollection<FormField> Fields { get; set; } = new List<FormField>();

    }
}