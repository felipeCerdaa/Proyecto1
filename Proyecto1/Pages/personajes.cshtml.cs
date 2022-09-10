using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.DTO;
using Proyecto1.NEGOCIO;

namespace Proyecto1.Pages
{
    public class personajesModel : PageModel
    {
        private readonly IPersonajeNegocio _personajeNegocio;

        public personajesModel(IPersonajeNegocio personajeNegocio)
        {
            _personajeNegocio = personajeNegocio;
        }
        public List<PersonajeDTO> Personajes { get; set; }
        public void OnGet()
        {
            Personajes = _personajeNegocio.ObtenerTodos();
        }
    }
}
