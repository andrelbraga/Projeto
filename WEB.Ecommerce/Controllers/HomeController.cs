using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Ecommerce.Data;
using WEB.Ecommerce.Models;

namespace WEB.Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private DataContexto db = new DataContexto();

        public ActionResult Index(Categoria categoria, string tipo)
        {
            var cate = db.Categoria.Where(g => g.Tipo != null).ToList();

            return View(cate);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //
        
    }
}