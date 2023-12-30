﻿using KanjiLearn.Server.Data;
using KanjiLearn.Server.Models;
using KanjiLearn.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanjiLearn.Server.Controllers
{
    [ApiController]
    [Route("api/kanji")]
    public class KanjiController : ControllerBase
    {
        private readonly IKanjiService _kanjiService;
        private readonly KanjiLearnContext _context;

        public KanjiController(KanjiLearnContext dbContext, IKanjiService kanjiSerrvice)
        {
            _kanjiService = kanjiSerrvice;
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kanji>>> GetAllKanji()
        {
            var kanji = await _context.Kanji
                .Include(k => k.Sentences)
                .Include(k => k.Readings)
                .ToListAsync();

            var kanjiDTOs = _kanjiService.GetAllKanji(kanji);

            return Ok(kanjiDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kanji>> GetKanji([FromRoute] int id)
        {
            var kanji = await _context.Kanji
                .Include(k => k.Sentences)
                .Include(k => k.Readings)
                .FirstOrDefaultAsync(k => k.Id == id);

            var kanjiDTO = _kanjiService.GetKanji(kanji);

            if (kanjiDTO == null)
                return NotFound();

            return Ok(kanjiDTO);
        }
    }
}
