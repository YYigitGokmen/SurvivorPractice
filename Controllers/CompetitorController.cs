using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CompetitorController : ControllerBase
{
    private readonly SurvivorDbContext _context;

    public CompetitorController(SurvivorDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompetitors()
    {
        var competitors = await _context.Competitors.Include(c => c.Category).ToListAsync();
        return Ok(competitors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompetitorById(int id)
    {
        var competitor = await _context.Competitors.FindAsync(id);
        if (competitor == null) return NotFound();
        return Ok(competitor);
    }

    [HttpGet("categories/{categoryId}")]
    public async Task<IActionResult> GetCompetitorsByCategoryId(int categoryId)
    {
        var competitors = await _context.Competitors
            .Where(c => c.CategoryId == categoryId)
            .ToListAsync();
        return Ok(competitors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompetitor(Competitor competitor)
    {
        _context.Competitors.Add(competitor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCompetitorById), new { id = competitor.Id }, competitor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompetitor(int id, Competitor updatedCompetitor)
    {
        if (id != updatedCompetitor.Id) return BadRequest();

        _context.Entry(updatedCompetitor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompetitor(int id)
    {
        var competitor = await _context.Competitors.FindAsync(id);
        if (competitor == null) return NotFound();

        _context.Competitors.Remove(competitor);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
