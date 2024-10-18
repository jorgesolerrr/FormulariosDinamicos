using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulariosDinamicosServer.Models
{
    public class FormValue
    {
        public Guid id { get; set; }
        public int FormId { get; set; }
        public virtual Form Form { get; set; } = null!;
        public required string Value { get; set; }
    }
}