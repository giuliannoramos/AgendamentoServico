using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AgendamentoServico.Repositories;
using AgendamentoServico.ViewModelCreate;
using AgendamentoServico.ViewModelRead;
using AgendamentoServico.ViewModelUpdate;

namespace AgendamentoServico.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly ProfissionalRepository _profissionalRepository;
        private static readonly List<Profissional> profissionais = new List<Profissional>();
        public ProfissionalController()
        {
            _profissionalRepository = new ProfissionalRepository();
        }

        [HttpPost]
        public IActionResult Create(CreateProfissionalViewModel createProfissionalViewModel)
        {   
            if (createProfissionalViewModel.profissional == null)
                return Ok("Dados do profissional não informados.");                       

            var resultado = _profissionalRepository.CreateProfissional(createProfissionalViewModel.profissional);

            if (resultado) return Ok("Profissional cadastrado com sucesso.");

            return Ok("Houve um problema ao cadastrar. Profissional não cadastrado.");            
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var resultado = _profissionalRepository.ReadAllProfissional();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }       

    }
}
