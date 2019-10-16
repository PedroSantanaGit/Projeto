using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository;

namespace Projeto.Business
{
	public class ClienteBusiness
	{
		public void Cadastrar(Cliente cliente)
		{
			ClienteRepository repository = new ClienteRepository();

			try
			{
				repository.AbrirConexao();
				repository.Inserir(cliente);
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

		//método para consultar todos os estoques..
		public List<Cliente> ObterTodos()
		{
			ClienteRepository repository = new ClienteRepository();

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
		public Cliente ObterPorId(int idCliente)
		{
			ClienteRepository repository = new ClienteRepository();

			try
			{
				repository.AbrirConexao();
				Cliente cliente= repository.ObterPorId(idCliente);

				if (cliente != null) //se foi encontrado
				{
					return cliente; //retornando cliente..
				}
				else
				{
					throw new Exception("Cliente não encontrado.");
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

		//método para atualizar o cliente..
		public void Atualizar(Cliente cliente)
		{
			ClienteRepository repository = new ClienteRepository();

			try
			{
				repository.AbrirConexao();
				repository.Update(cliente);
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
		public void Excluir(int idCliente)
		{
			ClienteRepository repository = new ClienteRepository();

			try
			{
				repository.AbrirConexao();
				repository.Excluir(idCliente);
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
