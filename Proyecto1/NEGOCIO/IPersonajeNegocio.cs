using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1.DTO;

namespace Proyecto1.NEGOCIO
{
	public interface IPersonajeNegocio
	{
		void CrearPersonaje(PersonajeParaGuardarDTO personajeParaGuardarDTO);
        void EliminarPersonaje(int id);
        SelectList ObtenerCategoriasLista();
		PersonajeParaEditarDTO ObtenerPersonajePorId(int id);
		List<PersonajeDTO> ObtenerTodos();
        List<PersonajeParaGuardarDTO> ObtenerTodosIndex();
    }
}
