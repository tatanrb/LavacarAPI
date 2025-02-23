using LavacarAPI.DTOs;
using LavacarAPI.Responses;
using LavacarAPI.Services.Implements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LavacarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelClienteController : ControllerBase
    {
        private readonly NivelClienteService _service;

        public NivelClienteController(NivelClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<NivelClienteDTO>>>> ObtenerTodos()
        {
            var usuarios = await _service.ObtenerTodosUsuariosAsync();

            if (usuarios == null || usuarios.Count() == 0)
            {
                return NotFound(new ApiResponse<IEnumerable<NivelClienteDTO>>(false, "No se encontraron niveles de cliente", null));
            }

            return Ok(new ApiResponse<IEnumerable<NivelClienteDTO>>(true, "Usuarios obtenidos correctamente", usuarios));
        }

        [HttpGet("id")]
        public async Task<ActionResult<ApiResponse<NivelClienteDTO>>> ObtenerPorId(int id)
        {
            var usuario = await _service.ObtenerPorId(id);

            if (usuario == null)
            {
                return NotFound(new ApiResponse<NivelClienteDTO>(false, $"No se encontró ningún cliente con el id {id}", null));
            }

            return Ok(new ApiResponse<NivelClienteDTO>(true, "Usuario obtenido correctamente", usuario));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<NivelClienteDTO>>> CrearNivelCliente([FromBody] NivelClienteDTO dto)
        {
            var nivelCliente = await _service.CrearNivelCliente(dto);

            if (nivelCliente == null)
            {
                return BadRequest(new ApiResponse<NivelClienteDTO>(false, "No se pudo crear el nivel de cliente", null));
            }

            return Ok(new ApiResponse<NivelClienteDTO>(true, "Nivel de cliente creado con éxito", nivelCliente));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<NivelClienteDTO>>> ActualizarNivelCliente([FromBody] NivelClienteDTO dto)
        {
            NivelClienteDTO nivelClienteActualizado = await _service.ActualizarNivelCliente(dto);

            if (nivelClienteActualizado == null)
            {
                return BadRequest(new ApiResponse<NivelClienteDTO>(false, "No se pudo actualizar el nivel de cliente", null));
            }

            return Ok(new ApiResponse<NivelClienteDTO>(true, "Nivel de cliente actualizado con éxito", nivelClienteActualizado));
        }
    }
}
