using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
	public class FornecedorCadastroViewModel

	{
		//[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		//[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o nome do Fornecedor.")]
		public string Nome { get; set; }

		//[MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		//[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o email do Fornecedor.")]
		public string Email { get; set; }

		//[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		//[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o CNPJ do fornecedor.")]
		public int CNPJ { get; set; }

		//[MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} números.")]
		//[MaxLength(15, ErrorMessage = "Por favor, informe no máximo {1} números.")]
		[Required(ErrorMessage = "Por favor, informe o telefone do fornecedor.")]
		public int Telefone { get; set; }

		//[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		//[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o endereço do fornecedor.")]
		public string Endereco { get; set; }
	}
}