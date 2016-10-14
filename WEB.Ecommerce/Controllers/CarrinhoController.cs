using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB.Ecommerce.Data;
using WEB.Ecommerce.Models;

namespace WEB.Ecommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        private DataContexto db = new DataContexto();

        // GET: Carrinho
        public ActionResult Index()
        {
            var carrinho = db.Carrinho.Include(c => c.Cliente).Include(c => c.Produto);
            return View(carrinho.ToList());
        }

        // GET: Carrinho/Details/5
        public ActionResult Details(int? id)
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

        // GET: Carrinho/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Nome");
            return View();
        }

        // POST: Carrinho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarrinhoId,ClienteId,ProdutoId,Quantidade,DataCadastro")] Carrinho carrinho)
        {
            if (ModelState.IsValid)
            {
                db.Carrinho.Add(carrinho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", carrinho.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produto, "ProdutoId", "Nome", carrinho.ProdutoId);
            return View(carrinho);
        }

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
    }
}
