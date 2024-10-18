using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicos.Services.FormService;
using FormulariosDinamicosServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulariosDinamicosServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IFormRepository _formRepository;

        public FormController(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }
        private static Form testForm = new Form();

        [HttpGet]
        public ActionResult<Form> Get()
        {
            return Ok(testForm);
        }

    }
}