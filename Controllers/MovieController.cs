using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interface_Layer.Master_Interface;
using Model_Layer.Master_Model;

namespace Web_Layer.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        I_Movie imovie;
        public MovieController(I_Movie init) 
        {
            imovie = init;
        }
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult SaveUpdate(Movie movie)
		{
            try
            {
                var res = imovie.SaveUpdate(movie);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
        public ActionResult List()
        {
            try
            {
                var res = imovie.List();
                return View(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            } 
        public ActionResult Edit(int id)
        {
            try
            {
                var res = imovie.Edit(id);
                return View("Index", res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var res = imovie.Delete(id);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}