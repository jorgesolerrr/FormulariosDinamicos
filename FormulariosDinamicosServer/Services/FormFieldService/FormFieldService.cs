using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulariosDinamicosServer.Data;
using FormulariosDinamicosServer.DTOs;
using FormulariosDinamicosServer.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulariosDinamicosServer.Services.FormFieldService
{
    public class FormFieldService : IFormFieldRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public FormFieldService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }


        public async Task<Response<bool>> AddFormField(FormFieldDTO newFormField)
        {
            var response = new Response<bool>();

            var formField = _mapper.Map<FormField>(newFormField);
            try
            {
                if (newFormField.Type == null)
                {
                    response.Data = false;
                    response.Success = false;
                    response.Message = "Field type is required.";
                    return response;
                }

                var existingType = await _dataContext.FieldTypes.AsNoTracking().FirstOrDefaultAsync(t => t.Id == newFormField.Type.Id);
                if (existingType == null)
                {
                    response.Data = false;
                    response.Success = false;
                    response.Message = "Field type not found.";
                    return response;
                }
                formField.FieldTypeId = existingType.Id;
                formField.Type = null;

                await _dataContext.Fields.AddAsync(formField);
                await _dataContext.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Form field added successfully.";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<bool>> RemoveFormField(int id)
        {
            var response = new Response<bool>();

            try
            {
                var formField = await _dataContext.Fields.FindAsync(id);
                if (formField == null)
                {
                    response.Data = false;
                    response.Success = false;
                    response.Message = "Form field not found.";
                    return response;
                }

                _dataContext.Fields.Remove(formField);
                await _dataContext.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Form field removed successfully.";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<FormFieldDTO>> UpdateFormField(int id, FormFieldUpdateDTO updatedFormField)
        {
            var response = new Response<FormFieldDTO>();

            try
            {
                var formField = await _dataContext.Fields.FindAsync(id);
                if (formField == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Form field not found.";
                    return response;
                }
                if (updatedFormField.Type == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Field type is required.";
                    return response;
                }

                var existingType = await _dataContext.FieldTypes.AsNoTracking().FirstOrDefaultAsync(t => t.Id == updatedFormField.Type.Id);
                if (existingType == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Field type not found.";
                    return response;
                }

                updatedFormField.Type = _mapper.Map<FieldTypeDTO>(existingType);
                _mapper.Map(updatedFormField, formField);
                _dataContext.Fields.Update(formField);
                await _dataContext.SaveChangesAsync();

                var formFieldDTO = _mapper.Map<FormFieldDTO>(formField);
                response.Data = formFieldDTO;
                response.Success = true;
                response.Message = "Form field updated successfully.";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }
    }
}