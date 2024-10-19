using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulariosDinamicosServer.Data;
using FormulariosDinamicosServer.DTOs;
using FormulariosDinamicosServer.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulariosDinamicosServer.Services.TypeService
{
    public class TypeService : ITypeRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public TypeService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Response<bool>> AddType(FieldTypeDTO newType)
        {
            var response = new Response<bool>();

            try
            {
                var fieldType = _mapper.Map<FieldType>(newType);
                await _dataContext.FieldTypes.AddAsync(fieldType);
                await _dataContext.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Type added successfully.";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<List<FieldTypeDTO>>> GetAllTypes()
        {
            var response = new Response<List<FieldTypeDTO>>();

            try
            {
                var fieldTypes = await _dataContext.FieldTypes.ToListAsync();
                var fieldTypeDTOs = _mapper.Map<List<FieldTypeDTO>>(fieldTypes);

                response.Data = fieldTypeDTOs;
                response.Success = true;
                response.Message = "Types retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<FieldTypeDTO>> GetTypeById(int id)
        {
            var response = new Response<FieldTypeDTO>();

            try
            {
            var fieldType = await _dataContext.FieldTypes.FindAsync(id);
            if (fieldType == null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Type not found.";
            }
            else
            {
                var fieldTypeDTO = _mapper.Map<FieldTypeDTO>(fieldType);
                response.Data = fieldTypeDTO;
                response.Success = true;
                response.Message = "Type retrieved successfully.";
            }
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