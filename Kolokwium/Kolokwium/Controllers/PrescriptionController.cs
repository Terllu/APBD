using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        private IDbService _service;

        public PrescriptionController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetPrescription(int id)
        {
            var response = _service.GetPrescription(id);

            if(response == null)
            {
                return NotFound("Brak recepty!");
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostReception()
        {

            try
            {
                var response = _service.PostReception();
            }
            catch(Exception ex)
            {
                return NotFound();
            }


            return Ok(response);
        }
    }
}