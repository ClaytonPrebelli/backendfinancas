using System.ComponentModel.DataAnnotations;

namespace financasPrebelli.Models
{
	public class Despesas
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Nome { get; set; }

		[Required]
		[RegularExpression(@"^\d+(\.\d{1,2})?$")]

		public decimal Valor { get; set; }
		[Required]

		public string Vencimento { get; set; }
		[Required]
		public string Parcelas { get; set; }
		[Required]
		public bool Pago { get; set; }
		[Required]
		public int MesRef { get; set; }
	}
}
