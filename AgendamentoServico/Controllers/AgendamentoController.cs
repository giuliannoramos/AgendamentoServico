using AgendamentoServico.Repositories;
using AgendamentoServico.ViewModelCreate;
using AgendamentoServico.ViewModelDelete;
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
        public IActionResult ReadAll()
        {
            var resultado = _agendamentoRepository.ReadAllAgendamento();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Update(UpdateAgendamentoViewModel updateAgendamentoViewModel)
        {

            var resultado = _agendamentoRepository.UpdateAgendamento(updateAgendamentoViewModel.agendamento, updateAgendamentoViewModel.Id);

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
            var resultado = _agendamentoRepository.DeleteAgendamento(deleteAgendamentoViewModel.Id);

            if (resultado) return Ok("Agendamento removido com sucesso.");

            return Ok("Erro ao deletar o agendamento.");
        }

        [HttpGet]
        public IActionResult ListarAgendamentosParaHoje()
        {
            var resultado = _agendamentoRepository.ListarAgendamentosParaHojeDetalhado();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult NumeroTotalDeAgendamentos()
        {
            var resultado = _agendamentoRepository.NumeroTotalDeAgendamentos();

            if (resultado == 0)
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult TotalArrecadado()
        {
            var resultado = _agendamentoRepository.TotalArrecadado();

            if (resultado == 0)
                return NotFound();

            return Ok(resultado);
        }

    }
}
