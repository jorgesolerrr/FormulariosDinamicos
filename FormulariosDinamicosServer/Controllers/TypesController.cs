using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.DTOs;
using FormulariosDinamicosServer.Services.TypeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FormulariosDinamicosServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ILogger<TypeController> _logger;
        private readonly ITypeRepository _typeRepository;

        public TypeController(ILogger<TypeController> logger, ITypeRepository typeRepository)
        {
            _logger = logger;
            _typeRepository = typeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypes()
        {
            var response = await _typeRepository.GetAllTypes();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var response = await _typeRepository.GetTypeById(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddType(FieldTypeDTO newType)
        {
            var response = await _typeRepository.AddType(newType);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        
    }
}