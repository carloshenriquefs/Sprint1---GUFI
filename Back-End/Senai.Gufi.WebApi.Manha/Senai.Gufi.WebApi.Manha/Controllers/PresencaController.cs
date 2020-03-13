using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Repositories;

namespace Senai.Gufi.WebApi.Manha.Controllers
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_presencaRepository.BuscarPorId(id)); ;
        }

        [HttpPost]
        public IActionResult Post(Presenca novaPresenca)
        {
            _presencaRepository.Cadastrar(novaPresenca);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca presencaAtualizada)
        {
            try
            {
                _presencaRepository.Atualizar(id, presencaAtualizada);

                return StatusCode(204);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _presencaRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}