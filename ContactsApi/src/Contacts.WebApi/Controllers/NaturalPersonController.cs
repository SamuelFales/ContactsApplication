using Contacts.Core.Service.Interfaces;
using Contacts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaturalPersonController : ControllerBase
    {
        private readonly INaturalPersonService _naturalPersonService;
        public NaturalPersonController(INaturalPersonService naturalPersonService)
        {
            _naturalPersonService = naturalPersonService;
        }

        [HttpGet("get/{personId}")]
        public async Task<ActionResult<NaturalPerson>> GetPerson(int personId)
        {
            var person =  await _naturalPersonService.GetById(personId);
            return person != null ? Ok(person) : (ActionResult<NaturalPerson>)NotFound();
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<NaturalPerson>>> GetAll()
        {
            var persons = await _naturalPersonService.GetAll();
            return persons != null ? Ok(persons) : (ActionResult<IEnumerable<NaturalPerson>>)NotFound();
        }

        [HttpPost("save")]
        public async Task<ActionResult<bool>> Save([FromBody] NaturalPerson person)
        {
           
            var result = await _naturalPersonService.Save(person);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> Update([FromBody] NaturalPerson person)
        {
            var result = await _naturalPersonService.Update(person);
            return Ok(result);
        }

        [HttpPost("delete/{personId}")]
        public ActionResult<bool> Delete(int personId)
        {
            var result =  _naturalPersonService.Delete(personId);
            return Ok(result);
        }
    }
}