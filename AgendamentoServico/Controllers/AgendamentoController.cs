using AgendamentoServico.Repositories;
using AgendamentoServico.ViewModelCreate;
using AgendamentoServico.ViewModelDelete;
using AgendamentoServico.ViewModels;
using AgendamentoServico.ViewModelUpdate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoServico.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AgendamentoRepository _agendamentoRepository;

        public AgendamentoController()
        {
            _agendamentoRepository = new AgendamentoRepository();
        }

        [HttpPost]
        public IActionResult Create(CreateAgendamentoViewModel createAgendamentoViewModel)
        {
            if (createAgendamentoViewModel.agendamento == null)
                return Ok("Dados do agendamento não informados.");

            var resultado = _agendamentoRepository.CreateAgendamento(createAgendamentoViewModel.agendamento);

            if (resultado) return Ok("Agendamento cadastrado com sucesso.");

            return Ok("Erro ao cadastrar o agendamento.");
        }

        [HttpGet]
        public IActionResult ReadAll(ReadAgendamentoViewModel readAgendamentoViewModel)
        {
            var resultado = _agendamentoRepository.ReadAllAgendamento(readAgendamentoViewModel.agendamento);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Update(UpdateAgendamentoViewModel updateAgendamentoViewModel)
        {

            var resultado = _agendamentoRepository.UpdateAgendamento(updateAgendamentoViewModel.agendamento);

            if (resultado) return Ok("Agendamento atualizado com sucesso. ");
            return Ok(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar o agendamento."
            });
        }

        [HttpDelete]
        public IActionResult Delete(DeleteAgendamentoViewModel deleteAgendamentoViewModel)
        {
            var resultado = _agendamentoRepository.DeleteAgendamento(deleteAgendamentoViewModel.agendamento);

            if (resultado) return Ok("Agendamento removido com sucesso.");

            return Ok("Erro ao deletar o agendamento.");
        }

    }
}
