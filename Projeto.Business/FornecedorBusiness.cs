using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository;

namespace Projeto.Business
{
	public class FornecedorBusiness
	{
		public void Cadastrar(Fornecedor fornecedor)
		{
			FornecedorRepository repository = new FornecedorRepository();

			try
			{
				repository.AbrirConexao();
				repository.Inserir(fornecedor);
			}
			catch (Exception e)
			{
				throw new Exception("Ocorreu um erro: " + e.Message);
			}
			finally
			{
				repository.FecharConexao();
			}
		}

		
		public List<Fornecedor> ObterTodos()
		{
			FornecedorRepository repository = new FornecedorRepository();

			try
			{
				repository.AbrirConexao();
				return repository.ObterTodos();
			}
			catch (Exception e)
			{
				throw new Exception("Ocorreu um erro: " + e.Message);
			}
			finally
			{
				repository.FecharConexao();
			}
		}


		//obter por ID
		public Fornecedor ObterPorId(int idFornecedor)
		{
			FornecedorRepository repository = new FornecedorRepository();

			try
			{
				repository.AbrirConexao();
				Fornecedor fornecedor= repository.ObterPorId(idFornecedor);

				if (fornecedor != null) //se foi encontrado
				{
					return fornecedor; //retornando fornecedor..
				}
				else
				{
					throw new Exception("Fornecedor não encontrado.");
				}
			}
			catch (Exception e)
			{
				throw new Exception("Ocorreu um erro: " + e.Message);
			}
			finally
			{
				repository.FecharConexao();
			}
		}

		//método para atualizar o fornecedor..
		public void Atualizar(Fornecedor fornecedor)
		{
			FornecedorRepository repository = new FornecedorRepository();

			try
			{
				repository.AbrirConexao();
				repository.Update(fornecedor);
			}
			catch (Exception e)
			{
				throw new Exception("Ocorreu um erro: " + e.Message);
			}
			finally
			{
				repository.FecharConexao();
			}
		}

		//método para excluir o estoque..
		public void Excluir(int idFornecedor)
		{
			FornecedorRepository repository = new FornecedorRepository();

			try
			{
				repository.AbrirConexao();
				repository.Excluir(idFornecedor);
			}
			catch (Exception e)
			{
				throw new Exception("Ocorreu um erro: " + e.Message);
			}
			finally
			{
				repository.FecharConexao();
			}
		}
	}
}
