using System.Net;

namespace MagicVilla_VillaAPI.Models;

public class ApiResponse
{
    public ApiResponse()
    {
        ErrorMessages = new List<string>();
    }
    public HttpStatusCode StatusCode { get; set; }

    public bool IsSuccess => (int)StatusCode >= 200 && (int)StatusCode <= 299;
    
    public List<string> ErrorMessages { get; set; }
    
    public object Result { get; set; }
    
}