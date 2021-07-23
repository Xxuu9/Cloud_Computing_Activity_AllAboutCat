using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CloudComputingAllAboutCat.Data;
using CloudComputingAllAboutCat.Models;

namespace CloudComputingAllAboutCat.Pages.Facts
{
    public class IndexModel : PageModel
    {
        private readonly CloudComputingAllAboutCat.Data.FactDbContext _context;

        public IndexModel(CloudComputingAllAboutCat.Data.FactDbContext context)
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
