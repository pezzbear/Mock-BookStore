using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models.EntityFramework;
using FinalProject.Models;


namespace FinalProject.Controllers
{
    public class SearchByController : Controller
    {

        HENRY_DATABASEEntities db = new HENRY_DATABASEEntities();
        // GET: SearchBy
        public ActionResult SearchByAuthor()
        {
            SearchBy model = new SearchBy();

            model.allAuthors = db.AUTHORs.ToList().Select(x => new SelectListItem
            {
                Text = x.AUTHOR_FIRST + " " + x.AUTHOR_LAST,
                Value = x.AUTHOR_NUM.ToString()
            });

            return PartialView("~/Views/Shared/_SearchByAuthor.cshtml", model);
        }
    }
}