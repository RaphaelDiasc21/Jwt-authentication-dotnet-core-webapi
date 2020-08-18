using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiJwt.Services
{
    public class JwtService
    {
        public static string generateToken(string username)
        {
                var key = Encoding.ASCII.GetBytes(Settings.secret); // Prepara a chave de segurança
                var tokenDescriptor = new SecurityTokenDescriptor //Objeto que descreve as informações contidas no token, como subject
                {                                                //tempo de expiração e etc
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Name, "Raphael"),
                            new Claim(ClaimTypes.Role, "user")
                        }
                     ),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )


                };
            var tokenHandler = new JwtSecurityTokenHandler(); // Inicializa objeto responsável de gerar e escrever um token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}