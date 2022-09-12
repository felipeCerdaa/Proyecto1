using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.DTO;
using Proyecto1.NEGOCIO;

namespace Proyecto1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonajeNegocio _personajeNegocio;

        public IndexModel(ILogger<IndexModel> logger,IPersonajeNegocio personajeNegocio)
        {
            _logger = logger;
            _personajeNegocio = personajeNegocio;
        }

        public List<PersonajeParaGuardarDTO> Personajes { get; set; }
        public void OnGet()
        {
            Personajes = _personajeNegocio.ObtenerTodosIndex();
        }
    }
}