using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vinoteca.Core;
using Vinoteca.Data;

namespace Vinoteca.Controllers
{
    [Route("api/[controller]")]
    public class VinosController : Controller
    {
        
        private readonly IVinotecaData _VinotecaData;
        public VinosController(IVinotecaData VinotecaData)
        {
            _VinotecaData = VinotecaData;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Vino>> Get()
        {
            try
            {
                return Ok(_VinotecaData.GetAllVinos());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get products");
            }
        }
    }
}