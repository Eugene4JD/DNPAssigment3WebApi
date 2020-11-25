using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNPAssigment1.Data;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace FamilyWebAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private IFamilyService _familyService;

        public FamilyController(IFamilyService familyService)
        {
            this._familyService = familyService;
        }


        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamilies()
        {
            try
            {
                var families = await _familyService.GetFamiliesAsync();
                return Ok(families);
            }
            catch (Exception e)
            { 
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> AddFamily([FromBody] Family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Family added = await _familyService.AddFamilyAsync(family);
                return Ok(added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Family>> UpdateFamily([FromBody] Family family)
        {
            try
            {
                Console.WriteLine(family);
                Family updatedFamily = await _familyService.UpdateFamilyAsync(family);
                return Ok(updatedFamily);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteFamily([FromQuery] string streetName,[FromQuery] int houseNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                await _familyService.RemoveFamilyAsync(streetName,houseNumber);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}