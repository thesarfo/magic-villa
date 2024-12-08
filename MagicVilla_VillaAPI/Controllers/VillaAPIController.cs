using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers;

[Route("api/villaAPI")]
[ApiController]
public class VillaApiController : ControllerBase
{
    private readonly ILogger<VillaApiController> _logger;
    private readonly IVillaRepository _dbVilla;
    private readonly IMapper _mapper;

    public VillaApiController(ILogger<VillaApiController> logger, IMapper mapper, IVillaRepository dbVilla)
    {
        _logger = logger;
        _mapper = mapper;
        _dbVilla = dbVilla;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public  async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
    {
        _logger.LogInformation("Getting All Villas");
        IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
        return Ok(_mapper.Map<List<VillaDto>>(villaList));
    }
    
    [HttpGet("{id:int}", Name="GetVilla")]
    // [ProducesResponseType(200, Type = typeof(VillaDTO))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VillaDto>> GetVilla(int id)
    {
        if (id == 0)
        {
            _logger.LogError("Failed getting villa with id " + id);
            return BadRequest();
        }

        var villa = await _dbVilla.GetAsync(u => u.Id == id);
         if (villa == null)
         {
             return NotFound();
         }
        return Ok(_mapper.Map<VillaDto>(villa));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<VillaDto>> CreateVilla([FromBody] VillaCreateDto createDto)
    {

        if (await _dbVilla.GetAsync(u => u.Name.ToLower() == createDto.Name.ToLower()) != null)
        {
            ModelState.AddModelError("CustomEror", "Villa already Exists!");
            return BadRequest(ModelState);
        }
        
        if (createDto == null)
        {
            return BadRequest(createDto);
        }

        Villa model = _mapper.Map<Villa>(createDto);
        
        await _dbVilla.CreateAsync(model);
        
        return CreatedAtRoute("GetVilla", new {id = model.Id}, model);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id:int}", Name = "DeleteVilla")]
    public async Task<IActionResult> DeleteVilla(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }
        var villa = await _dbVilla.GetAsync(u => u.Id == id);

       if (villa == null)
        {
            return NotFound();
        }

       _dbVilla.RemoveAsync(villa);
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id:int}", Name = "UpdateVilla")]
    public async Task<IActionResult> UpdateVilla(int id, [FromBody]VillaUpdateDto updateDto)
    {
        if (updateDto == null || id != updateDto.Id)
        {
            return BadRequest();
        }
        
        Villa model = _mapper.Map<Villa>(updateDto);
        
        await _dbVilla.UpdateAsync(model);
        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
    {
        if (patchDto == null || id == 0)
        {
            return BadRequest();
        }
        var villa = await _dbVilla.GetAsync(u => u.Id == id, tracked:false);
        
        VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);
        if (villa == null)
        {
            return BadRequest();
        }
        patchDto.ApplyTo(villaDto, ModelState);
        Villa model = _mapper.Map<Villa>(villaDto);
        
        await _dbVilla.UpdateAsync(model);
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return NoContent();

    }
        
}