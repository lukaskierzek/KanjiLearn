using AutoMapper;
using KanjiLearn.Server.Data;
using KanjiLearn.Server.Models;
using KanjiLearn.Server.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanjiLearn.Server.Controllers
{
    [ApiController]
    [Route("api/kanji")]
    public class KanjiController : ControllerBase
    {
        private readonly KanjiLearnContext _context;
        private readonly IMapper _mapper;

        public KanjiController(KanjiLearnContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kanji>>> GetAllKanji()
        {
            var kanji = await _context.Kanji
                .Include(k => k.Sentences)
                .Include(k => k.Readings)
                .ToListAsync();

            var kanjiDTOs = _mapper.Map<List<KanjiDTO>>(kanji);

            return Ok(kanjiDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kanji>> GetKanji([FromRoute] int id)
        {
            var kanji = await _context.Kanji
                .Include(k => k.Sentences)
                .Include(k => k.Readings)
                .FirstOrDefaultAsync(k => k.Id == id);

            if (kanji == null)
                return NotFound();

            var kanjiDTO = _mapper.Map<KanjiDTO>(kanji);   

            return Ok(kanjiDTO);
        }
    }
}
