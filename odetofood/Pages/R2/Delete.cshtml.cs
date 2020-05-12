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
    public class DeleteModel : PageModel
    {
        private readonly odotofood.data.OdetofoodDBcontext _context;

        public DeleteModel(odotofood.data.OdetofoodDBcontext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resturaunts = await _context.Resturaunt.FindAsync(id);

            if (Resturaunts != null)
            {
                _context.Resturaunt.Remove(Resturaunts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
