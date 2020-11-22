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
            //Console.WriteLine("http get ");
            try
            {
                IList<Family> families = await _familyService.GetFamiliesAsync();
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
            Console.WriteLine("here");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("**********8invalid family");
                return BadRequest(ModelState);
            }

            try
            {
                Family added = await _familyService.AddFamilyAsync(family);
                return Created($"/{added.Id}", added);
                // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine("exeption sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
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
        [Route("{streetName}")]
        public async Task<ActionResult> DeleteFamily([FromRoute] string streetName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                await _familyService.RemoveFamilyByStreetNameAsync(streetName);
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