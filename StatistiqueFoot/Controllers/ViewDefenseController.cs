using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StatistiqueFoot.Models;

namespace StatistiqueFoot.Controllers
{
    [ApiController]
    [Route("ViewDefenseController")]
    [Produces("application/json")]
    public class ViewDefenseController : ControllerBase
    {
        private readonly ILogger<ViewDefenseController> _logger;

        public ViewDefenseController(ILogger<ViewDefenseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ViewDefenses")]
        public List<ViewDefense> Get()
        {
            ViewDefense def = new ViewDefense();

            List<ViewDefense> ViewDefenseData = def.selectViewDefense();

            return ViewDefenseData;
        }

        [HttpGet]
        [Route("ViewDefense/{idType}")]
        public IActionResult GetByType(string idType)
        {
            try
            {
                ViewDefense def = new ViewDefense();

                var DefenseData = def.selectViewDefenseByType(idType);

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
