using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Repositories;
using Senai.Gufi.WebApi.Manha.ViewModel;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet("{email}")]
        public IActionResult GetByPasswordEmail(string email, string senha)
        {
            return Ok(_usuarioRepository.BuscarPorEmailSenha(email, senha));
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipousuario.ToString())
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Senatur-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "Senatur.WebApi",                 // emissor do token
                audience: "Senatur.WebApi",               // destinatário do token
                claims: claims,                          // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                signingCredentials: creds                // credenciais do token
            );

            // Retorna Ok com o token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}