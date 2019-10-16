using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entities;
using System.Data.SqlClient;
using System.Configuration;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Controllers
{
    public class UsuarioController : Controller
    {

		
		SqlConnection Connection = new SqlConnection();
		SqlCommand Command = new SqlCommand();
		//SqlDataReader dr;
        // GET: Usuario
		[HttpGet]
        public ActionResult Login()
        {
            return View();
        }

		void ConnectionString()
		{
			Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString);
		}


		
		[HttpPost]
		public ActionResult Verificar(Usuario usuario)
		{
			
			ConnectionString();
			Connection.Open();
			Command.Connection = Connection;
			string query = "select * from Usuario where Nome=@nome and Senha=@senha";
			Command = new SqlCommand(query, Connection);
			
			
			Command.Parameters.AddWithValue("@nome", usuario.Nome);
			Command.Parameters.AddWithValue("@senha", usuario.Senha);
			SqlDataReader dr = Command.ExecuteReader();			
			
			if (dr.Read())
			{			

				Connection.Close();	
				return View("~/Views/Home/Index.cshtml");

			}
			else
			{
				Connection.Close();

				return View("Login");

				
				
			}

			
			
		}
    }
}