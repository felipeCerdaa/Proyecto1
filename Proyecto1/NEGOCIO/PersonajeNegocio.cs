using Proyecto1.DATOS.Repositorios;
using Proyecto1.DTO;

namespace Proyecto1.NEGOCIO
{
	public class PersonajeNegocio : IPersonajeNegocio 
	{
		private readonly IPersonajeRepositorio _personajeRepositorio;

		public PersonajeNegocio(IPersonajeRepositorio personajeRepositorio)
		{
			_personajeRepositorio = personajeRepositorio;
		}
		public List<PersonajeDTO> ObtenerTodos()
		{
			var listaDTO = new List<PersonajeDTO>();
			var listaEntidades = _personajeRepositorio.ObtenerTodos();
			foreach (var entidad in listaEntidades)
			{
				var nuevoPersonajeDTO = new PersonajeDTO()
				{
					Id = entidad.Id,
					Categoria = entidad.Categoria,
					FechaNacimiento = entidad.FechaNacimiento,
					Nombre = entidad.Nombre,
				};
				listaDTO.Add(nuevoPersonajeDTO);
			}

			return listaDTO;
		}
	}
}
