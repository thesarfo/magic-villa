using static MagicVilla_Utility.SD;

namespace MagicVilla.Web.Models;

public class ApiRequest
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    
    public string Url { get; set; }
    
    public object Data { get; set; }
    
    public string Token { get; set; }

    public ContentType ContentType { get; set; } = ContentType.Json;

}