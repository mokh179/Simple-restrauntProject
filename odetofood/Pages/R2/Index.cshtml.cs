using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using odotofood.core;
using odotofood.data;

namespace odetofood.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly odotofood.data.OdetofoodDBcontext _context;

        public IndexModel(odotofood.data.OdetofoodDBcontext context)
        {
            _context = context;
        }

        public IList<Resturaunts> Resturaunts { get;set; }

        public async Task OnGetAsync()
        {
            Resturaunts = await _context.Resturaunt.ToListAsync();
        }
    }
}
