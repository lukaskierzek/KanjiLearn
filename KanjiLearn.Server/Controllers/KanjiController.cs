using KanjiLearn.Server.Data;
using KanjiLearn.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanjiLearn.Server.Controllers
{
    [ApiController]
    [Route("api/kanji")]
    public class KanjiController : ControllerBase
    {
        private readonly KanjiLearnContext _dbContext;

        public KanjiController(KanjiLearnContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kanji>>> Get()
        {
            var kanjis = await _dbContext.Kanji
                .Include( k => k.Sentences)
                .Include(k => k.Readings)
                .ToListAsync();
            return kanjis;
        }
    }
}
