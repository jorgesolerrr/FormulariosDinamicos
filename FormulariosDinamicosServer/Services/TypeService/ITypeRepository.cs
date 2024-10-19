using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulariosDinamicosServer.DTOs;

namespace FormulariosDinamicosServer.Services.TypeService
{
    public interface ITypeRepository
    {
        Task<Response<bool>> AddType(FieldTypeDTO newType);
        Task<Response<FieldTypeDTO>> GetTypeById(int id);
        Task<Response<List<FieldTypeDTO>>> GetAllTypes();
    }
}