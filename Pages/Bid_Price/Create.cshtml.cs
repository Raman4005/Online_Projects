using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Projects.Data;
using Online_Projects.Models;

namespace Online_Projects.Pages.Bid_Price
{
    public class CreateModel : PageModel
    {
        private readonly Online_Projects.Data.Online_ProjectsContext _context;

        public CreateModel(Online_Projects.Data.Online_ProjectsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeveloperId"] = new SelectList(_context.Developers, "Id", "Name");
        ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectTitle");
            return Page();
        }

        [BindProperty]
        public Bids Bids { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bids.Add(Bids);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
