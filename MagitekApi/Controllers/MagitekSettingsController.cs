using System.Collections.Generic;
using System.Linq;
using MagitekApi.Database;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagitekApi.Controllers
{
    [Route("/api/[controller]")]
    public class MagitekSettingsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllSettings()
        {
            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = context.MagitekSettings.ToList();
            }

            return new OkObjectResult(magitekSettingsList);
        }
    }
}
