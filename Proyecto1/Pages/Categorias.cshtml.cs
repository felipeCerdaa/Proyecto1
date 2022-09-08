using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.DTO;
using Proyecto1.NEGOCIO;

namespace Proyecto1.Pages
{
    public class CategoriasModel : PageModel
    {
        public List<CategoriaDTO> Categorias { get; set; }

        private readonly ICategoriaNegocio _categoriaNegocio;

        public CategoriasModel(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }

        public void OnGet()
        {
            Categorias = _categoriaNegocio.ObtenerCategoria();
        }
    }
}
