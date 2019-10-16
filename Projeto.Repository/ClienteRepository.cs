using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Projeto.Entities;

namespace Projeto.Repository
{
	public class ClienteRepository : Conexao
	{

		//método para inserir um cliente na base
		public void Inserir(Cliente cliente)
		{
			//criando a query sql..
			string query = "insert into Cliente(Nome, Email, CPF, Nascimento, CNPJ, Endereco) "
						 + "values(@Nome, @Email, @CPF, @Nascimento, @CNPJ, @Endereco)";

			//executando o comando sql no banco de dados..
			Command = new SqlCommand(query, Connection);
			Command.Parameters.AddWithValue("@Nome", cliente.Nome);
			Command.Parameters.AddWithValue("@Email", cliente.Email);
			Command.Parameters.AddWithValue("@CPF", cliente.Cpf);
			Command.Parameters.AddWithValue("@Nascimento", cliente.Nascimento);
			Command.Parameters.AddWithValue("@CNPJ", cliente.Cnpj);
			Command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
			Command.ExecuteNonQuery(); //finaliza e executa
		}


		//método para atualizar um cliente na base
		public void Update(Cliente cliente)
		{
			using (var conn = Connection)
			{
				var query = "update Cliente set Nome = @Nome, Email = @Email "
				+ "where IdCliente = @IdCliente";
				//executando..
				conn.Execute(query, cliente);
			}
		}


		//método para excluir um cliente na base
		public void Excluir(int id)
		{
			using (var conn = Connection)
			{
				var query = "delete from Cliente where IdCliente = @IdCliente";
				//executando..
				conn.Execute(query, new { IdCliente = id });
			}
		}



		public List<Cliente> ObterTodos()
		{
			using (var conn = Connection)
			{
				var query = "select * from Cliente";
				//executando..
				return conn.Query<Cliente>(query).ToList();
			}
		}


		public Cliente ObterPorId(int id) {
		using (var conn = Connection)
		{
			var query = "select * from Cliente where IdCliente = @IdCliente";
			//SingleOrDefault -> retorna apenas 1 registro e se nenhum for
			//encontrado retorna null. Se a consulta obtiver
			//mais de 1 registro
			//o SingleOrDefault lança uma exceção
			return conn.QuerySingleOrDefault<Cliente>(query,
		   new
		   {
			   IdCliente = id
		   });
		}
 }




	}
}
