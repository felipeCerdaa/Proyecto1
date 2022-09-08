using Microsoft.AspNetCore.WebUtilities;
using Proyecto1.DATOS.Repositorios;
using Proyecto1.DTO;

namespace Proyecto1.NEGOCIO
{
    public class CategoriaNegocio : ICategoriaNegocio
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaNegocio(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }
        public List<CategoriaDTO> ObtenerCategoria()
        {
            var listaCategoriasDTO = new List<CategoriaDTO>();
            var listaCategoriaEntidades = _categoriaRepositorio.ObtenerTodas();
            foreach (var categoria in listaCategoriaEntidades)
            {
                var categoriaDTO = new CategoriaDTO { Id = categoria.Id, Nombre = categoria.Nombre };
                listaCategoriasDTO.Add(categoriaDTO);
            }

            return listaCategoriasDTO;
        }
    }
}
