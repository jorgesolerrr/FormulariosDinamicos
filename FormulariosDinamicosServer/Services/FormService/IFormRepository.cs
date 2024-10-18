using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Models;
using FormulariosDinamicosServer.Services;
namespace FormulariosDinamicos.Services.FormService
{
    public interface IFormRepository
    {
        void AddForm(Form newForm);
        void RemoveForm(int id);
        Task<Result<Form,Error>> GetFormById(Guid id);
        Task<Result<List<Form>, Error>> GetAllForms();
        Task<Result<Form,Error>> UpdateForm(Guid id,Form updatedForm);
    }
}