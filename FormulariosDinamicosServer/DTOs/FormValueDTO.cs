using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulariosDinamicosServer.DTOs
{
    public class FormValueDTO
    {
        public int Id { get; set; }

        public int FormId { get; set; }
        public required string Value { get; set; }
    }

    

}