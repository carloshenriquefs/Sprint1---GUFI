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
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();       
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoEventoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            _tipoEventoRepository.Cadastrar(novoTipoEvento);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoEventoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}