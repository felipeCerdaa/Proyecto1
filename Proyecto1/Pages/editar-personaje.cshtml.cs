using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1.DTO;
using Proyecto1.NEGOCIO;

namespace Proyecto1.Pages
{
    public class editar_personajeModel : PageModel
    {
        private readonly IPersonajeNegocio _personajeNegocio;

        public editar_personajeModel(IPersonajeNegocio personajeNegocio)
        {
            _personajeNegocio = personajeNegocio;
        }
        public PersonajeParaEditarDTO Personaje { get; set; }
        public SelectList Categorias { get; set; }
        public void OnGet(int id)
        {
            var personajeParaEditarDTO = _personajeNegocio.ObtenerPersonajePorId(id);
            Personaje = personajeParaEditarDTO;
            Categorias = _personajeNegocio.ObtenerCategoriasLista();
        }
    }
}
