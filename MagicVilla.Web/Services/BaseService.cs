using System.Net;
using System.Net.Http.Headers;
using System.Text;
using MagicVilla_Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Services.IServices;
using Newtonsoft.Json;

namespace MagicVilla.Web.Services;

public class BaseService : IBaseService
{
    public ApiResponse responseModel { get; set; }
    public IHttpClientFactory httpClient { get; set; }

    public BaseService(IHttpClientFactory httpClient)
    {
        this.responseModel = new();
        this.httpClient = httpClient;
    }


    public async Task<T> SendAsync<T>(ApiRequest apiRequest)
    {
        try
        {
            var client = httpClient.CreateClient("MagicAPI");
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8,
                    "application/json");
            }

            switch (apiRequest.ApiType)
            {
                case SD.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;

                case SD.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;

                case SD.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;

                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            HttpResponseMessage apiResponse = null;
            
            
            apiResponse = await client.SendAsync(message);

            if (!string.IsNullOrEmpty(apiRequest.Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", 
                    apiRequest.Token);
            }
            var apiContent = await apiResponse.Content.ReadAsStringAsync();

            try
            {
                ApiResponse ApiResponse = JsonConvert.DeserializeObject<ApiResponse>(apiContent);
                if (apiResponse.StatusCode == HttpStatusCode.BadRequest ||
                    apiResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    ApiResponse.StatusCode = HttpStatusCode.BadRequest;
                    ApiResponse.IsSuccess = false;
                    var res = JsonConvert.SerializeObject(ApiResponse);
                    var returnObj = JsonConvert.DeserializeObject<T>(res);
                    return returnObj;
                }
            }
            catch (Exception e)
            {
                var exceptionResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return exceptionResponse;
            }
            var ApiResponseObj = JsonConvert.DeserializeObject<T>(apiContent);
            return ApiResponseObj;
        }
        catch (Exception e)
        {
            var dto = new ApiResponse()
            {
                ErrorMessages = new List<string>() { Convert.ToString(e.Message) },
                IsSuccess = false,
            };
            var res = JsonConvert.SerializeObject(dto);
            var ApiResponse = JsonConvert.DeserializeObject<T>(res);
            return ApiResponse;
        }
    }
}