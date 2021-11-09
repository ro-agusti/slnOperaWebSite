using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OperaWebSites.Models;//agregar
using OperaWebSites.Data; // agregar
using System.Data.Entity; //agregar
//using System.Diagnostics; //agregar - para imprimir en la consola y q se registren
using OperaWebSites.Filters;//agregar

namespace OperaWebSites.Controllers
{
    [MyFilterAction]
    public class OperaController : Controller
    {
        //crear instancia del dbContext
        private OperaDbContext context = new OperaDbContext();

        // GET: Opera o /Opera/Index (nombre del metodo)
        public ActionResult Index()
        {
            //traer todas las operas usando EF
            var operas = context.Operas.ToList();

            //el controller retorna una vista con el mismo nombre q el metodo, con la lista de operas
            return View("Index", operas); 
        }

        //creamos dos metodos para la insercion de la opera en la DB
        //priemero crear por GET para retornar la vista de registro
        [HttpGet]//el get es implicito, no es obligatorio crear
        public ActionResult Create()
        {
            //creamos la instancia con valores en las properties
            Opera opera = new Opera();
            //retornamos la vista que tiene el objeto opera
            return View("Create", opera);
        }

        //segundo crear es por POST para insertar la nueva opera en la DB
        //cuando el usuario en la vista crear hace click en enviar ahi va por el httpPost
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            //chequea q las proiedades q el usuario envia los datos con las required, las validaciones personalizadas como se debe
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", opera);
        }

        //GET
        // Controller/Action/id
        //RUTA --> Opera/Detail/2
        //[HttpGet("{id}")] --OPCIONAL
        public ActionResult Detail ( int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Detail", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //DELETE
        //--get (para enviar al cliente una vista con los detalles a eliminar, si confirma --> POST)
        //RUTA --> Opera/Delete/2
        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }
        //--post
        //RUTA --> Opera/Delete/2
        [HttpPost]
        [ActionName("Delete")]//para q la ruta sea delete y no deleteconfirmed
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                context.Operas.Remove(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Edit", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Opera opera)
        {
            context.Entry(opera).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //ocurre antes de la accion
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //Console.WriteLine("Paso por OnActionExecuting");

        //    //si quiero q especifique que control de esta ejecutando, con el parametro filterContext
        //    //encontrar q controlador se esta utiizando
        //    //Opera
        //    var operaController = filterContext.RouteData.Values["Controller"];
        //    //ver q accion se esta ejecutando
        //    //Opera/Create
        //    var operaAction = filterContext.RouteData.Values["Values"];
        //    Debug.WriteLine("Controller"+ operaController + "Action: " + operaAction + " Paso por OnActionExecuting");

        //}

        ////ocurre despues de la accion 
        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    var operaController = filterContext.RouteData.Values["Controller"];
        //    var operaAction = filterContext.RouteData.Values["Values"];
        //    Debug.WriteLine("Controller" + operaController + "Action: " + operaAction + " Paso por OnActionExecuted");
        //}
    }
    }
//@Html.HiddenFor(model => model.OperaId) --para ocultar el id en la view de edit
