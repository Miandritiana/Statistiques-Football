using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StatistiqueFoot.Models;

namespace StatistiqueFoot.Controllers
{
    [ApiController]
    [Route("ViewAttaqueController")]
    [Produces("application/json")]
    public class ViewAttaqueController : ControllerBase
    {
        private readonly ILogger<ViewAttaqueController> _logger;

        public ViewAttaqueController(ILogger<ViewAttaqueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ViewAttaques")]
        public List<ViewAttaque> Get()
        {
            ViewAttaque def = new ViewAttaque();

            List<ViewAttaque> ViewAttaqueData = def.selectViewAttaque();

            return ViewAttaqueData;
        }

        [HttpGet]
        [Route("ViewAttaque/{idType}")]
        public IActionResult GetByType(string idType)
        {
            try
            {
                ViewAttaque def = new ViewAttaque();

                var attaqueData = def.selectViewAttaqueByType(idType);

                if (attaqueData.Count > 0)
                {
                    return Ok(attaqueData); 
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
