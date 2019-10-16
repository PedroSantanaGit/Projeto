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
	public class FornecedorRepository : Conexao
	{

		//método para inserir um fornecedor na base
		public void Inserir(Fornecedor fornecedor)
		{
			
			string query = "insert into Fornecedor(Nome, Email, Telefone, CNPJ, Endereco) "
						 + "values(@Nome, @Email, @Telefone, @CNPJ, @Endereco)";


			Command = new SqlCommand(query, Connection);
			Command.Parameters.AddWithValue("@Nome", fornecedor.Nome);
			Command.Parameters.AddWithValue("@Email", fornecedor.Email);
			Command.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
			Command.Parameters.AddWithValue("@CNPJ", fornecedor.Cnpj);
			Command.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
			Command.ExecuteNonQuery(); 
		}


		//método para atualizar um fornecedor na base
		public void Update(Fornecedor fornecedor)
		{
			using (var conn = Connection)
			{
				var query = "update Fornecedor set Nome = @Nome, Email = @Email, Telefone = @Telefone, Endereco = @Endereco, CNPJ = @CNPJ "
				+ "where IdFornecedor = @IdFornecedor";
				//executando..
				conn.Execute(query, fornecedor);
			}
		}


		//método para excluir um fornecedor da base
		public void Excluir(int id)
		{
			using (var conn = Connection)
			{
				var query = "delete from Fornecedor where IdFornecedor = @IdFornecedor";
				//executando..
				conn.Execute(query, new { IdFornecedor = id });
			}
		}



		public List<Fornecedor> ObterTodos()
		{
			using (var conn = Connection)
			{
				var query = "select * from Fornecedor";
				//executando..
				return conn.Query<Fornecedor>(query).ToList();
			}
		}


		public Fornecedor ObterPorId(int id) {
		using (var conn = Connection)
		{
			var query = "select * from Fornecedor where IdFornecedor = @IdFornecedor";
				//SingleOrDefault -> retorna apenas 1 registro e se nenhum for encontrado retorna null.
				//se a consulta obtiver mais de 1 registro o SingleOrDefault lança uma exceção

				return conn.QuerySingleOrDefault<Fornecedor>(query,
		   new
		   {
			   IdFornecedor = id
		   });
		}
 }




	}
}
