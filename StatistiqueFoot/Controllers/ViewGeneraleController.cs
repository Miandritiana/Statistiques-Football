using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StatistiqueFoot.Models;

namespace StatistiqueFoot.Controllers
{
    [ApiController]
    [Route("ViewGeneraleController")]
    [Produces("application/json")]
    public class ViewGeneraleController : ControllerBase
    {
        private readonly ILogger<ViewGeneraleController> _logger;

        public ViewGeneraleController(ILogger<ViewGeneraleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ViewGenerales")]
        public List<ViewGenerale> Get()
        {
            ViewGenerale def = new ViewGenerale();

            List<ViewGenerale> ViewGeneraleData = def.selectViewGenerale();

            return ViewGeneraleData;
        }

        [HttpGet]
        [Route("ViewGenerale/{idType}")]
        public IActionResult GetByType(string idType)
        {
            try
            {
                ViewGenerale def = new ViewGenerale();

                var GeneraleData = def.selectViewGeneraleByType(idType);

                if (GeneraleData.Count > 0)
                {
                    return Ok(GeneraleData); 
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Une erreur s'est produite : {ex}");
                return StatusCode(500, "Erreur interne du serveur"); 
            }
        }
    }
}
