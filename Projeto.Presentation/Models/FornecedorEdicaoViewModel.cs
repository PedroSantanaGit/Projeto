using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
	public class FornecedorEdicaoViewModel
	{

		[Required(ErrorMessage = "Por favor, informe o id do fornecedor.")]
		public int IdFornecedor { get; set; }

		[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o nome do fornecedor.")]
		public string Nome { get; set; }

		[MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o email do fornecedor.")]
		public string Email { get; set; }

		[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o CNPJ do fornecedor.")]
		public string CNPJ { get; set; }

		[MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
		[MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
		[Required(ErrorMessage = "Por favor, informe o telefone do fornedor.")]
		public string Telefone { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o endereço do fornedor.")]
        public string Endereco { get; set; }
    }
}