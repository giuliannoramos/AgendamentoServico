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
using AgendamentoServico.ViewModelUpdate;
using AgendamentoServico.ViewModelDelete;

namespace AgendamentoServico.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly ProfissionalRepository _profissionalRepository;
        
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

            return Ok("Erro ao cadastrar o profissional.");            
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var resultado = _profissionalRepository.ReadAllProfissional();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Update(UpdateProfissionalViewModel updateProfissionalViewModel)
        {

            var resultado = _profissionalRepository.UpdateProfissional(updateProfissionalViewModel.Profissional, updateProfissionalViewModel.Id);

            if (resultado) return Ok("Profissional atualizado com sucesso. ");
            return Ok(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar o profisisonal."
            });            
        }

        [HttpDelete]
        public IActionResult Delete(DeleteProfissionalViewModel deleteProfissionalViewModel)
        {
            var resultado = _profissionalRepository.DeleteProfissional(deleteProfissionalViewModel.profissional);

            if (resultado) return Ok("Profissional removido com sucesso.");

            return Ok("Erro ao deletar o profissional.");
        }

    }
}
