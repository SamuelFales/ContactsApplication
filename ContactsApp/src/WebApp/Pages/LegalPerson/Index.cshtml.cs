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

namespace WebApp.Legal
{
    public class IndexModel : PageModel
    {
        private readonly ILegalPersonService _legalPersonService; 
        public IndexModel(ILegalPersonService legalPersonService)
        {
            _legalPersonService = legalPersonService;
        }

        [BindProperty]
        public IEnumerable<LegalPersonModel> legalPersons { get; set; }
        [BindProperty]
        public LegalPersonModel person { get; set; }

        [TempData]
        public string Message { get; set; }


        public void OnGet()
        {
            legalPersons = _legalPersonService.GetAll().GetAwaiter().GetResult();
        }

        public IActionResult OnPostAsync(LegalPersonModel person)
        {
            try
            {
              
                var postResult = _legalPersonService.Save(person).GetAwaiter().GetResult();

                if (postResult)
                    return RedirectToPage("Index");
                else
                {
                    Message = "Error on insert new person";
                    return RedirectToPage("Index");
                }
            }
            catch
            {
                Message = "Error on insert new person.";
                return RedirectToPage("Index");
            }
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            {
                var postResult = _legalPersonService.Delete(id);

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