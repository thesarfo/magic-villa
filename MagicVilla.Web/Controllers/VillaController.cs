using AutoMapper;
using MagicVilla_Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Dto.Villa;
using MagicVilla.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla.Web.Controllers;

public class VillaController : Controller
{
    private readonly IVillaService _villaService;
    private readonly IMapper _mapper;

    public VillaController(IVillaService villaService, IMapper mapper)
    {
        _villaService = villaService;
        _mapper = mapper;
    }

    public async Task<IActionResult> IndexVilla()
    {
        List<VillaDto> list = new();
        
        var response = await _villaService.GetAllAsync<ApiResponse>();
        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result));
        }
        return View(list);
    }
    
    
    public async Task<IActionResult> CreateVilla()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateVilla(VillaCreateDto model)
    {
        if (ModelState.IsValid)
        {

            var response = await _villaService.CreateAsync<ApiResponse>(model);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa created successfully";
                return RedirectToAction(nameof(IndexVilla));
            }
        }
        TempData["error"] = "Error encountered.";
        return View(model);
    }
}