using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CloudComputingAllAboutCat.Context;
using CloudComputingAllAboutCat.Model;

namespace CloudComputingAllAboutCat.Pages.FactPages
{
    public class IndexModel : PageModel
    {
        private readonly CloudComputingAllAboutCat.Context.DataContext _context;

        public IndexModel(CloudComputingAllAboutCat.Context.DataContext context)
        {
            _context = context;
        }

        public IList<Fact> Fact { get;set; }

        public async Task OnGetAsync()
        {
            Fact = await _context.Facts.ToListAsync();
        }
    }
}
