using MagicVilla.Web.Models.Dto.VillaNumber;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla.Web.Models.VM;

public class VillaNumberUpdateVM
{

    public VillaNumberUpdateVM()
    {
        VillaNumber = new VillaNumberUpdateDto();
    }

    public VillaNumberUpdateDto VillaNumber { get; set; }
    
    [ValidateNever]
    public IEnumerable<SelectListItem> VillaList { get; set; }
}