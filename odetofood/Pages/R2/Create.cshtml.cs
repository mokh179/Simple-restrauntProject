using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using odotofood.core;
using odotofood.data;

namespace odetofood.Pages.R2
{
    public class CreateModel : PageModel
    {
        private readonly odotofood.data.OdetofoodDBcontext _context;

        public CreateModel(odotofood.data.OdetofoodDBcontext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Resturaunts Resturaunts { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Resturaunt.Add(Resturaunts);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
