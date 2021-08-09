using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CloudComputingAllAboutCat.Data;
using CloudComputingAllAboutCat.Models;
using Newtonsoft.Json;

namespace CloudComputingAllAboutCat.Pages.Facts
{
    public class IndexModel : PageModel
    {
        private readonly FactDbContext _context;

        private string dogFactUrl = "https://dog-facts-api.herokuapp.com/api/v1/resources/dogs/all";

        public IndexModel(FactDbContext context)
        {
            _context = context;
        }

        public IList<Fact> Facts { get;set; }

        public async Task OnGetAsync()
        {
            Facts = await _context.Facts.ToListAsync();

            if (Facts.Count == 0)
            {
                string json = new System.Net.WebClient().DownloadString(dogFactUrl);
                var factsResponse = JsonConvert.DeserializeObject<List<FactsResponse>>(json);
                foreach (var item in factsResponse)
                {

                    var fact = item.fact;
                    Fact a = new Fact()
                    {
                        FactText = fact
                    };
                    _context.Facts.Add(a);
 
                };

                await _context.SaveChangesAsync();

                Facts = await _context.Facts.ToListAsync();
            }
        }
    }
}
