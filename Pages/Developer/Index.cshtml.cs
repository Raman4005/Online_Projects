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
    public class IndexModel : PageModel
    {
        private readonly Online_Projects.Data.Online_ProjectsContext _context;

        public IndexModel(Online_Projects.Data.Online_ProjectsContext context)
        {
            _context = context;
        }

        public IList<Developers> Developers { get;set; }

        public async Task OnGetAsync()
        {
            Developers = await _context.Developers.ToListAsync();
        }
    }
}
