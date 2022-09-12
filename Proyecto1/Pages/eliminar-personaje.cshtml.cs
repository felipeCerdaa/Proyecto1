using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.NEGOCIO;

namespace Proyecto1.Pages
{
    public class eliminar_personajeModel : PageModel
    {
        private readonly IPersonajeNegocio _personajeNegocio;

        public eliminar_personajeModel(IPersonajeNegocio personajeNegocio)
        {
            _personajeNegocio = personajeNegocio;
        }
        [BindProperty]
        public int Id { get; set; }
        public void OnGet(int id)
        {
            Id = id;
        }

        public IActionResult OnPost()
        {
            _personajeNegocio.EliminarPersonaje(Id);
            return RedirectToPage("./personajes");
        }
    }
}
