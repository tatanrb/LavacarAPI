using System.ComponentModel.DataAnnotations;

namespace LavacarAPI.DTOs
{
    public class CrearNivelClienteDTO
    {
        public int NivelClienteID { get; set; }
        [Required(ErrorMessage = "El nombre del nivel de cliente es obliatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El detalle del beneficio es obligatorio")]
        public string Beneficio { get; set; }
    }
}
