using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
	public class ClienteCadastroViewModel
	{
		[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
		public string Nome { get; set; }

		[MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o email do cliente.")]
		public string Email { get; set; }

		[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o CPF do cliente.")]
		public string CPF { get; set; }

		[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe a data de nascimento do cliente.")]
		public string Nascimento { get; set; }

		[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		public string CNPJ { get; set; }

		[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o endereço do cliente.")]
		public string Endereco { get; set; }
	}
}