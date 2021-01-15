using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp
{
    public class IndexModel : PageModel
    {
        private readonly INaturalPersonService _naturalPersonService;
        public IndexModel(INaturalPersonService naturalPersonService)
        {
            _naturalPersonService = naturalPersonService;
        }

        [BindProperty]
        public IEnumerable<NaturalPersonModel> naturalPersons { get; set; }
        [BindProperty]
        public NaturalPersonModel person { get; set; }
        
        [TempData]
        public string Message { get; set; }


        public void OnGet()
        {
            naturalPersons = _naturalPersonService.GetAll().GetAwaiter().GetResult();
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            {
                var postResult = _naturalPersonService.Delete(id);

                if (postResult)
                    Message = "Person deleted with success.";
                else
                    Message = "Error on deleting person.";
            }
            catch
            {
                Message = "Error on deleting person.";
            }

            return RedirectToPage("Index");
        }

    }
}