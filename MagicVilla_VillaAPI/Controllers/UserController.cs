using System.Net;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto.Users;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers;

[Route("api/v{version:apiVersion}/UsersAuth")]
[ApiController]
[ApiVersionNeutral]
public class UserController : ControllerBase
{
     private readonly IUserRepository _userRepository;
     protected ApiResponse _response;

     public UserController(IUserRepository userRepository)
     {
          _userRepository = userRepository;
          _response = new();
     }

     [HttpPost("login")]
     public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
     {
          var loginResponse = await _userRepository.Login(model);
          if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
          {
               _response.StatusCode = HttpStatusCode.BadRequest;
               _response.ErrorMessages.Add("Username or password is incorrect.");
               return BadRequest(_response);
          }

          _response.StatusCode = HttpStatusCode.OK;
          _response.Result = loginResponse;
          return Ok(_response);

     }
     
     [HttpPost("register")]
     public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
     {
          bool ifUserNameUnique = _userRepository.IsUniqueUser(model.Username);

          if (!ifUserNameUnique)
          {
               _response.StatusCode = HttpStatusCode.BadRequest;
               _response.ErrorMessages.Add("Username already exists.");
               return BadRequest(_response);
          }
          var user = await _userRepository.Register(model);
          if (user == null)
          {
               _response.StatusCode = HttpStatusCode.BadRequest;
               _response.ErrorMessages.Add("Error while registering");
               return BadRequest(_response);
          }
          _response.StatusCode = HttpStatusCode.OK;
          return Ok(_response);
     }
}