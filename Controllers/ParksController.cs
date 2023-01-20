using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class ParksController : ControllerBase
  {
    private readonly ParksApiContext _db;

    public ParksController(ParksApiContext db)
    {
      _db = db;
    }

    // GET api/Parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get([FromQuery] string location, string state, string type)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }

      if (type != null)
      {
        query = query.Where(entry => entry.Type == type);
      }

      return await query.ToListAsync();
    }

    // GET: api/Parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }
      return park;
    }

    // POST: api/Parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    //PUT: api/Parks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }
      _db.Parks.Update(park);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }

    // DELETE: api/Parks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      if ( park == null )
      {
        return NotFound();
      }
      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}