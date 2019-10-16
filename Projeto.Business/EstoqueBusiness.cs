using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //importando..
using Projeto.Repository; //importando..

namespace Projeto.Business
{
    public class EstoqueBusiness
    {
        //método para cadastrar o estoque..
        public void Cadastrar(Estoque estoque)
        {
            EstoqueRepository repository = new EstoqueRepository();

            try
            {
                repository.AbrirConexao();
                repository.Inserir(estoque);
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

        //método para atualizar o estoque..
        public void Atualizar(Estoque estoque)
        {
            EstoqueRepository repository = new EstoqueRepository();

            try
            {
                repository.AbrirConexao();
                repository.Atualizar(estoque);
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
        public void Excluir(int idEstoque)
        {
            EstoqueRepository repository = new EstoqueRepository();

            try
            {
                repository.AbrirConexao();
                repository.Excluir(idEstoque);
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
        public List<Estoque> ObterTodos()
        {
            EstoqueRepository repository = new EstoqueRepository();

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

        //método para consultar 1 estoque pelo id
        public Estoque ObterPorId(int idEstoque)
        {
            EstoqueRepository repository = new EstoqueRepository();

            try
            {
                repository.AbrirConexao();
                Estoque estoque = repository.ObterPorId(idEstoque);
                
                if(estoque != null) //se foi encontrado
                {
                    return estoque; //retornando estoque..
                }
                else
                {
                    throw new Exception("Estoque não encontrado.");
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
    }
}
