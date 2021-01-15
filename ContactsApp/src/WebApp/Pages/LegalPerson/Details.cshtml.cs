using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Legal
{
    public class DetailsModel : PageModel
    {
        private readonly ILegalPersonService _legalPersonService;
        public DetailsModel(ILegalPersonService legalPersonService)
        {
            _legalPersonService = legalPersonService;
        }

        [BindProperty]
        public LegalPersonModel legalPerson { get; set; }
        public void OnGet(int id)
        {
            legalPerson = _legalPersonService.GetById(id).GetAwaiter().GetResult();
        }

    }
}