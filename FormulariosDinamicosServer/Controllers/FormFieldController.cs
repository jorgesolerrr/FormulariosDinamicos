using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.DTOs;
using FormulariosDinamicosServer.Services.FormFieldService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FormulariosDinamicosServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormFieldController : ControllerBase
    {
        private readonly IFormFieldRepository _formFieldRepository;

        public FormFieldController(IFormFieldRepository formFieldRepository)
        {
            _formFieldRepository = formFieldRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddFormField(FormFieldDTO newFormField)
        {
            var response = await _formFieldRepository.AddFormField(newFormField);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFormField(int id)
        {
            var response = await _formFieldRepository.RemoveFormField(id);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFormField(int id, FormFieldUpdateDTO updatedFormField)
        {
            var response = await _formFieldRepository.UpdateFormField(id, updatedFormField);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }
    }
}