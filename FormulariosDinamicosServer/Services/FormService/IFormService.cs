using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicos.Models;
namespace FormulariosDinamicos.Services.FormService
{
    public interface IFormService
    {
        List<Form> GetAllForms();
        Form GetFormById(int id);
        Form AddForm(Form newForm);

    }
}