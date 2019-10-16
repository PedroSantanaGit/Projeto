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
    public class FornecedorController : Controller
    {
        // GET: Fornecedor/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Fornecedor/Consulta
        public ActionResult Consulta()
        {
            //criando uma lista classe de modelo..
            List<FornecedorConsultaViewModel> model = new List<FornecedorConsultaViewModel>();

            try
            {
                FornecedorBusiness business = new FornecedorBusiness();
                model = Mapper.Map<List<FornecedorConsultaViewModel>>(business.ObterTodos());
            }
            catch(Exception e)
            {
                //imprimir mensagem de erro na página
                ViewBag.Mensagem = e.Message;
            }

            //enviar a lista para a página
            return View(model);
        }

        // GET: Fornecedor/Edicao/id
        public ActionResult Edicao(int id)
        {
            //criando um objeto da classe de modelo
            FornecedorEdicaoViewModel model = new FornecedorEdicaoViewModel();

            try
            {
                //buscar o fornecedor pelo id..
                FornecedorBusiness business = new FornecedorBusiness();
                Fornecedor fornecedor = business.ObterPorId(id);

                //transferir os dados de Fornecedor para FornecedorEdicaoViewModel
                model = Mapper.Map<FornecedorEdicaoViewModel>(fornecedor);
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
            }

            //enviando o objeto para a página
            return View(model);
        }

        // GET: Fornecedor/Exclusao/id
        public ActionResult Exclusao(int id)
        {
            try
            {
                FornecedorBusiness business = new FornecedorBusiness();
                business.Excluir(id);

                TempData["Mensagem"] = "Fornecedor excluído com sucesso.";
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
            }

            //redirecionar para a página de consulta..
            //executando o método ActionResult Consulta()
            return RedirectToAction("Consulta", "Fornecedor");
        }

        [HttpPost] //receber chamadas do tipo POST
        public ActionResult CadastrarFornecedor(FornecedorCadastroViewModel model)
        {
            //verificar se os dados estão corretos
            //em relação as suas validações..
            if(ModelState.IsValid)
            {
                Fornecedor fornecedor = Mapper.Map<Fornecedor>(model);

                try
                {
                    FornecedorBusiness business = new FornecedorBusiness();
                    business.Cadastrar(fornecedor);

                    ViewBag.Mensagem = "Fornecedor cadastrado com sucesso.";
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
        public ActionResult AtualizarFornecedor(FornecedorEdicaoViewModel model)
        {
            //verificar se não há erros de validação
            if(ModelState.IsValid)
            {
                try
                {
                    //passando os dados da model para a entidade
                    Fornecedor fornecedor = Mapper.Map<Fornecedor>(model);

                    //atualizando..
                    FornecedorBusiness business = new FornecedorBusiness();
                    business.Atualizar(fornecedor);

                    TempData["Mensagem"] = "Fornecedor atualizado com sucesso.";
                    return RedirectToAction("Consulta", "Fornecedor");
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