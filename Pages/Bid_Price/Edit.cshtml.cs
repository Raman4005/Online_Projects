using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Projects.Data;
using Online_Projects.Models;

namespace Online_Projects.Pages.Bid_Price
{
    public class EditModel : PageModel
    {
        private readonly Online_Projects.Data.Online_ProjectsContext _context;

        public EditModel(Online_Projects.Data.Online_ProjectsContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DeveloperId"] = new SelectList(_context.Developers, "Id", "Name");
           ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectTitle");
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

            _context.Attach(Bids).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidsExists(Bids.Id))
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

        private bool BidsExists(int id)
        {
            return _context.Bids.Any(e => e.Id == id);
        }
    }
}
