using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Proyecto1.Pages
{
    public class eliminar_categoriaModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        public void OnGet(int id)
        {
            Id = id;
        }
        public void OnPost()
        {

        }
    }
}
