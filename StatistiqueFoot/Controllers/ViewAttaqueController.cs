using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StatistiqueFoot.Models;

namespace StatistiqueFoot.Controllers
{
    [ApiController]
    [Route("Attaques")]  // Modifiez le route au niveau de la classe
    [Produces("application/json")]
    public class ViewAttaqueController : ControllerBase
    {
        private readonly ILogger<ViewAttaqueController> _logger;

        public ViewAttaqueController(ILogger<ViewAttaqueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("generale")] 
        public IActionResult GetGenerale()
        {
            try
            {
                ViewAttaque def = new ViewAttaque();

                var attaqueData = def.selectViewAttaqueByType("type1");  

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

        [HttpGet]
        [Route("domicile")] 
        public IActionResult GetDomicile()
        {
            try
            {
                ViewAttaque def = new ViewAttaque();

                var attaqueData = def.selectViewAttaqueByType("type2");  

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
        [HttpGet]
        [Route("exterieur")] 
        public IActionResult GetExterieur()
        {
            try
            {
                ViewAttaque def = new ViewAttaque();

                var attaqueData = def.selectViewAttaqueByType("type3");  

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
