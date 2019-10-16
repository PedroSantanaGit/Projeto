using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //importando
using Projeto.Entities; //importando

namespace Projeto.Repository
{
    public class ProdutoRepository : Conexao
    {
        //método para inserir um produto na base de dados
        public void Inserir(Produto produto)
        {
            string query = "insert into Produto(Nome, Preco, Quantidade, DataCadastro, IdEstoque) "
                         + "values(@Nome, @Preco, @Quantidade, @DataCadastro, @IdEstoque)";

            //executar o comando SQL..
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@Nome", produto.Nome);
            Command.Parameters.AddWithValue("@Preco", produto.Preco);
            Command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
            Command.Parameters.AddWithValue("@DataCadastro", produto.DataCadastro);
            Command.Parameters.AddWithValue("@IdEstoque", produto.Estoque.IdEstoque);
            Command.ExecuteNonQuery();
        }

        //método para atualizar o produto
        public void Atualizar(Produto produto)
        {
            string query = "update Produto set Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade, IdEstoque = @IdEstoque "
                         + "where IdProduto = @IdProduto";

            //executar o comando SQL..
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IdProduto", produto.IdProduto);
            Command.Parameters.AddWithValue("@Nome", produto.Nome);
            Command.Parameters.AddWithValue("@Preco", produto.Preco);
            Command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
            Command.Parameters.AddWithValue("@IdEstoque", produto.Estoque);
            Command.ExecuteNonQuery();
        }

        //método para excluir o produto
        public void Excluir(int idProduto)
        {
            string query = "delete from Produto where IdProduto = @IdProduto";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IdProduto", idProduto);
            Command.ExecuteNonQuery();
        }

        //método para adicionar o produto ao carrinho
        public void Carrinho(int idProduto)
        {
            string query = "delete from Produto where IdProduto = @IdProduto";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IdProduto", idProduto);
            Command.ExecuteNonQuery();
        }

        //método para retornar todos os produtos com estoque
        public List<Produto> ObterTodos()
        {
            string query = "select p.IdProduto, p.Nome, p.Preco, p.Quantidade, "
                         + "p.DataCadastro, e.IdEstoque, e.Nome as NomeEstoque "
                         + "from Produto p inner join Estoque e "
                         + "on p.IdEstoque = e.IdEstoque";

            Command = new SqlCommand(query, Connection);
            DataReader = Command.ExecuteReader();

            List<Produto> lista = new List<Produto>();

            while(DataReader.Read())
            {
                Produto produto = new Produto();
                produto.Estoque = new Estoque();

                produto.IdProduto = Convert.ToInt32(DataReader["IdProduto"]);
                produto.Nome = Convert.ToString(DataReader["Nome"]);
                produto.Preco = Convert.ToDecimal(DataReader["Preco"]);
                produto.Quantidade = Convert.ToInt32(DataReader["Quantidade"]);
                produto.DataCadastro = Convert.ToDateTime(DataReader["DataCadastro"]);
                produto.Estoque.IdEstoque = Convert.ToInt32(DataReader["IdEstoque"]);
                produto.Estoque.Nome = Convert.ToString(DataReader["NomeEstoque"]);

                lista.Add(produto); //adicionar na lista..
            }

            return lista;
        }

        //método para retornar 1 produto com estoque pelo id
        public Produto ObterPorId(int idProduto)
        {
            string query = "select p.IdProduto, p.Nome, p.Preco, p.Quantidade, "
                         + "p.DataCadastro, e.IdEstoque, e.Nome as NomeEstoque "
                         + "from Produto p inner join Estoque e "
                         + "on p.IdEstoque = e.IdEstoque "
                         + "where IdProduto = @IdProduto";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IdProduto", idProduto);
            DataReader = Command.ExecuteReader();
            
            if(DataReader.Read()) //se algum registro foi encontrado
            {
                Produto produto = new Produto();
                produto.Estoque = new Estoque();

                produto.IdProduto = Convert.ToInt32(DataReader["IdProduto"]);
                produto.Nome = Convert.ToString(DataReader["Nome"]);
                produto.Preco = Convert.ToDecimal(DataReader["Preco"]);
                produto.Quantidade = Convert.ToInt32(DataReader["Quantidade"]);
                produto.DataCadastro = Convert.ToDateTime(DataReader["DataCadastro"]);
                produto.Estoque.IdEstoque = Convert.ToInt32(DataReader["IdEstoque"]);
                produto.Estoque.Nome = Convert.ToString(DataReader["NomeEstoque"]);

                return produto;
            }
            else
            {
                return null; //vazio..
            }            
        }
    }
}
