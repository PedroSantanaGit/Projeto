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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Cadastro()
        {
            return View();
        }

		[HttpPost] //receber chamadas do tipo POST
		public ActionResult CadastrarCliente(ClienteCadastroViewModel model)
		{
			//verificar se os dados estão corretos
			//em relação as suas validações..
			if (ModelState.IsValid)
			{
				Cliente cliente = Mapper.Map<Cliente>(model);

				try
				{
					ClienteBusiness business = new ClienteBusiness();
					business.Cadastrar(cliente);

					ViewBag.Mensagem = "Cliente cadastrado com sucesso.";
					ModelState.Clear(); //limpar todos os campos do formulário
				}
				catch (Exception e)
				{
					ViewBag.Mensagem = e.Message;
				}
			}

			//retornar para a página..
			return View("Cadastro");
		}


		// GET: Estoque/Consulta
		public ActionResult Consulta()
		{
			//criando uma lista classe de modelo..
			List<ClienteConsultaViewModel> model = new List<ClienteConsultaViewModel>();

			try
			{
				ClienteBusiness business = new ClienteBusiness();
				model = Mapper.Map<List<ClienteConsultaViewModel>>(business.ObterTodos());
			}
			catch (Exception e)
			{
				//imprimir mensagem de erro na página
				ViewBag.Mensagem = e.Message;
			}

			//enviar a lista para a página
			return View(model);
		}

		// GET: Cliente/Edicao/id
		public ActionResult Edicao(int id)
		{
			//criando um objeto da classe de modelo
			ClienteEdicaoViewModel model = new ClienteEdicaoViewModel();

			try
			{
				//buscar o estoque pelo id..
				ClienteBusiness business = new ClienteBusiness();
				Cliente cliente = business.ObterPorId(id);

				//transferir os dados de Estoque para EstoqueEdicaoViewModel
				model = Mapper.Map<ClienteEdicaoViewModel>(cliente);
			}
			catch (Exception e)
			{
				ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
			}

			//enviando o objeto para a página
			return View(model);
		}

		[HttpPost]
		public ActionResult AtualizarCliente(ClienteEdicaoViewModel model)
		{
			//verificar se não há erros de validação
			if (ModelState.IsValid)
			{
				try
				{
					//passando os dados da model para a entidade
					Cliente cliente = Mapper.Map<Cliente>(model);

					//atualizando..
					ClienteBusiness business = new ClienteBusiness();
					business.Atualizar(cliente);

					TempData["Mensagem"] = "Cliente atualizado com sucesso.";
					return RedirectToAction("Consulta", "Cliente");
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

		// GET: Cliente/Exclusao/id
		public ActionResult Exclusao(int id)
		{
			try
			{
				ClienteBusiness business = new ClienteBusiness();
				business.Excluir(id);

				TempData["Mensagem"] = "Estoque excluído com sucesso.";
			}
			catch (Exception e)
			{
				TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
			}

			//redirecionar para a página de consulta..
			//executando o método ActionResult Consulta()
			return RedirectToAction("Consulta", "Cliente");
		}

	}
}