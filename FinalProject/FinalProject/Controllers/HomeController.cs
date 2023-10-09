using FinalProject.Models;
using FinalProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

        public ActionResult BookDetails(BOOK book)
        {
            return View(book);
        }

        public ActionResult BrowseByAuthor()
        {
            List<BOOK> noBooks = new List<BOOK>();
            return View(noBooks);
        }

        public ActionResult BrowseByAuthorPost(string selectedAuthor)
        {
            int authorNum = int.Parse(selectedAuthor);


            var filteredBooks = (
            from book in database.BOOKs
            join wrote in database.WROTEs on book.BOOK_CODE equals wrote.BOOK_CODE
            where wrote.AUTHOR_NUM == authorNum
            select book
            ).ToList();

            return View("BrowseByAuthor", filteredBooks);
        }

        public ActionResult BrowseByPublisher()
        {
            List<BOOK> noBooks = new List<BOOK>();
            return View(noBooks);
        }

        public ActionResult BrowseByPublisherPost(string selectedPublisher)
        {
            string pubCode = selectedPublisher;


            var filteredBooks = database.BOOKs.Where(book => book.PUBLISHER_CODE == pubCode).ToList();

            return View("BrowseByPublisher", filteredBooks);
        }

        public ActionResult BrowseByLocation()
        {
            List<BOOK> noBooks = new List<BOOK>();

            ViewBag.FilteredBooks = noBooks;
            ViewBag.BranchNum = null;

            Debug.WriteLine("WAAA");

            return View(noBooks);
        }

        public ActionResult BrowseByLocationPost(string selectedLocation)
        {
            int branchNum = int.Parse(selectedLocation);


            var filteredBooks = (
            from book in database.BOOKs
            join inventory in database.INVENTORies on book.BOOK_CODE equals inventory.BOOK_CODE
            where inventory.BRANCH_NUM == branchNum
            select book
            ).ToList();

            ViewBag.FilteredBooks = filteredBooks;
            ViewBag.BranchNum = branchNum;

            Debug.WriteLine("RUNNITn");

            return View("BrowseByLocation");
        }


        public ActionResult BrowseByPublisherSelected(PUBLISHER publisher)
        {
            return View("BrowseByPublisher", publisher);
        }

        public ActionResult ContactManagement()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ContactManagement(ContactManagement model)
        {
            ViewBag.Message = "User Added";

            return Json(model);
        }

    }
}