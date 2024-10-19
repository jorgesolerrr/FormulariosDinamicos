using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulariosDinamicosServer.Data;
using FormulariosDinamicosServer.DTOs;
using FormulariosDinamicosServer.Models;

namespace FormulariosDinamicosServer.Services.FormValueService
{
    public class FormValueService : IFormValueRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FormValueService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<bool>> AddForm(FormValueDTO newForm)
        {
            var formEntity = _mapper.Map<FormValue>(newForm);
            await _context.FormValues.AddAsync(formEntity);
            var result = await _context.SaveChangesAsync() > 0;
            return new Response<bool> { Data = result, Success = result };
        }

        public async Task<Response<bool>> RemoveForm(int id)
        {
            var formEntity = await _context.FormValues.FindAsync(id);
            if (formEntity == null)
            {
                return new Response<bool> { Data = false, Success = false, Message = "Form not found" };
            }

            _context.FormValues.Remove(formEntity);
            var result = await _context.SaveChangesAsync() > 0;
            return new Response<bool> { Data = result, Success = result };
        }
    }
}