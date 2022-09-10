using Proyecto1.DATOS.Entidades;
using System.Data.SqlClient;

namespace Proyecto1.DATOS.Repositorios
{
	public class PersonajeRepositorio : IPersonajeRepositorio
	{
		private readonly IConfiguration _configuration;

		public PersonajeRepositorio(IConfiguration configuration)
		{
			_configuration = configuration;
		}
        public List<Personaje> ObtenerTodos()
        {
            var listaPersonajes = new List<Personaje>();
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_obtener_personajes", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevaPersonaje = new Personaje
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? null : (DateTime)reader["FechaNacimiento"],
                        Categoria = reader["Categoria"].ToString() 
                    };
                    listaPersonajes.Add(nuevaPersonaje);
                }
            }

            return listaPersonajes;
        }

        public void CrearPersonaje(Personaje personaje)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_insertar_personaje", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", personaje.Nombre));
            cmd.Parameters.Add(new SqlParameter("@nombreReal", personaje.NombreReal == null ? DBNull.Value : personaje.NombreReal));
            cmd.Parameters.Add(new SqlParameter("@superPoder", personaje.SuperPoder == null ? DBNull.Value : personaje.SuperPoder));
            cmd.Parameters.Add(new SqlParameter("@fechaNacimiento", personaje.FechaNacimiento == null ? DBNull.Value : personaje.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("@categoriaId", personaje.CategoriaId));
            cmd.Parameters.Add(new SqlParameter("@imagenUrl", personaje.ImagenUrl == null ? DBNull.Value : personaje.ImagenUrl));
            sql.Open();
            cmd.ExecuteNonQuery();
        }

        public Personaje ObtenerPorId(int id)
        {
            var personaje = new Personaje();
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_obtener_personaje_por_id", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoPersonaje = new Personaje 
                    { 
                        Id = (int)reader["Id"], 
                        Nombre = reader["Nombre"].ToString(),
                        NombreReal = reader["NombreReal"].ToString(),
                        SuperPoder = reader["SuperPoder"].ToString(),
                        FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? null : Convert.ToDateTime (reader["FechaNacimiento"]),
                        CategoriaId = (int)reader["CategoriaId"],
                        ImagenUrl = reader["ImagenUrl"].ToString()
                    };
                    personaje = nuevoPersonaje;
                }
            }

            return personaje;
        }

        public void ActualizarPersonaje(Personaje personaje)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_actualizar_personaje", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", personaje.Nombre));
            cmd.Parameters.Add(new SqlParameter("@nombreReal", personaje.NombreReal == null ? DBNull.Value : personaje.NombreReal));
            cmd.Parameters.Add(new SqlParameter("@superPoder", personaje.SuperPoder == null ? DBNull.Value : personaje.SuperPoder));
            cmd.Parameters.Add(new SqlParameter("@fechaNacimiento", personaje.FechaNacimiento == null ? DBNull.Value : personaje.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("@categoriaId", personaje.CategoriaId));
            cmd.Parameters.Add(new SqlParameter("@imagenUrl", personaje.ImagenUrl == null ? DBNull.Value : personaje.ImagenUrl));
            sql.Open();
            cmd.ExecuteNonQuery();
        }

        public void EliminarPersonaje(int id)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_eliminar_personaje", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
