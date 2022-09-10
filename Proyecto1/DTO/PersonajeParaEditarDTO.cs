using System.ComponentModel.DataAnnotations;

namespace Proyecto1.DTO
{
	public class PersonajeParaEditarDTO
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo NOMBRE es requerido")]
        public string Nombre { get; set; }
        public string? NombreReal { get; set; }
        public string? SuperPoder { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una CATEGORIA")]
        public int? CategoriaId { get; set; }
        public string? ImagenUrl { get; set; }
    }
}
