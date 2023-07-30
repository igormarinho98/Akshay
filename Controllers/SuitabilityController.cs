namespace Akshay.Controllers;

using Akshay.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


        [Route("[controller]")]
        [ApiController]
        public class SuitabilityController : ControllerBase
        {
            private static List<Suitability> suitabilityList = new List<Suitability>();


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(suitabilityList);
            
        }

        [HttpPost]
        public IActionResult AddSuitability(Suitability suitability)
        {
            suitabilityList.Add(suitability);
            return CreatedAtAction(nameof(GetAll), null);
        }


    }