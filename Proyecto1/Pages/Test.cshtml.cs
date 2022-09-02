using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Proyecto1.Pages
{
    public class TestModel : PageModel
    {
        [BindProperty]
        public int? numero1 { get; set; }
        [BindProperty]
        public int? numero2 { get; set; }
        public void OnGet()
        {
            //this.numero1 = 123;
            //this.numero2 = 321;
        }
        public void OnPost() 
        {
        
        }
    }
}
