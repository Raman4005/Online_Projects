using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Projects.Data;
using Online_Projects.Models;

namespace Online_Projects.Pages.Developer
{
    public class DeleteModel : PageModel
    {
        private readonly Online_Projects.Data.Online_ProjectsContext _context;

        public DeleteModel(Online_Projects.Data.Online_ProjectsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Developers Developers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Developers = await _context.Developers.FirstOrDefaultAsync(m => m.Id == id);

            if (Developers == null)
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

            Developers = await _context.Developers.FindAsync(id);

            if (Developers != null)
            {
                _context.Developers.Remove(Developers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
