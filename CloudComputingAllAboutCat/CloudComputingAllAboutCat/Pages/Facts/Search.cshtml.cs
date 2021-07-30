using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CloudComputingAllAboutCat.Pages.Facts
{
    public class SearchModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;



        public SearchModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            //_context = context;

        }

        public void OnGet()
        {
        }

    
    }
}
