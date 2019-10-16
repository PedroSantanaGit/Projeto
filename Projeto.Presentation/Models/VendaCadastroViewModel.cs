using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
	public class VendaCadastroViewModel

	{
		//[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		//[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o nome do Venda.")]
		public string Nome { get; set; }

		//[MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		//[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o email do Venda.")]
		public string Email { get; set; }

		//[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		//[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o CNPJ do venda.")]
		public int CNPJ { get; set; }

		//[MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} números.")]
		//[MaxLength(15, ErrorMessage = "Por favor, informe no máximo {1} números.")]
		[Required(ErrorMessage = "Por favor, informe o telefone do venda.")]
		public int Telefone { get; set; }

		//[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		//[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o endereço do venda.")]
		public string Endereco { get; set; }
	}
}