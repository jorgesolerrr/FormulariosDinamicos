using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Models;
using FormulariosDinamicosServer.Services;

namespace FormulariosDinamicos.Services.FormService
{
    public class FormService : IFormRepository
    {
        public void AddForm(Form newForm)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Form>, Error>> GetAllForms()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Form, Error>> GetFormById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveForm(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Form, Error>> UpdateForm(Guid id, Form updatedForm)
        {
            throw new NotImplementedException();
        }
    }
}