using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.DTOs;

namespace FormulariosDinamicosServer.Services.FormFieldService
{
    public interface IFormFieldRepository
    {
        Task<Response<bool>> AddFormField(FormFieldDTO newFormField);
        Task<Response<bool>> RemoveFormField(int id);
        Task<Response<FormFieldDTO>> UpdateFormField(int id, FormFieldUpdateDTO updatedFormField);
    }
}