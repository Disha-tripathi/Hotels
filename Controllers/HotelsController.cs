using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("hotels")]
public class HotelsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public HotelsController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _context.Hotels.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        return hotel == null ? NotFound() : Ok(hotel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Hotel hotel)
    {
        _context.Hotels.Add(hotel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = hotel.HotelId }, hotel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Hotel hotel)
    {
        if (id != hotel.HotelId) return BadRequest();
        _context.Entry(hotel).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel == null) return NotFound();
        _context.Hotels.Remove(hotel);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpGet("count")]
    public async Task<IActionResult> GetCount()
    {
        var count = await _context.Hotels.CountAsync();
        return Ok(new { Count = count });
    }

}
