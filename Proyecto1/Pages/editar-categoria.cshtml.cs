using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.DTO;
using Proyecto1.NEGOCIO;
using System.ComponentModel.DataAnnotations;

namespace Proyecto1.Pages
{
    public class editar_categoriaModel : PageModel
    {
        private readonly ICategoriaNegocio _categoriaNegocio;

        public editar_categoriaModel(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        [Required(ErrorMessage ="El campo NOMBRE es requerido")]
        public string Nombre { get; set; }
        public void OnGet(int id)
        {
            var categoriaDTO = _categoriaNegocio.ObtenerCategoriaPorId(id);
            Nombre = categoriaDTO.Nombre;
            Id = id;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var categoria = new CategoriaDTO { Id = Id, Nombre = Nombre };
                _categoriaNegocio.ActualizarCategoria(categoria);
                return RedirectToPage("./categorias");
            }

            return Page();
        }
    }
}
