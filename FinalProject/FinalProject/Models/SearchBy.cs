using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Models
{
    public class SearchBy
    {
        public string selectedAuthor { get; set; }

        public IEnumerable<SelectListItem> allAuthors { get; set; }

        public string selectedPublisher { get; set; }

        public IEnumerable<SelectListItem> allPublisher { get; set; }

        public string selectedLocation { get; set; }

        public IEnumerable<SelectListItem> allLocation { get; set; }
    }
}