using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StatistiqueFoot.Models;

namespace StatistiqueFoot.Controllers
{
    [ApiController]
    [Route("Generales")]  // Modifiez le route au niveau de la classe
    [Produces("application/json")]
    public class ViewGeneraleController : ControllerBase
    {
        private readonly ILogger<ViewGeneraleController> _logger;

        public ViewGeneraleController(ILogger<ViewGeneraleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("generale")] 
        public IActionResult GetGenerale()
        {
            try
            {
                ViewGenerale def = new ViewGenerale();

                var GeneraleData = def.selectViewGeneraleByType("type1");  

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

        [HttpGet]
        [Route("domicile")] 
        public IActionResult GetDomicile()
        {
            try
            {
                ViewGenerale def = new ViewGenerale();

                var GeneraleData = def.selectViewGeneraleByType("type2");  

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
        [HttpGet]
        [Route("exterieur")] 
        public IActionResult GetExterieur()
        {
            try
            {
                ViewGenerale def = new ViewGenerale();

                var GeneraleData = def.selectViewGeneraleByType("type3");  

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
