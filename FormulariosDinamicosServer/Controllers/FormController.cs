using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicos.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulariosDinamicos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private static Form testForm = new Form();

        [HttpGet]
        public ActionResult<Form> Get()
        {
            return Ok(testForm);
        }

    }
}