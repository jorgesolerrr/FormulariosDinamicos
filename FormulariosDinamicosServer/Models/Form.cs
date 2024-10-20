using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormulariosDinamicosServer.Models
{
    public class Form
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public ICollection<FormField> Fields { get; set; } = new List<FormField>();
        public ICollection<FormValue> FormValues { get; set; } = new List<FormValue>(); 
    }
}