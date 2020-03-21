using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Gufi_WebApi_Manha.Domains;
using Senai_Gufi_WebApi_Manha.Interface;
using Senai_Gufi_WebApi_Manha.Repository;

namespace Senai_Gufi_WebApi_Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private IPresencaRepository _presencaRepository { get; set; }

        public PresencaController()
        {
            _presencaRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_presencaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(Presenca novoConvidado)
        {
            _presencaRepository.Convidar(novoConvidado);

            return StatusCode(201);
        }

        [HttpPost]
        public IActionResult PostInscricao(Presenca novaPresenca)
        {
            _presencaRepository.InscricaoEvento(novaPresenca);

            return StatusCode(201);
        }

    }
}