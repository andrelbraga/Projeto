using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WEB.Ecommerce.Data;
using WEB.Ecommerce.Models;

namespace WEB.Ecommerce.Controllers
{
    public class MensagemController : Controller
    {
        private DataContexto db = new DataContexto();

        // GET: Mensagem
        public ActionResult Index()
        {
            List<Mensagem> msg = new List<Mensagem>();

           
            UserManager<ApplicationUser> id = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            string nome = id.FindByName(User.Identity.Name).NomeUsuario;
            
             Vendedor vendedor = db.Vendedor.FirstOrDefault(x => x.Nome == nome);
             Cliente cliente = db.Cliente.FirstOrDefault(x => x.Nome == nome);
 

            if (vendedor != null && nome == vendedor.Nome)
            {
                Vendedor input = db.Vendedor.FirstOrDefault(x => x.Nome == nome);
                 int idVendedor = input.VendedorId;
                 msg = db.Mensagem.Where(x => x.VendedorId == idVendedor).ToList();
                return View(msg);
            }

            if (nome != null && nome == cliente.Nome)
            {
                Cliente input = db.Cliente.FirstOrDefault(x => x.Nome == nome);
                int idCliente = input.ClienteId;
                msg = db.Mensagem.Where(x => x.ClienteId == idCliente).ToList();

                return View(msg);
            }

            return View(msg);

        }

        // GET: Mensagem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagem mensagem = db.Mensagem.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }

        // GET: Mensagem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mensagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MensagenId,Titulo,Texto,ClienteId")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                db.Mensagem.Add(mensagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mensagem);
        }

        // GET: Mensagem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagem mensagem = db.Mensagem.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }

        // POST: Mensagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MensagenId,Titulo,Texto,ClienteId")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mensagem);
        }

        // GET: Mensagem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagem mensagem = db.Mensagem.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }

        // POST: Mensagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mensagem mensagem = db.Mensagem.Find(id);
            db.Mensagem.Remove(mensagem);
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
    }
}
