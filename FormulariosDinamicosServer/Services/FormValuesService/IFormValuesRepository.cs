using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.Models;

namespace FormulariosDinamicosServer.Services.FormValuesService
{
    public interface IFormValuesRepository
    {
        void AddFormValue(FormValue newFormValue);
        void RemoveFormValue(int id);
        Task<Result<FormValue, Error>> GetFormValueById(int id);
        Task<Result<List<FormValue>, Error>> GetAllFormValues();
    }
}