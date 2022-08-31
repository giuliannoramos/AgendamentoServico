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
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository _servicoRepository;

        public ServicoController()
        {
            _servicoRepository = new ServicoRepository();
        }

        [HttpPost]
        public IActionResult Create(CreateServicoViewModel createServicoViewModel)
        {
            if (createServicoViewModel.servico == null)
                return Ok("Dados do serviço não informados.");

            var resultado = _servicoRepository.CreateServico(createServicoViewModel.servico);

            if (resultado) return Ok("Serviço cadastrado com sucesso.");

            return Ok("Erro ao cadastrar o serviço.");
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var resultado = _servicoRepository.ReadAllServico();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Update(UpdateServicoViewModel updateServicoViewModel)
        {

            var resultado = _servicoRepository.UpdateServico(updateServicoViewModel.servico, updateServicoViewModel.Id);

            if (resultado) return Ok("Servico atualizado com sucesso. ");
            return Ok(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar o servico."
            });
        }

        [HttpDelete]
        public IActionResult Delete(DeleteServicoViewModel deleteServicoViewModel)
        {
            var resultado = _servicoRepository.DeleteServico(deleteServicoViewModel.Id);

            if (resultado) return Ok("Serviço removido com sucesso.");

            return Ok("Erro ao deletar o serviço.");
        }

    }
}
