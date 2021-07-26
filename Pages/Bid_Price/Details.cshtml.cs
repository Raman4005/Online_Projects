using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Projects.Data;
using Online_Projects.Models;

namespace Online_Projects.Pages.Bid_Price
{
    public class DetailsModel : PageModel
    {
        private readonly Online_Projects.Data.Online_ProjectsContext _context;

        public DetailsModel(Online_Projects.Data.Online_ProjectsContext context)
        {
            _context = context;
        }

        public Bids Bids { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bids = await _context.Bids
                .Include(b => b.Developer)
                .Include(b => b.Project).FirstOrDefaultAsync(m => m.Id == id);

            if (Bids == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
