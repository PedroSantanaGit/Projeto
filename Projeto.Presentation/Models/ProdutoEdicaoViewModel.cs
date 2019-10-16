using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.Business;

namespace Projeto.Presentation.Models
{
    public class ProdutoEdicaoViewModel
    {

        [Required(ErrorMessage = "Por favor, informe o ID do produto.")]
        public string IdProduto { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string Nome { get; set; }

        [Range(0.01, 99999, ErrorMessage = "Por favor, informe um preço entre R$ {1} e R$ {2}.")]
        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public decimal Preco { get; set; }

        [Range(1, 9999, ErrorMessage = "Por favor, informe uma quantidade entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int Quantidade { get; set; }

        //utilizado para capturar o id do estoque selecionado
        [Required(ErrorMessage = "Por favor, selecione o estoque.")]
        public int IdEstoque { get; set; }

        //propriedade para gerar o DropDownList
        public List<SelectListItem> Estoques
        {
            get
            {
                List<SelectListItem> lista = new List<SelectListItem>();

                EstoqueBusiness business = new EstoqueBusiness();
                foreach (Estoque estoque in business.ObterTodos())
                {
                    lista.Add(new SelectListItem
                    {
                        Value = estoque.IdEstoque.ToString(),
                        Text = estoque.Nome
                    });
                }

                return lista;
            }
        }
    }
}