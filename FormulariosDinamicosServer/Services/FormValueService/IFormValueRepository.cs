using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.DTOs;

namespace FormulariosDinamicosServer.Services.FormValueService
{
    public interface IFormValueRepository
    {
        Task<Response<bool>> AddForm(FormValueDTO newForm);
        Task<Response<bool>> RemoveForm(int id);
    }
}