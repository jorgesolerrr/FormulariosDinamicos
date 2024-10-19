using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulariosDinamicosServer.Data;
using FormulariosDinamicosServer.DTOs;
using FormulariosDinamicosServer.Models;
using FormulariosDinamicosServer.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace FormulariosDinamicos.Services.FormService
{
    public class FormService : IFormRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public FormService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Response<bool>> AddForm(FormDTO newForm)
        {
            var form = _mapper.Map<Form>(newForm);

            foreach (var field in form.Fields)
            {
                var existingType = await _dataContext.FieldTypes.FirstOrDefaultAsync(t => t.Id == field.Type.Id);
                if (existingType != null)
                {
                    field.Type = existingType;
                }
            }

            await _dataContext.Forms.AddAsync(form);
            var result = await _dataContext.SaveChangesAsync();

            if (result > 0)
            {
                return new Response<bool> { Data = true, Success = true, Message = "Form added successfully." };
            }
            else
            {
                return new Response<bool> { Data = false, Success = false, Message = "Failed to add form." };
            }
        }

        public async Task<Response<List<FormDTO>>> GetAllForms()
        {
            var forms = await _dataContext.Forms.Include(f => f.Fields)
                                                .ThenInclude(t => t.Type)
                                                .Include(f => f.FormValues)
                                                .ToListAsync();
            var formDTOs = _mapper.Map<List<FormDTO>>(forms);

            return new Response<List<FormDTO>>
            {
                Data = formDTOs,
                Success = true,
                Message = "Forms retrieved successfully."
            };
        }

        public async Task<Response<FormDTO>> GetFormById(int id)
        {
            var form = await _dataContext.Forms.Include(f => f.Fields)
                                            .ThenInclude(t => t.Type)
                                            .Include(f => f.FormValues)
                                            .FirstOrDefaultAsync(f => f.Id == id);

            if (form is null)
            {
                return new Response<FormDTO>
                {
                    Data = null,
                    Success = false,
                    Message = "Form not found."
                };
            }

            var formDTO = _mapper.Map<FormDTO>(form);

            return new Response<FormDTO>
            {
                Data = formDTO,
                Success = true,
                Message = "Form retrieved successfully."
            };
        }

        public async Task<Response<bool>> RemoveForm(int id)
        {
            var form = await _dataContext.Forms.FindAsync(id);

            if (form is null)
            {
                return new Response<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Form not found."
                };
            }

            _dataContext.Forms.Remove(form);
            var result = await _dataContext.SaveChangesAsync();

            if (result > 0)
            {
                return new Response<bool>
                {
                    Data = true,
                    Success = true,
                    Message = "Form removed successfully."
                };
            }
            else
            {
                return new Response<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Failed to remove form."
                };
            }
        }

        public async Task<Response<FormDTO>> UpdateForm(int id, FormUpdateDTO updatedForm)
        {
            var form = await _dataContext.Forms
                               .FirstOrDefaultAsync(f => f.Id == id);

            if (form is null)
            {
                return new Response<FormDTO>
                {
                    Data = null,
                    Success = false,
                    Message = "Form not found."
                };
            }

            _mapper.Map(updatedForm, form);

            
            _dataContext.Forms.Update(form);
            var result = await _dataContext.SaveChangesAsync();

            if (result > 0)
            {
                var formDTO = _mapper.Map<FormDTO>(await _dataContext.Forms.Include(f => f.Fields)
                                            .ThenInclude(t => t.Type)
                                            .Include(f => f.FormValues)
                                            .FirstOrDefaultAsync(f => f.Id == id));
                return new Response<FormDTO>
                {
                    Data = formDTO,
                    Success = true,
                    Message = "Form updated successfully."
                };
            }
            else
            {
                return new Response<FormDTO>
                {
                    Data = null,
                    Success = false,
                    Message = "Failed to update form."
                };
            }
        }
    }
}