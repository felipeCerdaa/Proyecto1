using Proyecto1.DTO;

namespace Proyecto1.NEGOCIO
{
    public interface ICategoriaNegocio
    {
        List<CategoriaDTO> ObtenerCategoria();
        void CrearCategoria(CategoriaDTO categoriaDTO);
        CategoriaDTO ObtenerCategoriaPorId(int id);
		void ActualizarCategoria(CategoriaDTO categoriaDTO);
		void EliminarCategoria(int id);
	}
}
