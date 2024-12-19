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
    public class CategoryController : ControllerBase
    {
        private readonly SurvivorContext _context;

        // Dependency Injection: SurvivorContext sınıfını alır ve _survivorContext değişkenine atar
        public CategoryController(SurvivorContext context)
        {
            _context = context;
        }

        // GET api/category 
        // Tüm kategorileri getirir
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() { 
            // Tüm kategorileri veritabanından asenkron olarak getirir
            return await _context.Categories.ToListAsync(); 
        }

        // GET api/category/{id}
        // Belirli bir kategori ID'sine göre kategori getirir
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            // Verilen ID'ye göre kategoriyi bulur
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            // Eğer kategori bulunamazsa NotFound() döner
            if (category is null)
                return NotFound();

            return category;// Kategoriyi döner
        }

        // POST api/category 
        // Yeni bir kategori ekler
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(CategoryDtos categoryDto)
        {
            // DTO'dan yeni bir Category nesnesi oluşturur
            var category = new Category 
            { 
                Name = categoryDto.Name, 
                CreatedDate = DateTime.Now, 
                ModifiedDate = DateTime.Now, 
                IsDeleted = false 
            };

            // Yeni kategoriyi veritabanına ekler
            _context.Categories.Add(category);
            // Değişiklikleri kaydeder
            await _context.SaveChangesAsync();

            // Yeni eklenen kategoriyi döner
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT api/category/{id} 
        // Var olan bir kategoriyi günceller
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, CategoryDtos categoryDto)
        {
 
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                return NotFound();

            category.Name = categoryDto.Name;
            category.ModifiedDate = DateTime.Now;


            // Kategoriye değişiklikleri uygular
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // Değişiklikleri kaydeder
            }
            catch (DbUpdateConcurrencyException)
            {
                // Güncellenmek istenen kategori mevcut değilse NotFound() döner
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                    throw;
            }
            // Başarılı olursa NoContent() döner
            return NoContent();
        }


        // DELETE api/category/{id} 
        // Belirli bir kategori ID'sine göre kategori siler
        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteCategory(int id) 
        {
            // Verilen ID'ye göre kategoriyi bulur
            var category = await _context.Categories.FindAsync(id); 
            if (category == null) // Eğer kategori bulunamazsa NotFound() döner
            { 
                return NotFound(); 
            }

            // Kategoriyi veritabanından siler
            _context.Categories.Remove(category); 
            await _context.SaveChangesAsync(); 
            return NoContent(); 
        }

        // Belirli bir kategori ID'sinin var olup olmadığını kontrol eder
        private bool CategoryExists(int id) 
        { 
            return _context.Categories.Any(e => e.Id == id);
        }

    }
}
