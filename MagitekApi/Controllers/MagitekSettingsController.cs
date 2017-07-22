using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagitekApi.Database;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagitekApi.Controllers
{
    [Route("/api/[controller]")]
    public class MagitekSettingsController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = context.MagitekSettings.ToList();
            }

            return new OkObjectResult(magitekSettingsList);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] MagitekSettings settings)
        {
            using (var context = MagitekContextFactory.Create())
            {
                var result = context.MagitekSettings.AddAsync(settings).Result;
                return new ObjectResult(result);
            }
        }
    }
}
