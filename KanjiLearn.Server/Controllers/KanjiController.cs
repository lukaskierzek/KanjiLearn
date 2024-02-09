using KanjiLearn.Server.Data;
using KanjiLearn.Server.Models;
using KanjiLearn.Server.Models.Extensions;
using KanjiLearn.Server.ModelsDTO;
using KanjiLearn.Server.Services.KanjiService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanjiLearn.Server.Controllers
{
    [ApiController]
    [Route("api/kanji")]
    public class KanjiController : ControllerBase
    {
        private readonly KanjiLearnContext _context;
        private readonly IKanjiService _kanjiService;
        public KanjiController(KanjiLearnContext dbContext, IKanjiService kanjiService)
        {
            _context = dbContext;
            _kanjiService = kanjiService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kanji>>> GetAllKanji()
        {
            var kanji = await _context.Kanji
                .Include(kanji => kanji.Sentences)
                .Include(kanji => kanji.Readings)
                .ToListAsync();

            var kanjiDTO = _kanjiService.GetAllKanjiDTO(kanji);
            return Ok(kanjiDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kanji>> GetKanji([FromRoute] int id)
        {
            var kanji = await _context.Kanji
                .Include(k => k.Sentences)
                .Include(k => k.Readings)
                .FirstOrDefaultAsync(k => k.Id == id);

            if (kanji.IsNull())
                return NotFound();
            
            var kanjiDTO = _kanjiService.GetKanjiDTO(kanji);

            if (kanjiDTO.IsNull())
                return NotFound();

            return Ok(kanjiDTO);
        }

        [HttpPost]
        public async Task<ActionResult<Kanji>> PostKanji([FromBody] CreateKanjiDTO createKanjiDTO)
        {
            var kanji = _kanjiService.CreateKanji(createKanjiDTO);

            _context.Kanji.Add(kanji);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKanji), new { id = kanji.Id }, kanji);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKanji([FromRoute] int id)
        {
            var kanji = await _context.Kanji.FindAsync(id);

            bool isDeleted = _kanjiService.DeleteKanji(kanji);

            if (!isDeleted)
                return NotFound();

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKanji([FromRoute] int id, [FromBody] UpdateKanjiDTO updateKanjiDTO)
        {
            var kanji = await _context.Kanji
                .Include(k => k.Readings)
                .FirstOrDefaultAsync(k => k.Id == id);

            if (kanji.IsNull())
                return NotFound();

            if (kanji.IsDifferentId(id))
                return BadRequest();

            _kanjiService.UpdateKanjiByKanjiDTO(kanji, id, updateKanjiDTO);
#if DEBUG
            var kanjiState = _context.Entry(kanji).State;
#endif

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var isAnyKanji = _kanjiService.IsAnyKanjiById(id);
                if (isAnyKanji)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }
    }
}
