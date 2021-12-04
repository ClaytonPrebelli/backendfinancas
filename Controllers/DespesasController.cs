using System.Threading.Tasks;
using financasPrebelli.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using financasPrebelli.Models;
using Microsoft.AspNetCore.Cors;

namespace financasPrebelli.Controllers
{
	
	[Controller]
	
	[Route("[controller]")]
	[EnableCors("MyPolicy")]



	public class DespesasController : ControllerBase
	{
		
		private DataContext dc;

		public DespesasController(DataContext context)
		{
			this.dc = context;
		}
		
		[HttpPost("createDespesas")]
		
		public async Task<ActionResult> cadastrar([FromBody] Despesas d)
		{
			dc.despesas.Add(d);
			await dc.SaveChangesAsync();

			return Created("Objeto despesa", d);
		}

		[HttpGet("listDespesas")]
		
		public async Task<ActionResult> listar()
		{
			var dados = await dc.despesas.ToListAsync();
			return Ok(dados);
		}
	
		[HttpGet("listDespesas/{id}")]
	
		public Despesas filtrar(int id)
		{
			Despesas d = dc.despesas.Find(id);

			return d;
		}




	
		[HttpPatch("updateDespesa")]
		
		public async Task<ActionResult> editar([FromBody] Despesas d)
		{
			

				dc.despesas.Update(d);
				await dc.SaveChangesAsync();
				return Ok(d);
			
		}
	
		[HttpDelete("deleteDespesa/{id}")]


		public async Task<ActionResult> deletar(int id)
		{
			Despesas d = filtrar(id);
			if (d == null)
			{
				return NotFound();
			}
			else
			{
				dc.despesas.Remove(d);
				await dc.SaveChangesAsync();
				return Ok();
			}
		}
	}
}
