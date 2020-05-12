using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using odotofood.core;
using odotofood.data;

namespace odetofood.Pages.R2
{
    public class EditModel : PageModel
    {
        private readonly odotofood.data.OdetofoodDBcontext _context;

        public EditModel(odotofood.data.OdetofoodDBcontext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Resturaunts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResturauntsExists(Resturaunts.ID))
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

        private bool ResturauntsExists(int id)
        {
            return _context.Resturaunt.Any(e => e.ID == id);
        }
    }
}
