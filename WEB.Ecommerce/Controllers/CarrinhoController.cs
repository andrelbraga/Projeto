using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WEB.Ecommerce.Data;
using WEB.Ecommerce.Models;

namespace WEB.Ecommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        private DataContexto db = new DataContexto();

        // GET: Carrinho
        public ActionResult Index(string id)
        {

            ViewBag.Model = new Produto();

            var usuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var ClienteCorrent = usuario.FindByEmail(User.Identity.Name).Cliente;

            if (ClienteCorrent)
            {
                var NomeC = usuario.FindByEmail(User.Identity.Name).NomeUsuario;
                List<Cliente> client = db.Cliente.Where(x => x.Nome == NomeC).ToList();
                var carrinh = db.Carrinho.Where(x => x.Cliente.Nome == id).ToList();
                if (carrinh != null)
                {
                    var carrinhoo = db.Carrinho.Include(c => c.Cliente).Include(c => c.Produto).Where(x => x.Cliente.Nome == id).ToList();
                    return View(carrinhoo.ToList());
                }
            }
            

            var carrinho = db.Carrinho.Include(c => c.Cliente).Include(c => c.Produto);
            return View(carrinho.ToList());
        }

        // GET: Carrinho/Details/5
        public ActionResult Details(int? id, int cliente, int produto)
        {
            Carrinho carrinho = db.Carrinho.Find(id);
            carrinho.ClienteId = cliente;
            carrinho.ProdutoId = produto;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (carrinho == null)
            {
                return HttpNotFound();
            }
            return View(carrinho);
        }

        // GET: Carrinho/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome");
        //    ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Nome");
        //    return View();
        //}

        // POST: Carrinho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CarrinhoId,ClienteId,ProdutoId,Quantidade,DataCadastro")] Carrinho carrinho)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Carrinho.Add(carrinho);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", carrinho.ClienteId);
        //    ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Nome", carrinho.ProdutoId);
        //    return View(carrinho);
        //}

        // GET: Carrinho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrinho carrinho = db.Carrinho.Find(id);
            if (carrinho == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", carrinho.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Nome", carrinho.ProdutoId);
            return View(carrinho);
        }

        // POST: Carrinho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarrinhoId,ClienteId,ProdutoId,Quantidade,DataCadastro")] Carrinho carrinho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrinho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", carrinho.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Nome", carrinho.ProdutoId);
            return View(carrinho);
        }

        // GET: Carrinho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrinho carrinho = db.Carrinho.Find(id);
            if (carrinho == null)
            {
                return HttpNotFound();
            }
            return View(carrinho);
        }

        // POST: Carrinho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrinho carrinho = db.Carrinho.Find(id);
            db.Carrinho.Remove(carrinho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Adcionar(int idCliente, int idProduto)
        {
            Carrinho carr = new Carrinho();

            carr.ClienteId = idCliente;
            carr.ProdutoId = idProduto;
            

            return View(carr);

        }


        //Quando Cliente adciona produto no carrinho
        public ActionResult Criar(int idProduto)
        {
            Carrinho carr = new Carrinho();

            UserManager<ApplicationUser> id = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            string nome = id.FindByName(User.Identity.Name).NomeUsuario;
            Cliente input = db.Cliente.FirstOrDefault(x => x.Nome == nome);
            carr.ClienteId = input.ClienteId;

            
            carr.ProdutoId = idProduto;
            db.Carrinho.Add(carr);
            db.SaveChanges();

            return RedirectToAction("Index", "Home", "HomeController" );
            

        }
    }
}
