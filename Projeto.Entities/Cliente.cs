﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
		public DateTime Nascimento { get; set; }
	}
}
