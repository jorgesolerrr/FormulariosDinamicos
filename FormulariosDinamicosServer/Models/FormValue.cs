using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormulariosDinamicosServer.Models
{
    public class FormValue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FormId { get; set; }
        public virtual Form Form { get; set; } = null!;
        public required string Value { get; set; }
    }
}