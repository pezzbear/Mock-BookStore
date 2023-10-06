﻿using FinalProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public HENRY_DATABASEEntities database = new HENRY_DATABASEEntities();

        public ActionResult Index()
        {
            var allBooks = database.BOOKs.ToList();

            return View(allBooks);
        }

        public ActionResult BrowseInventory()
        {
            var allBooks = database.BOOKs.ToList();

            return View(allBooks);
        }

        public ActionResult BrowseByAuthor()
        {
            return View();
        }

        public ActionResult BrowseByAuthorSelected(AUTHOR author) 
        {
            return View("BrowseByAuthor", author);
        }

        public ActionResult BookDetails(BOOK book)
        {
            return View(book);
        }

        public ActionResult BrowseByLocation()
        {
            return View();
        }

        public ActionResult BrowseByLocationSelected(BRANCH branch)
        {
            return View("BrowseByLocation", branch);
        }

        public ActionResult BrowseByPublisher()
        {
            return View();
        }

        public ActionResult BrowseByPublisherSelected(PUBLISHER publisher)
        {
            return View("BrowseByPublisher", publisher);
        }

        public ActionResult ContactManagement()
        {
            return View();
        }

    }
}