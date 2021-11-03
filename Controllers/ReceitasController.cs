using System.Threading.Tasks;
using financasPrebelli.Data;
using financasPrebelli.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace financasPrebelli.Controllers
{
	[Controller]
	[Route("[controller]")]

	public class ReceitasController : ControllerBase
	{
		private DataContext dc;

		public ReceitasController(DataContext context)
		{
			this.dc = context;
		}

		[HttpPost("createReceitas")]
		public async Task<ActionResult> cadastrar([FromBody] Receitas r)
		{
			dc.receitas.Add(r);
			await dc.SaveChangesAsync();

			return Created("Objeto receitas", r);
		}
		[HttpGet("listReceitas")]
		public async Task<ActionResult> listar()
		{
			var dados = await dc.receitas.ToListAsync();
			return Ok(dados);
		}

		[HttpGet("listReceitas/{id}")]
		public Receitas filtrar(int id)
		{
			Receitas r = dc.receitas.Find(id);

			return r;
		}

		[HttpPut("updateReceita")]
		public async Task<ActionResult> editar([FromBody] Receitas r)
		{
			dc.receitas.Update(r);
			await dc.SaveChangesAsync();
			return Ok(r);
		}
		[HttpDelete("deleteReceita/{id}")]

		public async Task<ActionResult> deletar(int id)
		{
			Receitas r = filtrar(id);
			if (r == null)
			{
				return NotFound();
			}
			else
			{
				dc.receitas.Remove(r);
				await dc.SaveChangesAsync();
				return Ok();
			}
		}
	}
}
