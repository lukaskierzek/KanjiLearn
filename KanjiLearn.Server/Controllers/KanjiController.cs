using KanjiLearn.Server.Models;
using KanjiLearn.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace KanjiLearn.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KanjiController : ControllerBase
    {
        private readonly ILogger<KanjiController> _logger;
        private readonly IKanjiService _kanjiService;

        public KanjiController(ILogger<KanjiController> logger, IKanjiService kanjiService)
        {
            _logger = logger;
            _kanjiService = kanjiService;
        }

        [HttpGet]
        public IEnumerable<Kanji> Get()
        {
            var result = _kanjiService.Get();
            return result;
        }
    }
}
