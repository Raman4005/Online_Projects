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

namespace Online_Projects.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly Online_Projects.Data.Online_ProjectsContext _context;

        public EditModel(Online_Projects.Data.Online_ProjectsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client.FirstOrDefaultAsync(m => m.Id == id);

            if (Client == null)
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

            _context.Attach(Client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(Client.Id))
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

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}
