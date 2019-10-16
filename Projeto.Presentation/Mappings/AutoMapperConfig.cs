using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Entities; //importando
using Projeto.Presentation.Models; //importando
using AutoMapper; //importando

namespace Projeto.Presentation.Mappings
{    
    public class AutoMapperConfig : Profile
    {
		//construtor
		//ctor + 2x[tab]
		public AutoMapperConfig()
		{
			//Mapeamentos..

			#region Estoque

			//DE: EstoqueCadastroViewModel PARA: Estoque
			CreateMap<EstoqueCadastroViewModel, Estoque>();

			//DE: Estoque PARA: EstoqueConsultaViewModel
			CreateMap<Estoque, EstoqueConsultaViewModel>();

			//DE: Estoque PARA: EstoqueEdicaoViewModel
			CreateMap<Estoque, EstoqueEdicaoViewModel>();

			//DE: EstoqueEdicaoViewModel PARA: Estoque
			CreateMap<EstoqueEdicaoViewModel, Estoque>();

			#endregion

			#region Produto

			//DE: ProdutoCadastroViewModel PARA: Produto
			CreateMap<ProdutoCadastroViewModel, Produto>()
				 .AfterMap((src, dest)
					=> dest.Estoque = new Estoque { IdEstoque = src.IdEstoque })
					.AfterMap((src, dest)
					=> dest.DataCadastro = DateTime.Now);

			//DE: Produto PARA: ProdutoConsultaViewModel
			CreateMap<Produto, ProdutoConsultaViewModel>()
				.AfterMap((src, dest)
				 => dest.Total = src.Preco * src.Quantidade)
				.AfterMap((src, dest)
				=> dest.IdEstoque = src.Estoque.IdEstoque)
				.AfterMap((src, dest)
				=> dest.NomeEstoque = src.Estoque.Nome);

			//DE: Produto PARA: ProdutoEdicaoViewModel
			CreateMap<Produto, ProdutoEdicaoViewModel>();

			//DE: ProdutoEdicaoViewModel PARA: Produto
			CreateMap<ProdutoEdicaoViewModel, Produto>();

			#endregion


			//Mapeamentos..

			#region Cliente

			//DE: EstoqueCadastroViewModel PARA: Estoque
			CreateMap<ClienteCadastroViewModel, Cliente>();
			//DE: Cliente PARA: ClienteEdicaoViewModel
			CreateMap<Cliente, ClienteEdicaoViewModel>();
			//DE: ClienteEdicaoViewModel PARA: Cliente
			CreateMap<ClienteEdicaoViewModel, Cliente>();

			#endregion


			#region Fornecedor

			//DE: FornecedorCadastroViewModel PARA: Fornecedor
			CreateMap<FornecedorCadastroViewModel, Fornecedor>();
			//DE: Fornecedor PARA: FornecedorCadastroViewModel
			CreateMap<Fornecedor, FornecedorCadastroViewModel>();

			//DE: FornecedorEdicaoViewModel PARA: Fornecedor
			//CreateMap<FornecedorEdicaoViewModel, Fornecedor>();

			#endregion



		}
	}
}
