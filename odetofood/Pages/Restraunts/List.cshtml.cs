using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using odotofood.data;
using odotofood.core;
using Microsoft.Extensions.Logging;

namespace odetofood.Pages.Restraunts
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
            //class in odo.core
        public IEnumerable<Resturaunts> AllRest { get; set; }
        //this property to 
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        //to get all configuration of appconfig
        private readonly IConfiguration Config;
        private readonly IRestaurantData Data;
        private readonly ILogger<ListModel> logger;
        public ListModel(IConfiguration config , IRestaurantData ResData,ILogger<ListModel> logger)
        {
            this.Config = config;
            this.Data = ResData;
            this.logger = logger;
        }
        public void OnGet()
        {
            //to show data from appconfig to cshtml
            Message = Config["Message"];
            logger.LogError("Exec process");
            AllRest = Data.GetDatabyname(SearchTerm);
        }
    }
}