using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PruebaApiNet.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace PruebaApiNet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TokenValidationParameters _tokenParameters;
    public AuthController(IOptionsMonitor<JwtBearerOptions> jwOptions)
    {
        _tokenParameters = jwOptions.Get(JwtBearerDefaults.AuthenticationScheme).TokenValidationParameters;
    }




    [Authorize]
    [HttpGet]
    public string GetUserIdentifiedMessage()
    {
        return "Si puedes leer esto es que estás identificado";
    }

    [Authorize(Roles = "admin")]
    [HttpGet("admin")]
    public string GetAdminMessage()
    {
        return "Si puedes leer esto, eres el admin";
    }

    [AllowAnonymous] // Se pone para que todos puedan llamarlo es decir EL LOGIN y el registro.
    [HttpPost]
    public ActionResult<string> Login([FromBody] LoginDto data)
    {
        if (data.UserName == "paco" && data.Password == "123456")
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Claims = new Dictionary<string, object>
                {
                    { "id", 23},
                    { ClaimTypes.Role, "" }
                },
                Expires = DateTime.UtcNow.AddHours(1), //Tiempo de expiracion
                SigningCredentials = new SigningCredentials(
                    _tokenParameters.IssuerSigningKey, //La clave que viene del tokenParameters con un cifrado
                    SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor); //Informacion del token en una instancia
            string tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);

        } else
        {
            return Unauthorized(); // Devuelve codigo 401 USUARIO NO AUTORIZADO
        }
    }
}
