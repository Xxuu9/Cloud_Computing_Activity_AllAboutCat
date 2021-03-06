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
    public class DeleteModel : PageModel
    {
        private readonly CloudComputingAllAboutCat.Data.FactDbContext _context;

        public DeleteModel(CloudComputingAllAboutCat.Data.FactDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fact Fact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fact = await _context.Facts.FirstOrDefaultAsync(m => m.FactID == id);

            if (Fact == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fact = await _context.Facts.FindAsync(id);

            if (Fact != null)
            {
                _context.Facts.Remove(Fact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
