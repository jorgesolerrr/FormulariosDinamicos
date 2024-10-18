using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Data;
using FormulariosDinamicosServer.Models;

namespace FormulariosDinamicosServer.Services.FormFieldService
{
    public class FormFieldService : IFormFieldRepository
    {
        private readonly DataContext _dataContext;
        public FormFieldService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddField(FormField newField)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<FormField>, Error>> GetAllFields()
        {
            throw new NotImplementedException();
        }

        public Task<Result<FormField, Error>> GetFieldById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveField(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<FormField, Error>> UpdateField(FormField updatedField)
        {
            throw new NotImplementedException();
        }
    }

}