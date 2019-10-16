using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime DataVenda { get; set; }
        public Usuario Usuario { get; set; }
        public decimal ValorTotal { get; set; }
        public string FormaPagamento { get; set; }
		public int Parcelas { get; set; }
	}
}
