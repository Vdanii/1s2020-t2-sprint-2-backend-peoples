using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionariosRepository();
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        { 
            _funcionarioRepository.Apagar(id);

            return Ok("Funcionario deletado");
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionariosDomains funcionarioAtualizado)
        {
            FuncionariosDomains funcionarioBuscado = _funcionarioRepository.PegarPorId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionario não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(FuncionariosDomains novoFuncionarios)
        {
            _funcionarioRepository.Cadastrar(novoFuncionarios);

            return StatusCode(201);
        }

        [HttpGet]
        public IEnumerable<FuncionariosDomains> Get()
        {
            return _funcionarioRepository.Listar();
        }
    }
}
