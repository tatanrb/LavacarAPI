using AutoMapper;
using LavacarAPI.DTOs;
using LavacarAPI.Models;
using LavacarAPI.Repositories;
using LavacarAPI.Utils;

namespace LavacarAPI.Services.Implements
{
    public class NivelClienteService
    {
        private readonly NivelClienteRepository _repository;
        private readonly IMapper _mapper;
        public NivelClienteService(NivelClienteRepository nivelClienteRepository, IMapper mapper)
        {
            _repository = nivelClienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NivelClienteDTO>> ObtenerTodosUsuariosAsync()
        {
            IEnumerable<NivelCliente> nivelClientes = await _repository.ObtenerTodos();

            return _mapper.Map<IEnumerable<NivelClienteDTO>>(nivelClientes);
        }

        public async Task<NivelClienteDTO> ObtenerPorId(int id)
        {
            NivelCliente nivelClientes = await _repository.ObtenerPorId(id);

            return _mapper.Map<NivelClienteDTO>(nivelClientes);
        }

        public async Task<NivelClienteDTO> CrearNivelCliente(NivelClienteDTO dto)
        {
            NivelCliente nivelCliente = await _repository.Crear(dto);

            return _mapper.Map<NivelClienteDTO>(nivelCliente);
        }

        public async Task<NivelClienteDTO> ActualizarNivelCliente(NivelClienteDTO dto)
        {
            bool actualizado = await _repository.Actualizar(dto);

            if (!actualizado)
            {
                return null;
            }

            NivelCliente nivelCliente = await _repository.ObtenerPorId(dto.NivelClienteID);

            return _mapper.Map<NivelClienteDTO>(nivelCliente);
        }
    }
}
