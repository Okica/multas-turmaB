using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Multas.Models;

namespace Multas.Controllers
{
    public class AgentesController : Controller
    {
        //
        private MultasDb db = new MultasDb();

        // GET: Agentes
        public ActionResult Index()
        {
            //db.Agentes.ToList() -> em sql: SELECT * FROM Agentes
            return View(db.Agentes.ToList());
        }

        // GET: Agentes/Details/5
        // o ? significa que é um parametro de preenchimento facultativo
        public ActionResult Details(int? id)
        {
            //protecção para o caso de não ter sido fornecido um ID válido
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //procura na BD, o Agente cujo ID foi fornecido
            Agentes agentes = db.Agentes.Find(id);

            //protecção para o caso de não ter sido encontrado o Agente
            if (agentes == null)
            {
                return HttpNotFound();
            }
            //entrega à view os dados do Agente encontrado
            return View(agentes);
        }

        // GET: Agentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //anotador para HTTP POst
        [HttpPost]
        //anotador para protecção por roubo de identidade
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Esquadra,Fotografia")] Agentes agentes)
        { //escrever os dados de um novo Agente na BD

            //ModelState.IsValid ->confronta os dados fornecidas da View com as exigencias do Modelo
            if (ModelState.IsValid)
            {
                //adiciona o Agente à BD
                db.Agentes.Add(agentes);
                //guarda as alterações
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // se houver um erro, representa os dados do Agente na View
            return View(agentes);
        }

        // GET: Agentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                //neste caso já existe um Agente
                //apenas quero editar os seus dados
                db.Entry(agentes).State = EntityState.Modified;
                //guardar
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agentes);
        }

        // GET: Agentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agentes agentes = db.Agentes.Find(id);
            //remove o Agente da BD
            db.Agentes.Remove(agentes);
            //guardar
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
