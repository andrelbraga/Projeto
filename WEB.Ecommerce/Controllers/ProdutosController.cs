﻿using System;
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
    public class ProdutosController : Controller
    {
        private DataContexto db = new DataContexto();

        // GET: Produtos
        public ActionResult Index(int id)
        {
            var usuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var VendedorCorrent = usuario.FindByEmail(User.Identity.Name).Vendedor;

            if (VendedorCorrent)
            {
              Vendedor vendedor = new Vendedor();
              var produto = db.Produto.Where(x => x.VendedorId == id).ToList();  
            }

            var produtoPorCategoria = db.Produto.Include(p => p.Categoria).ToList();
            return View(produtoPorCategoria);
            
           
        }

        // retorna a imagem associada a um filme
        public ActionResult GetImage(int id)
        {
            Produto produto = db.Produto.Find(id);
            if (produto != null && produto.ImageFile != null)
            {
                //File used to return a binary content and the contenttype of the returned photo
                return File(produto.ImageFile, produto.ImageMimeType);
            }
            else
            {
                return new FilePathResult("~/Images/nao-disponivel.jpg", "image/jpeg");
            }
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Tipo");
            //ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Quando vendedor está criando
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Nome,Descricao,ImageFile,ImageMimeType,ImageUrl,Preco,Status,CategoriaId,ClienteId,DataCadastro")] Produto produto,
            HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    produto.ImageMimeType = image.ContentType;
                    produto.ImageFile = new byte[image.ContentLength];
                    //save the photo file by using image.InputStream.Read method.
                    image.InputStream.Read(produto.ImageFile, 0, image.ContentLength);
                }

                 
                UserManager<ApplicationUser> id = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                string nome = id.FindByName(User.Identity.Name).NomeUsuario;
                Vendedor input = db.Vendedor.FirstOrDefault(x => x.Nome == nome);
                produto.VendedorId = input.VendedorId;

                

                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Tipo", produto.CategoriaId);
            //ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Tipo", produto.CategoriaId);
            //ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }


        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,Nome,Descricao,ImageFile,ImageMimeType,ImageUrl,Preco,Status,CategoriaId,ClienteId,DataCadastro")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Tipo", produto.CategoriaId);
            //ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produto.Find(id);
            db.Produto.Remove(produto);
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

        [ChildActionOnly]
        public ActionResult CategoriasMenu(int num = 9)
        {
            var catego = db.Categoria
            .OrderByDescending(g => g.Produtos.Count)
            .Take(num)
            .ToList();
            return this.PartialView(catego);
        }

        public ActionResult Browse(string categoria = "Action")
        {
            var cate = db.Categoria.SingleOrDefault(g => g.Tipo == categoria);

            return View(cate);
        }

        [ChildActionOnly]
        public ActionResult CategoriasVendedor(int id)
        {


           List<Produto> prod = db.Produto.Where(x => x.VendedorId == id).ToList();

            return View(prod);
        }



    }
}
