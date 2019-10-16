using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository;

namespace Projeto.Business
{
	public class VendaBusiness
	{
		public void Cadastrar(Venda venda)
		{
			VendaRepository repository = new VendaRepository();

			try
			{
				repository.AbrirConexao();
				repository.Inserir(venda);
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

		
		public List<Venda> ObterTodos()
		{
			VendaRepository repository = new VendaRepository();

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
		public Venda ObterPorId(int idVenda)
		{
			VendaRepository repository = new VendaRepository();

			try
			{
				repository.AbrirConexao();
				Venda venda= repository.ObterPorId(idVenda);

				if (venda != null) //se foi encontrado
				{
					return venda; //retornando venda..
				}
				else
				{
					throw new Exception("Venda não encontrado.");
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

		//método para atualizar o venda..
		public void Atualizar(Venda venda)
		{
			VendaRepository repository = new VendaRepository();

			try
			{
				repository.AbrirConexao();
				repository.Update(venda);
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
		public void Excluir(int idVenda)
		{
			VendaRepository repository = new VendaRepository();

			try
			{
				repository.AbrirConexao();
				repository.Excluir(idVenda);
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
