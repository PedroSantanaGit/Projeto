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
	public class VendaRepository : Conexao
	{

		//método para inserir um venda na base
		public void Inserir(Venda venda)
		{
			
			string query = "insert into Venda(Nome, Email, Telefone, CNPJ, Endereco) "
						 + "values(@Nome, @Email, @Telefone, @CNPJ, @Endereco)";



            //EDITADO DE QQR FORMA PRA REMOVER OS ERROS DE ACORDO COM AS ENTIDADES UTILIZADAS NA MODEL ****
			Command = new SqlCommand(query, Connection);
			Command.Parameters.AddWithValue("@Nome", venda.Cliente);
			Command.Parameters.AddWithValue("@Email", venda.DataVenda);
			Command.Parameters.AddWithValue("@Telefone", venda.IdVenda);
			Command.Parameters.AddWithValue("@CNPJ", venda.Usuario);
			Command.Parameters.AddWithValue("@Endereco", venda.ValorTotal);
			Command.ExecuteNonQuery(); 
		}


		//método para atualizar um venda na base
		public void Update(Venda venda)
		{
			using (var conn = Connection)
			{
				var query = "update Venda set Nome = @Nome, Email = @Email, Telefone = @Telefone, Endereco = @Endereco, CNPJ = @CNPJ "
				+ "where IdVenda = @IdVenda";
				//executando..
				conn.Execute(query, venda);
			}
		}


		//método para excluir um venda da base
		public void Excluir(int id)
		{
			using (var conn = Connection)
			{
				var query = "delete from Venda where IdVenda = @IdVenda";
				//executando..
				conn.Execute(query, new { IdVenda = id });
			}
		}



		public List<Venda> ObterTodos()
		{
			using (var conn = Connection)
			{
				var query = "select * from Venda";
				//executando..
				return conn.Query<Venda>(query).ToList();
			}
		}


		public Venda ObterPorId(int id) {
		using (var conn = Connection)
		{
			var query = "select * from Venda where IdVenda = @IdVenda";
				//SingleOrDefault -> retorna apenas 1 registro e se nenhum for encontrado retorna null.
				//se a consulta obtiver mais de 1 registro o SingleOrDefault lança uma exceção

				return conn.QuerySingleOrDefault<Venda>(query,
		   new
		   {
			   IdVenda = id
		   });
		}
 }




	}
}
