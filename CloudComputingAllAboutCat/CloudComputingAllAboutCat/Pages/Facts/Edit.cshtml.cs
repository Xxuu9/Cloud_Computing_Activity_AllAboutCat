using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudComputingAllAboutCat.Data;
using CloudComputingAllAboutCat.Models;

namespace CloudComputingAllAboutCat.Pages.Facts
{
    public class EditModel : PageModel
    {
        private readonly CloudComputingAllAboutCat.Data.FactDbContext _context;

        public EditModel(CloudComputingAllAboutCat.Data.FactDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Fact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactExists(Fact.FactID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FactExists(int id)
        {
            return _context.Facts.Any(e => e.FactID == id);
        }
    }
}
