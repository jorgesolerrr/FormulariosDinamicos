using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.DTOs;
using FormulariosDinamicosServer.Models;
using FormulariosDinamicosServer.Services;
namespace FormulariosDinamicos.Services.FormService
{
    public interface IFormRepository
    {
        Task<Response<bool>> AddForm(FormDTO newForm);
        Task<Response<bool>> RemoveForm(int id);
        Task<Response<FormDTO>> GetFormById(int id);
        Task<Response<List<FormDTO>>> GetAllForms();
        Task<Response<FormDTO>> UpdateForm(int id,FormUpdateDTO updatedForm);
    }
}