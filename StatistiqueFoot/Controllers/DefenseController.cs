using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StatistiqueFoot.Models;

namespace StatistiqueFoot.Controllers
{
    [ApiController]
    [Route("DefenseController")]
    [Produces("application/json")]
    public class DefenseController : ControllerBase
    {
        private readonly ILogger<DefenseController> _logger;

        public DefenseController(ILogger<DefenseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Defense")]
        public List<Defense> Get()
        {
            Defense def = new Defense();

            List<Defense> DefenseData = def.selectDefense();

            return DefenseData;
        }
    }
}
