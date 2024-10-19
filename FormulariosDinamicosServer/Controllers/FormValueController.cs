using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.DTOs;
using FormulariosDinamicosServer.Services.FormValueService;
using Microsoft.AspNetCore.Mvc;

namespace FormulariosDinamicosServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormValueController : ControllerBase
    {
        private readonly IFormValueRepository _formValueService;

        public FormValueController(IFormValueRepository formValueService)
        {
            _formValueService = formValueService;
        }

        [HttpPost]
        public async Task<IActionResult> AddForm(FormValueDTO newForm)
        {
            var response = await _formValueService.AddForm(newForm);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveForm(int id)
        {
            var response = await _formValueService.RemoveForm(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}