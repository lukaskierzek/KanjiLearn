using KanjiLearn.Server.Data;
using KanjiLearn.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanjiLearn.Server.Controllers
{
    [ApiController]
    [Route("api/kanji")]
    public class KanjiController : ControllerBase
    {
        private readonly KanjiLearnContext _context;

        public KanjiController(KanjiLearnContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kanji>>> GetAllKanji()
        {
            var kanjis = await _context.Kanji
                .Include( k => k.Sentences)
                .Include(k => k.Readings)
                .ToListAsync();
            return kanjis;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kanji>> GetKanji(int id)
        {
            var kanji = await _context.Kanji
                .Include(k => k.Sentences)
                .Include(k => k.Readings)
                .FirstOrDefaultAsync(k => k.Id == id);

            if (kanji == null)
                return NotFound();

            return kanji;
        }
    }
}
