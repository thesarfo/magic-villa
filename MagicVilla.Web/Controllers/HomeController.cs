 using AutoMapper;
 using MagicVilla_Utility;
 using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Dto.Villa;
using MagicVilla.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla.Web.Controllers;

public class HomeController : Controller
{
    private readonly IVillaService _villaService;
    private readonly IMapper _mapper;
    
    public HomeController(IVillaService villaService, IMapper mapper)
    {
        _villaService = villaService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        List<VillaDto> list = new();

        var response = await _villaService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString(SD.SessionToken));
        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result));
        }
        return View(list);
    }
       
}