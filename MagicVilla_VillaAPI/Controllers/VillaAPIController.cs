using System.Collections.Generic;
using System.Linq;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace MagicVilla_VillaAPI.Controllers;

[Route("api/villaAPI")]
[ApiController]
public class VillaApiController : ControllerBase
{
    private readonly ILogger<VillaApiController> _logger;
    private readonly ApplicationDbContext _db;

    public VillaApiController(ILogger<VillaApiController> logger, ApplicationDbContext db)
    {
        this._logger = logger;
        this._db = db;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public  ActionResult<IEnumerable<VillaDto>> GetVillas()
    {
        _logger.LogInformation("Getting All Villas");
        return Ok(_db.Villas.ToList());
    }
    
    [HttpGet("{id:int}", Name="GetVilla")]
    // [ProducesResponseType(200, Type = typeof(VillaDTO))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VillaDto> GetVilla(int id)
    {
        if (id == 0)
        {
            _logger.LogError("Failed getting villa with id " + id);
            return BadRequest();
        }

        var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
         if (villa == null)
         {
             return NotFound();
         }
        return Ok(villa);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
    {

        if (_db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDto.Name.ToLower()) != null)
        {
            ModelState.AddModelError("CustomEror", "Villa already Exists!");
            return BadRequest(ModelState);
        }
        
        if (villaDto == null)
        {
            return BadRequest(villaDto);
        }

        if (villaDto.Id > 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        Villa model = new Villa()
        {
            Id = villaDto.Id,
            Name = villaDto.Name,
            Details = villaDto.Details,
            Rate = villaDto.Rate,
            Sqft =  villaDto.Sqft,
            Occupancy = villaDto.Occupancy,
            ImageUrl = villaDto.ImageUrl,
            Amenity = villaDto.Amenity,
        };
        _db.Villas.Add(model);
        _db.SaveChanges();
        
        return CreatedAtRoute("GetVilla", new {id = villaDto.Id}, villaDto);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:int}", Name = "DeleteVilla")]
    public IActionResult DeleteVilla(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }
        var villa = _db.Villas.FirstOrDefault(u => u.Id == id);

       if (villa == null)
        {
            return NotFound();
        }

        _db.Villas.Remove(villa);
        _db.SaveChanges();
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:int}", Name = "UpdateVilla")]
    public IActionResult UpdateVilla(int id, [FromBody]VillaDto villaDto)
    {
        if (villaDto == null || id != villaDto.Id)
        {
            return BadRequest();
        }
        
        Villa model = new Villa()
        {
            Id = villaDto.Id,
            Name = villaDto.Name,
            Details = villaDto.Details,
            Rate = villaDto.Rate,
            Sqft =  villaDto.Sqft,
            Occupancy = villaDto.Occupancy,
            ImageUrl = villaDto.ImageUrl,
            Amenity = villaDto.Amenity,
        };
        _db.Villas.Update(model);
        _db.SaveChanges();
        return NoContent();

    }

    [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
    {
        if (patchDto == null || id == 0)
        {
            return BadRequest();
        }
        var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
        
        VillaDto villaDto = new VillaDto()
        {
            Id = villa.Id,
            Name = villa.Name,
            Details = villa.Details,
            Rate = villa.Rate,
            Sqft =  villa.Sqft,
            Occupancy = villa.Occupancy,
            ImageUrl = villa.ImageUrl,
            Amenity = villa.Amenity,
        };
        if (villa == null)
        {
            return BadRequest();
        }
        patchDto.ApplyTo(villaDto, ModelState);
        Villa model = new Villa()
        {
            Id = villaDto.Id,
            Name = villaDto.Name,
            Details = villaDto.Details,
            Rate = villaDto.Rate,
            Sqft =  villaDto.Sqft,
            Occupancy = villaDto.Occupancy,
            ImageUrl = villaDto.ImageUrl,
            Amenity = villaDto.Amenity,
        };
        _db.Villas.Update(model);
        _db.SaveChanges();
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return NoContent();

    }
        
}