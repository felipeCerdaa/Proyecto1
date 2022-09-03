using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.NEGOCIO;

namespace Proyecto1.Pages
{
    public class TestModel : PageModel
    {
        private readonly Icalculo _calculo;

        public TestModel(Icalculo calculo)
        {
            _calculo = calculo;
        }

        [BindProperty]
        public int numero1 { get; set; }
        [BindProperty]
        public int numero2 { get; set; }
        [BindProperty]
        public int? Resultado { get; set; }
        public void OnGet()
        {
            //this.numero1 = 123;
            //this.numero2 = 321;
        }
        public void OnPost() 
        {
              var resultado = _calculo.Operacion(this.numero1, this.numero2);
        }
    }
}
