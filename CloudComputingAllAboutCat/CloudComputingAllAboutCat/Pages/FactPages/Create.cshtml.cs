using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CloudComputingAllAboutCat.Context;
using CloudComputingAllAboutCat.Model;

namespace CloudComputingAllAboutCat.Pages.FactPages
{
    public class CreateModel : PageModel
    {
        private readonly CloudComputingAllAboutCat.Context.DataContext _context;

        public CreateModel(CloudComputingAllAboutCat.Context.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fact Fact { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Facts.Add(Fact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
