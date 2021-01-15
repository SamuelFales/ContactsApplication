using Contacts.Core.Service.Interfaces;
using Contacts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalPersonController : ControllerBase
    {
        private readonly ILegalPersonService _legalPersonService;
        public LegalPersonController(ILegalPersonService legalPersonService)
        {
            _legalPersonService = legalPersonService;
        }

        [HttpGet("get/{personId}")]
        public async Task<ActionResult<LegalPerson>> GetPerson(int personId)
        {
            var person = await _legalPersonService.GetById(personId);
            return person != null ? Ok(person) : (ActionResult<LegalPerson>)NotFound();
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<LegalPerson>>> GetAll()
        {
            var persons = await _legalPersonService.GetAll();
            return persons != null ? Ok(persons) : (ActionResult<IEnumerable<LegalPerson>>)NotFound();
        }

        [HttpPost("save")]
        public async Task<ActionResult<bool>> Save([FromBody] LegalPerson person)
        {

            var result = await _legalPersonService.Save(person);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> Update([FromBody] LegalPerson person)
        {
            var result = await _legalPersonService.Update(person);
            return Ok(result);
        }

        [HttpPost("delete/{personId}")]
        public ActionResult<bool> Delete(int personId)
        {
            var result = _legalPersonService.Delete(personId);
            return Ok(result);
        }

    }
}