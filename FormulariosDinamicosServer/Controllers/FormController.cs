using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulariosDinamicos.Services.FormService;
using FormulariosDinamicosServer.DTOs;
using FormulariosDinamicosServer.Models;
using FormulariosDinamicosServer.Services;
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

        [HttpPost]
        public async Task<ActionResult<Response<bool>>> AddFormAsync(FormDTO formDTO)
        {
            var result = await _formRepository.AddForm(formDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return StatusCode(500, result.Message);

        }

        [HttpGet]
        public async Task<ActionResult<Response<List<FormDTO>>>> GetAllFormsAsync()
        {
            var result = await _formRepository.GetAllForms();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, result.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<FormDTO>>> GetFormByIdAsync(int id)
        {
            var result = await _formRepository.GetFormById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, result.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<bool>>> UpdateFormAsync(int id, FormUpdateDTO formDTO)
        {
            var result = await _formRepository.UpdateForm(id, formDTO);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, result.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> RemoveFormAsync(int id)
        {
            var result = await _formRepository.RemoveForm(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, result.Message);
            }
        }



    }
}