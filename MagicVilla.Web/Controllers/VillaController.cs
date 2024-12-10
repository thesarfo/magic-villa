using AutoMapper;
using MagicVilla_Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Dto.Villa;
using MagicVilla.Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
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

            var response = await _villaService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDto model)
        {
            if (ModelState.IsValid)
            {

                var response = await _villaService.CreateAsync<ApiResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
{
                    TempData["success"] = "Villa created successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateVilla(int villaId)
{
            var response = await _villaService.GetAsync<ApiResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                
                VillaDto model = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaUpdateDto>(model));
            }
            return NotFound();
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Villa updated successfully";
                var response = await _villaService.UpdateAsync<ApiResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            var response = await _villaService.GetAsync<ApiResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                VillaDto model = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDto model)
        {
            
                var response = await _villaService.DeleteAsync<ApiResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                TempData["success"] = "Villa deleted successfully";
                return RedirectToAction(nameof(IndexVilla));
                }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
}