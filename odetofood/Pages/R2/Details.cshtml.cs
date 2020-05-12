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
    public class DetailsModel : PageModel
    {
        private readonly odotofood.data.OdetofoodDBcontext _context;

        public DetailsModel(odotofood.data.OdetofoodDBcontext context)
        {
            _context = context;
        }

        public Resturaunts Resturaunts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resturaunts = await _context.Resturaunt.FirstOrDefaultAsync(m => m.ID == id);

            if (Resturaunts == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
