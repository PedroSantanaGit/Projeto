using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.Business;
using Projeto.Presentation.Models;
using AutoMapper;

namespace Projeto.Presentation.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto/Cadastro
        public ActionResult Cadastro()
        {
            return View(new ProdutoCadastroViewModel());
        }

        // GET: Produto/Consulta
        public ActionResult Consulta()
        {
            List<ProdutoConsultaViewModel> model = new List<ProdutoConsultaViewModel>();

            try
            {
                ProdutoBusiness business = new ProdutoBusiness();
                model = Mapper.Map<List<ProdutoConsultaViewModel>>(business.ObterTodos());
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            //enviando a lista para a página..
            return View(model);
        }

        // GET: Produto/Edicao
        public ActionResult Edicao(int id)
        {
            //criando um objeto da classe de modelo
            ProdutoEdicaoViewModel model = new ProdutoEdicaoViewModel();

            try
            {
                //buscar o estoque pelo id..
                ProdutoBusiness business = new ProdutoBusiness();
                Produto produto = business.ObterPorId(id);

                //transferir os dados de Produto para ProdutoEdicaoViewModel
                model = Mapper.Map<ProdutoEdicaoViewModel>(produto);
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
            }

            //enviando o objeto para a página
            return View(model);
        }

        //POST: Produto/CadastrarProduto
        [HttpPost]
        public ActionResult CadastrarProduto(ProdutoCadastroViewModel model)
        {
            //verificando se as validações estão corretas
            if(ModelState.IsValid)
            {
                try
                {                           //    SAIDA  ENTRADA
                    Produto produto = Mapper.Map<Produto>(model);

                    //gravar..
                    ProdutoBusiness business = new ProdutoBusiness();
                    business.Cadastrar(produto);

                    ViewBag.Mensagem = "Produto cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário
                }
                catch(Exception e)
                {
                    ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
                }
            }

            //nome da página
            return View("Cadastro", new ProdutoCadastroViewModel());
        }

        //GET: Produto/Exclusao/id
        public ActionResult Exclusao(int id)
        {
            try
            {
                ProdutoBusiness business = new ProdutoBusiness();
                business.Excluir(id);

                TempData["Mensagem"] = "Produto excluído com sucesso.";
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            //redirecionar para a página de consulta
            return RedirectToAction("Consulta", "Produto");
        }

        //GET: Produto/Carrinho/id
        public ActionResult Carrinho(int id)
        {
            try
            {
                ProdutoBusiness business = new ProdutoBusiness();
                business.Carrinho(id);

                TempData["Mensagem"] = "Produto adicionado ao carrinho.";
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            //redirecionar para a página de consulta
            return RedirectToAction("Consulta", "Produto");
        }

        [HttpPost]
        public ActionResult AtualizarProduto(ProdutoEdicaoViewModel model)
        {
            //verificar se não há erros de validação
            if (ModelState.IsValid)
            {
                try
                {
                    //passando os dados da model para a entidade
                    Produto produto = Mapper.Map<Produto>(model);

                    //atualizando..
                    ProdutoBusiness business = new ProdutoBusiness();
                    business.Atualizar(produto);

                    TempData["Mensagem"] = "Produto atualizado com sucesso.";
                    return RedirectToAction("Consulta", "Produto");
                }
                catch (Exception e)
                {
                    //mensagem de erro
                    ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
                }
            }

            //retornando para a página
            return View("Edicao");
        }

    }
}