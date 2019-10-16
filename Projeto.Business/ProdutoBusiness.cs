using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //importando..
using Projeto.Repository; //importando..

namespace Projeto.Business
{
    public class ProdutoBusiness
    {
        public void Cadastrar(Produto produto)
        {
            ProdutoRepository repository = new ProdutoRepository();

            try
            {
                repository.AbrirConexao();
                repository.Inserir(produto);
            }
            catch(Exception e)
            {
                throw new Exception("Ocorreu um erro: " + e.Message);
            }
            finally
            {
                repository.FecharConexao();
            }
        }

        public void Atualizar(Produto produto)
        {
            ProdutoRepository repository = new ProdutoRepository();

            try
            {
                repository.AbrirConexao();
                repository.Atualizar(produto);
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

        public void Excluir(int idProduto)
        {
            ProdutoRepository repository = new ProdutoRepository();

            try
            {
                repository.AbrirConexao();
                repository.Excluir(idProduto);
            }
            catch(Exception e)
            {
                throw new Exception("Ocorreu um erro: " + e.Message);
            }
            finally
            {
                repository.FecharConexao();
            }
        }


        //adicionar item ao carrinho
        public void Carrinho(int idProduto)
        {
            ProdutoRepository repository = new ProdutoRepository();

            try
            {
                repository.AbrirConexao();
                repository.Carrinho(idProduto);
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

        public List<Produto> ObterTodos()
        {
            ProdutoRepository repository = new ProdutoRepository();

            try
            {
                repository.AbrirConexao();
                return repository.ObterTodos();
            }
            catch(Exception e)
            {
                throw new Exception("Ocorreu um erro: " + e.Message);
            }
            finally
            {
                repository.FecharConexao();
            }
        }

        public Produto ObterPorId(int idProduto)
        {
            ProdutoRepository repository = new ProdutoRepository();

            try
            {
                repository.AbrirConexao();
                return repository.ObterPorId(idProduto);
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
