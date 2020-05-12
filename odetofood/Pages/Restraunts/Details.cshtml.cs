 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;
using odotofood.core;
using odotofood.data;

namespace odetofood.Pages.Restraunts
{
    public class DetailsModel : PageModel
    {
        public Resturaunts Restraunt { set; get; }
        public IEnumerable<Resturaunts>  RestName { set; get; }
        private readonly IRestaurantData Data;
        public DetailsModel(IRestaurantData Da)
        {
            this.Data = Da;
        }
        public IActionResult OnGet(int id)
        {

            Restraunt = Data.GetDatabyID(id);
            if (Restraunt==null)
            {
               return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}