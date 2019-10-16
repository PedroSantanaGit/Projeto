using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models; //importando..
using Projeto.Entities; //importando..
using Projeto.Business; //importando..
using AutoMapper; //importando..

namespace Projeto.Presentation.Controllers
{
    public class EstoqueController : Controller
    {
        // GET: Estoque/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Estoque/Consulta
        public ActionResult Consulta()
        {
            //criando uma lista classe de modelo..
            List<EstoqueConsultaViewModel> model = new List<EstoqueConsultaViewModel>();

            try
            {
                EstoqueBusiness business = new EstoqueBusiness();
                model = Mapper.Map<List<EstoqueConsultaViewModel>>(business.ObterTodos());
            }
            catch(Exception e)
            {
                //imprimir mensagem de erro na página
                ViewBag.Mensagem = e.Message;
            }

            //enviar a lista para a página
            return View(model);
        }

        // GET: Estoque/Edicao/id
        public ActionResult Edicao(int id)
        {
            //criando um objeto da classe de modelo
            EstoqueEdicaoViewModel model = new EstoqueEdicaoViewModel();

            try
            {
                //buscar o estoque pelo id..
                EstoqueBusiness business = new EstoqueBusiness();
                Estoque estoque = business.ObterPorId(id);

                //transferir os dados de Estoque para EstoqueEdicaoViewModel
                model = Mapper.Map<EstoqueEdicaoViewModel>(estoque);
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
            }

            //enviando o objeto para a página
            return View(model);
        }

        // GET: Estoque/Exclusao/id
        public ActionResult Exclusao(int id)
        {
            try
            {
                EstoqueBusiness business = new EstoqueBusiness();
                business.Excluir(id);

                TempData["Mensagem"] = "Estoque excluído com sucesso.";
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
            }

            //redirecionar para a página de consulta..
            //executando o método ActionResult Consulta()
            return RedirectToAction("Consulta", "Estoque");
        }

        [HttpPost] //receber chamadas do tipo POST
        public ActionResult CadastrarEstoque(EstoqueCadastroViewModel model)
        {
            //verificar se os dados estão corretos
            //em relação as suas validações..
            if(ModelState.IsValid)
            {
                Estoque estoque = Mapper.Map<Estoque>(model);

                try
                {
                    EstoqueBusiness business = new EstoqueBusiness();
                    business.Cadastrar(estoque);

                    ViewBag.Mensagem = "Estoque cadastrado com sucesso.";
                    ModelState.Clear(); //limpar todos os campos do formulário
                }
                catch(Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            //retornar para a página..
            return View("Cadastro");
        }

        [HttpPost]
        public ActionResult AtualizarEstoque(EstoqueEdicaoViewModel model)
        {
            //verificar se não há erros de validação
            if(ModelState.IsValid)
            {
                try
                {
                    //passando os dados da model para a entidade
                    Estoque estoque = Mapper.Map<Estoque>(model);

                    //atualizando..
                    EstoqueBusiness business = new EstoqueBusiness();
                    business.Atualizar(estoque);

                    TempData["Mensagem"] = "Estoque atualizado com sucesso.";
                    return RedirectToAction("Consulta", "Estoque");
                }
                catch(Exception e)
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