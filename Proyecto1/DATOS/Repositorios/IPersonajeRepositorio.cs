using Proyecto1.DATOS.Entidades;

namespace Proyecto1.DATOS.Repositorios
{
	public interface IPersonajeRepositorio
	{
		void ActualizarPersonaje(Personaje personaje);
		void CrearPersonaje(Personaje personaje);
		void EliminarPersonaje(int id);
		Personaje ObtenerPorId(int id);
		List<Personaje> ObtenerTodos();
	}
}
