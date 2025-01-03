using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, Counter injectedCounter//Menu injectedMenu
            )
        {
            _logger = logger;
            this._counter = injectedCounter;
            //this.Menu = injectedMenu;
            //step3: request Menu to be injected via Constructor Injection. Use this.Menu to maintain a reference.
        }

        //private Counter _counter = new();
        private Counter _counter; //didn't use "new" this time because I am not creating a entirely new independent instance, otherwise each time _counter
                                  //is created, it will be a brand new one, and they will update independently, such as the "View" always stays as "1"

        /* property */
        public int PageViews => _counter.Count;



        public void OnGet()
        {
            _counter.Count++;
        }
    }
}
