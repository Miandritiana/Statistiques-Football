using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StatistiqueFoot.Models;

namespace StatistiqueFoot.Controllers
{
    [ApiController]
    [Route("Defenses")]  // Modifiez le route au niveau de la classe
    [Produces("application/json")]
    public class ViewDefenseController : ControllerBase
    {
        private readonly ILogger<ViewDefenseController> _logger;

        public ViewDefenseController(ILogger<ViewDefenseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("generale")] 
        public IActionResult GetGenerale()
        {
            try
            {
                ViewDefense def = new ViewDefense();

                var DefenseData = def.selectViewDefenseByType("type1");  

                if (DefenseData.Count > 0)
                {
                    return Ok(DefenseData);
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
                ViewDefense def = new ViewDefense();

                var DefenseData = def.selectViewDefenseByType("type2");  

                if (DefenseData.Count > 0)
                {
                    return Ok(DefenseData);
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
                ViewDefense def = new ViewDefense();

                var DefenseData = def.selectViewDefenseByType("type3");  

                if (DefenseData.Count > 0)
                {
                    return Ok(DefenseData);
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
