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
    public class EditModel : PageModel
    {

        private readonly INaturalPersonService _naturalPersonService;
        public EditModel(INaturalPersonService naturalPersonService)
        {
            _naturalPersonService = naturalPersonService;
        }

        [BindProperty]
        public NaturalPersonModel naturalPerson { get; set; }
        [TempData]
        public string Message { get; set; }
        public void OnGet(int id)
        {
            naturalPerson = _naturalPersonService.GetById(id).GetAwaiter().GetResult();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                Message = messages;
                return Page();
            }

            try
            {
                var postResult = _naturalPersonService.Update(naturalPerson).GetAwaiter().GetResult();

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

    }
}