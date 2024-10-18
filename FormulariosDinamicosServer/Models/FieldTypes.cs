using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FormulariosDinamicosServer.Models
{
    public class FieldType
    {
        public int id { get; set; }

        public required string Name { get; set; }

        public ICollection<FormField> Fields { get; set; } = new List<FormField>();

    }
}