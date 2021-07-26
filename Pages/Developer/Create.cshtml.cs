using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Projects.Data;
using Online_Projects.Models;

namespace Online_Projects.Pages.Developer
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
            return Page();
        }

        [BindProperty]
        public Developers Developers { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Developers.Add(Developers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
