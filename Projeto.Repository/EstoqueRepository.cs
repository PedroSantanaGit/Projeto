using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //importando..
using Projeto.Entities; //importando..

namespace Projeto.Repository
{
    public class EstoqueRepository : Conexao
    {
        //método para inserir um estoque na base de dados..
        public void Inserir(Estoque estoque)
        {
            //criando a query sql..
            string query = "insert into Estoque(Nome) values(@Nome)";

            //executando o comando sql no banco de dados..
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@Nome", estoque.Nome);
            Command.ExecuteNonQuery(); //finaliza e executa
        }

        //método para atualizar um estoque na base de dados..
        public void Atualizar(Estoque estoque)
        {
            //criando a query sql..
            string query = "update Estoque set Nome = @Nome "
                         + "where IdEstoque = @IdEstoque";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IdEstoque", estoque.IdEstoque);
            Command.Parameters.AddWithValue("@Nome", estoque.Nome);
            Command.ExecuteNonQuery(); //finaliza e executa
        }

        //método para excluir um estoque na base de dados..
        public void Excluir(int idEstoque)
        {
            string query = "delete from Estoque where IdEstoque = @IdEstoque";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IdEstoque", idEstoque);
            Command.ExecuteNonQuery();
        }

        //método para retornar todos os estoques cadastrados no banco
        public List<Estoque> ObterTodos()
        {
            string query = "select * from Estoque";

            Command = new SqlCommand(query, Connection);
            DataReader = Command.ExecuteReader();

            //declarando uma lista..
            List<Estoque> lista = new List<Estoque>();

            while(DataReader.Read())
            {
                Estoque estoque = new Estoque();

                estoque.IdEstoque = Convert.ToInt32(DataReader["IdEstoque"]);
                estoque.Nome = Convert.ToString(DataReader["Nome"]);

                lista.Add(estoque);
            }

            //retornando a lista
            return lista;
        }

        //método para retornar 1 estoque baseado no id
        public Estoque ObterPorId(int idEstoque)
        {
            string query = "select * from Estoque where IdEstoque = @IdEstoque";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IdEstoque", idEstoque);
            DataReader = Command.ExecuteReader();

            Estoque estoque = null; //vazio (sem espaço de memória)

            if(DataReader.Read()) //se contem registro..
            {
                estoque = new Estoque(); //instanciando

                estoque.IdEstoque = Convert.ToInt32(DataReader["IdEstoque"]);
                estoque.Nome = Convert.ToString(DataReader["Nome"]);
            }

            //retornando o objeto..
            return estoque;
        }

    }
}
