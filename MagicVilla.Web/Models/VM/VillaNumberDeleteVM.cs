using MagicVilla.Web.Models.Dto.VillaNumber;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla.Web.Models.VM;

public class VillaNumberDeleteVM
{
    public VillaNumberDeleteVM()
    {
        VillaNumber = new VillaNumberDto();
    }
    public VillaNumberDto VillaNumber { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> VillaList { get; set; }
}