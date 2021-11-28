using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNPAssignement3API.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace DNPAssignement3API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class FamilyServiceController : ControllerBase
    {

        private IFamilyService familyService;

        public FamilyServiceController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamilies()
        {
            try
            {

                IList<Family> families = await familyService.GetFamilies();
                return Ok(families);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }


        [HttpDelete]
        [Route("{familyId:int}")]
        public async Task<ActionResult> RemoveFamily([FromRoute] int familyId )
        {

            try
            {
                
                await familyService.RemoveFamily(familyId);

                return Ok($"Familey with id: {familyId}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }



        [HttpPost]
        public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
        {

            try
            {
                await familyService.AddFamily(family);

                return Created($"/{family.FamilyId}", family);

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(500, e.Message);


            }
        }

        [HttpGet]
        [Route("{familyId:int}")]
        public async Task<ActionResult<Family>> GetFamily([FromRoute] int familyId)
        {
            
            try
            {

                Family Family = await familyService.GetFamily(familyId);
                return Ok(Family);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        
        
        [HttpPatch]
        public async Task<ActionResult<Family>> UpdateFamily([FromBody] Family family)
        {

            try
            {
                await familyService.Update();
                return null;

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(500, e.Message);


            }
        }
        
        [HttpGet]
        [Route("/adult/{adultId:int}")]
        public async Task<ActionResult<Adult>> GetAdult([FromRoute] int adultId)
        {
            try
            {

                Adult adult = await familyService.GetAdult(adultId);
                return Ok(adult);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpGet]
        [Route("/adults")]
        public async Task<ActionResult<IList<Family>>> GetAdults()
        {
            try
            {
                Console.WriteLine();
                IList<Adult> adult = await familyService.GetAdults();
                return Ok(adult);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        
        
        [HttpDelete]
        [Route("/adult/{adultId:int}")]
        public async Task<ActionResult> RemoveAdult([FromRoute] int adultId )
        {

            try
            {
                
                await familyService.RemoveAdult(adultId);

                return Ok($"adult with id: {adultId} was deleted");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }

        

    }
}