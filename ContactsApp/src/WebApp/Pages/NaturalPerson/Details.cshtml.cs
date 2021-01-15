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

namespace WebApp
{
    public class DetailsModel : PageModel
    {

        private readonly INaturalPersonService _naturalPersonService;
        public DetailsModel(INaturalPersonService naturalPersonService)
        {
            _naturalPersonService = naturalPersonService;
        }

        [BindProperty]
        public NaturalPersonModel naturalPerson { get; set; }
        public void OnGet(int id)
        {
            naturalPerson = _naturalPersonService.GetById(id).GetAwaiter().GetResult();
        }

    }
}