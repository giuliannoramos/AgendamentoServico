using AgendamentoServico.Models;
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
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }

        [HttpPost]
        public IActionResult Create(CreateClienteViewModel createClienteViewModel)
        {
            if (createClienteViewModel.cliente == null)
                return Ok("Dados do cliente não informados.");

            var resultado = _clienteRepository.CreateCliente(createClienteViewModel.cliente);

            if (resultado) return Ok("Cliente cadastrado com sucesso.");

            return Ok("Erro ao cadastrar o cliente.");
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var resultado = _clienteRepository.ReadAllCliente();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Update(UpdateClienteViewModel updateClienteViewModel)
        {

            var resultado = _clienteRepository.UpdateCliente(updateClienteViewModel.cliente, updateClienteViewModel.Id);

            if (resultado) return Ok("Cliente atualizado com sucesso. ");
            return Ok(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar o cliente."
            });
        }

        [HttpDelete]
        public IActionResult Delete(DeleteClienteViewModel deleteClienteViewModel)
        {
            var resultado = _clienteRepository.DeleteCliente(deleteClienteViewModel.Id);

            if (resultado) return Ok("Cliente removido com sucesso.");

            return Ok("Erro ao deletar o cliente.");
        }

    }
}
