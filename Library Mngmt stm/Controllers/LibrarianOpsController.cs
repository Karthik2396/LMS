using LibraryManagementSystem.Models;
using LMS.Model;
using LMS.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Controllers
{
    public class LibrarianOpsController : Controller
    {
        private readonly IBizLmsService _bizLmsService;

        public LibrarianOpsController(IBizLmsService bizLmsService)
        {
            _bizLmsService = bizLmsService;
        }
        public IActionResult Index()
        {
            var books = _bizLmsService.GetBooksList();
            List<Fine> fineCollected = _bizLmsService.GetFineCollected();
            ViewData["FineCollected"] = fineCollected;
            return View(books);
        }

        public IActionResult Create()
        {
            var categories = _bizLmsService.GetBookCategories();
            //ViewBag.Category = new SelectList(categories);
            ViewBag.Category = categories.Select(s => new SelectListItem()
            {
                Text = s.CatName,
                Value = s.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookDetail bookDetail)
        {
            TryUpdateModelAsync(bookDetail);
            var books = _bizLmsService.AddBookDetail(bookDetail);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var categories = _bizLmsService.GetBookCategories();
            //ViewBag.Category = new SelectList(categories);
            ViewBag.Category = categories.Select(s => new SelectListItem()
            {
                Text = s.CatName,
                Value = s.Id.ToString()
            });
            var books = _bizLmsService.GetBookDetail(id);
            return View(books);
        }

        [HttpPost]
        public IActionResult Edit(BookDetail bookDetail)
        {
            TryUpdateModelAsync(bookDetail);
            var books = _bizLmsService.EditBookDetail(bookDetail);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var books = _bizLmsService.GetBookDetail(id);
            return View(books);
        }

        public IActionResult Delete(int id)
        {
            _bizLmsService.RemoveBook(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMember(MemberDetail member)
        {
            TryUpdateModelAsync(member);
            bool memberPresent = _bizLmsService.CheckIfMemberPresent(member);
            if (memberPresent)
            {
                ViewBag.Error = "Member with same Id or username already present!";
                return View(member);
            }
            _bizLmsService.AddNewMember(member);
            return RedirectToAction("Index");
        }
    }
}
