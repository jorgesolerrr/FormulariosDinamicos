using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Models;

namespace FormulariosDinamicosServer.Services.FormFieldService
{
    public interface IFormFieldRepository
    {
        void AddField(FormField newField);
        void RemoveField(int id);
        Task<Result<FormField, Error>> GetFieldById(int id);
        Task<Result<List<FormField>, Error>> GetAllFields();
        Task<Result<FormField, Error>> UpdateField(FormField updatedField);
    }
}