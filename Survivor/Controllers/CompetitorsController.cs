using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor.Data;
using Survivor.Dtos;
using Survivor.Models;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        public readonly SurvivorContext _survivorContext;

        public CompetitorsController(SurvivorContext survivorContext) // dependies injection çalıacak
        {
            _survivorContext = survivorContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competitors>>> GetCompetitors()
        {
            return await _survivorContext.Competitors.ToListAsync();
        }

        // GET api/competitors/{id}
        // Belirli bir yarışmacı ID'sine göre yarışmacı getirir
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitorWithCategoryDto>> GetById(int id)
        {
            var result = await _survivorContext.Competitors
                .Where(c => c.Id == id)
                .Select(c => new CompetitorWithCategoryDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate,
                    IsDeleted = c.IsDeleted,
                    CategoryName = c.Category.Name,
                })
                .FirstOrDefaultAsync();

            if(result is null) 
                return NotFound();
            
            return Ok(result);
        }


        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<IEnumerable<CompetitorWithCategoryDto>>> GetCompetitorsByCategoryId(int categoryId)
        {
            var competitors = await _survivorContext.Competitors
                .Where(c => c.CategoryId == categoryId)
                .Select(c => new CompetitorWithCategoryDto 
                { 
                    Id = c.Id, 
                    FirstName = c.FirstName, 
                    LastName = c.LastName, 
                    CreatedDate = c.CreatedDate, 
                    ModifiedDate = c.ModifiedDate, 
                    IsDeleted = c.IsDeleted, 
                    CategoryName = c.Category.Name 
                }).ToListAsync();

            if (competitors == null || !competitors.Any()) 
            { 
                return NotFound(); 
            }

            return Ok(competitors);
        }

        // POST api/competitors
        // Yeni bir yarışmacı ekler
        [HttpPost]
        public async Task<ActionResult<Competitors>> AddCompetitors(CompetitorDtos competitorDtos)
        {
            // Yeni yarışmacıyı DTO'dan alınan verilere göre oluşturur
            var competitor = new Competitors
            {
                FirstName = competitorDtos.FirstName,
                LastName = competitorDtos.LastName,
                CategoryId = competitorDtos.CategoryId,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsDeleted = false
            };

            _survivorContext.Competitors.Add(competitor);
            await _survivorContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = competitor.Id }, competitor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetitor(int id, CompetitorDtos competitorDtos)
        {
            var competitor = await _survivorContext.Competitors.FindAsync(id);
            if(competitor == null) return NotFound();


            //DTO'dan gelen verilerler yarışmacıyı günceller
            competitor.FirstName = competitorDtos.FirstName;
            competitor.LastName = competitorDtos.LastName;
            competitor.CategoryId = competitorDtos.CategoryId;

            await _survivorContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _survivorContext.Competitors.FirstOrDefaultAsync(x => x.Id == id);
            if(competitor == null) return NotFound();   

            _survivorContext.Competitors.Remove(competitor);
            await _survivorContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
