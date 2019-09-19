using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Models;
using Project.Application.Contracts;
using AutoMapper;

namespace Project.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
		private readonly ILancamentosApplicationServices applicationServices;

		public LancamentosController(ILancamentosApplicationServices applicationServices)
		{
			this.applicationServices = applicationServices;
		}

		[HttpPost]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(500, Type = typeof(string))]
		[ProducesResponseType(400)]
		public IActionResult Post([FromBody] LancamentosCadastroModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					applicationServices.Cadastrar(model);
					return Ok($"Lancamento {model.Tipo}, cadastrado com sucesso.");
				}
				catch (Exception e)
				{
					return StatusCode(500, e.Message);
				}
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(500, Type = typeof(string))]
		[ProducesResponseType(400)]
		public IActionResult Put([FromBody] LancamentosEdicaoModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					applicationServices.Atualizar(model);
					return Ok($"Lancamento {model.Tipo}, atualizado com sucesso.");
				}
				catch (Exception e)
				{
					return StatusCode(500, e.Message);
				}
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(500, Type = typeof(string))]
		public IActionResult Delete(int id)
		{
			try
			{
				applicationServices.Excluir(id);
				return Ok("Lancamento excluído com sucesso.");
			}
			catch (Exception e)
			{
				return StatusCode(500, e.Message);
			}
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<LancamentosConsultaModel>))]
		[ProducesResponseType(500, Type = typeof(string))]
		public IActionResult Get()
		{
			try
			{
				var result = applicationServices.ConsultarTodosOsDados();
				return Ok(result);
			}
			catch (Exception e)
			{
				return StatusCode(500, e.Message);
			}
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200, Type = typeof(LancamentosConsultaModel))]
		[ProducesResponseType(500, Type = typeof(string))]
		public IActionResult Get(int id)
		{
			try
			{
				var result = applicationServices.ConsultarPorId(id);
				return Ok(result);
			}
			catch (Exception e)
			{
				return StatusCode(500, e.Message);
			}
		}
	}
}
