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
    public class VendaController : Controller
    {
        // GET: Venda/Cadastro
        public ActionResult Cadastro()
        {
            return View(new VendaCadastroViewModel());
        }

        // GET: Venda/Consulta
        public ActionResult Consulta()
        {
            List<VendaConsultaViewModel> model = new List<VendaConsultaViewModel>();

            try
            {
                VendaBusiness business = new VendaBusiness();
                model = Mapper.Map<List<VendaConsultaViewModel>>(business.ObterTodos());
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            //enviando a lista para a página..
            return View(model);
        }

        // GET: Venda/Edicao
        public ActionResult Edicao(int id)
        {
            //criando um objeto da classe de modelo
            VendaEdicaoViewModel model = new VendaEdicaoViewModel();

            try
            {
                //buscar o estoque pelo id..
                VendaBusiness business = new VendaBusiness();
                Venda venda = business.ObterPorId(id);

                //transferir os dados de Venda para VendaEdicaoViewModel
                model = Mapper.Map<VendaEdicaoViewModel>(venda);
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
            }

            //enviando o objeto para a página
            return View(model);
        }


        // POST Incluir nova venda
        //POST: Venda/CadastrarVenda
        [HttpPost]
        public ActionResult CadastrarVenda(VendaCadastroViewModel model)
        {
            //verificando se as validações estão corretas
            if(ModelState.IsValid)
            {
                try
                {                           //    SAIDA  ENTRADA
                    Venda venda = Mapper.Map<Venda>(model);

                    //gravar..
                    VendaBusiness business = new VendaBusiness();
                    business.Cadastrar(venda);

                    ViewBag.Mensagem = "Venda cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário
                }
                catch(Exception e)
                {
                    ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
                }
            }

            //nome da página
            return View("Cadastro", new VendaCadastroViewModel());
        }

        //GET: Venda/Exclusao/id
        public ActionResult Exclusao(int id)
        {
            try
            {
                VendaBusiness business = new VendaBusiness();
                business.Excluir(id);

                TempData["Mensagem"] = "Venda excluído com sucesso.";
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            //redirecionar para a página de consulta
            return RedirectToAction("Consulta", "Venda");
        }

        [HttpPost]
        public ActionResult AtualizarVenda(VendaEdicaoViewModel model)
        {
            //verificar se não há erros de validação
            if (ModelState.IsValid)
            {
                try
                {
                    //passando os dados da model para a entidade
                    Venda venda = Mapper.Map<Venda>(model);

                    //atualizando..
                    VendaBusiness business = new VendaBusiness();
                    business.Atualizar(venda);

                    TempData["Mensagem"] = "Venda atualizado com sucesso.";
                    return RedirectToAction("Consulta", "Venda");
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