using LMS.Model;
using LMS.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Controllers
{
    public class MemberOpsController : Controller
    {
        private readonly IBizLmsService _bizLmsService;

        public MemberOpsController(IBizLmsService bizLmsService)
        {
           _bizLmsService = bizLmsService;
        }

        public IActionResult Index()
        {
            var memberId = Convert.ToInt32(HttpContext.Session.GetString("member_userid"));
            var memberDetail = _bizLmsService.GetMemberDetail(memberId);
            ViewBag.Member = memberDetail.FirstName;
            return View();
        }

        public IActionResult Borrow()
        {
            var memberId = Convert.ToInt32(HttpContext.Session.GetString("member_userid"));
            Borrowed borrowed = new Borrowed()
            {
                MemberId = memberId,
                BorrowedDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(20),
            };
            ViewBag.BookIds = _bizLmsService.GetBooksList().Select(s => new SelectListItem() { 
                Text = s.BookId,
                Value = s.BookId
            });
            return View(borrowed);
        }

        [HttpPost]
        public IActionResult Borrow(Borrowed borrowed, string borrowedBookIds)
        {
            var bookIds = borrowedBookIds.Split(',').ToList();
            string errorString = string.Empty;
            foreach (var bookId in bookIds)
            {
                var bookPresent = _bizLmsService.CheckIfBookIsPresentUsingBookId(bookId);
                if (!bookPresent) {
                    errorString += "Enter Valid Book Ids";
                    ViewBag.Error = errorString;
                    return View(borrowed);
                }
            }
            foreach (var bookId in bookIds)
            {
                BookDetail book = _bizLmsService.GetBookDetailByBookDetial(bookId);
                Borrowed newBorrow = new Borrowed()
                {
                    BookId = book.Id,
                    MemberId = borrowed.MemberId,
                    BorrowedDate = borrowed.BorrowedDate,
                    ReturnDate = borrowed.ReturnDate,
                };
                _bizLmsService.AddBorrwed(newBorrow);
            }
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult ReturnRenew(int? borrowedBookId, int? RenewedBorrowedBookId, bool? renew)
        {
            var memberId = Convert.ToInt32(HttpContext.Session.GetString("member_userid"));
            List<Borrowed> borrowedBooks = _bizLmsService.GetBorrowedDetailsForMember(memberId);
            foreach (var item in borrowedBooks)
            {
                if(DateTime.Now > item.ReturnDate)
                {
                    var diffDays = (DateTime.Now - item.ReturnDate).Value.Days;
                    if(diffDays >= 1 && diffDays <= 5)
                    {
                        item.FineAmount = 2;
                    }
                    else if(diffDays >= 6 && diffDays <= 15)
                    {
                        item.FineAmount = 5;
                    }
                    else if(diffDays >= 15)
                    {
                        item.FineAmount = 10;
                    }
                }
            }

            if(borrowedBookId.HasValue) {
                ViewBag.FailedBorrowedBookId = borrowedBookId.Value;
                ViewBag.Error = "Pay fine first!";

                if(renew.HasValue && renew.Value)
                {
                    ViewBag.IsRenewTried = true;
                }
            }

            if (RenewedBorrowedBookId.HasValue)
            {
                ViewBag.RenewedBorrowedBookId = RenewedBorrowedBookId.Value;
            }

            return View(borrowedBooks);
        }

        public IActionResult ReturnBorrowedBook(int id)
        {
            var memberId = Convert.ToInt32(HttpContext.Session.GetString("member_userid"));
            Borrowed borrowedBook = _bizLmsService.GetBorrowedDetailsFromId(id);
            if (DateTime.Now > borrowedBook.ReturnDate)
            {
                return RedirectToAction("ReturnRenew", new { borrowedBookId = id, renew = false });
            }
            _bizLmsService.RemoveBorrowedBookDetails(borrowedBook);
            return RedirectToAction("ReturnRenew");
        }

        public IActionResult RenewBorrowedBook(int id)
        {
            var memberId = Convert.ToInt32(HttpContext.Session.GetString("member_userid"));
            Borrowed borrowedBook = _bizLmsService.GetBorrowedDetailsFromId(id);
            if (DateTime.Now > borrowedBook.ReturnDate)
            {
                return RedirectToAction("ReturnRenew", new { borrowedBookId = id, renew = true });
            }
            var prevReturnDate = borrowedBook.ReturnDate;
            borrowedBook.ReturnDate = prevReturnDate.Value.AddDays(14);
            _bizLmsService.UpdateBorrowedBookDetails(borrowedBook);
            return RedirectToAction("ReturnRenew", new { RenewedBorrowedBookId = borrowedBook.Id });
        }

        public IActionResult PayFine(int id, bool renew)
        {
            var memberId = Convert.ToInt32(HttpContext.Session.GetString("member_userid"));
            Borrowed borrowedBook = _bizLmsService.GetBorrowedDetailsFromId(id);
            Fine fine = new Fine();
            fine.FineDate = DateTime.Now;
            fine.MemberId = memberId;
            var diffDays = (DateTime.Now - borrowedBook.ReturnDate).Value.Days;
            if (diffDays >= 1 && diffDays <= 5)
            {
                fine.FineAmount = 2;
            }
            else if (diffDays >= 6 && diffDays <= 15)
            {
                fine.FineAmount = 5;
            }
            else if (diffDays >= 15)
            {
                fine.FineAmount = 10;
            }
            _bizLmsService.PayFine(fine);
            if (renew)
            {
                var prevReturnDate = borrowedBook.ReturnDate;
                borrowedBook.ReturnDate = prevReturnDate.Value.AddDays(14);
                _bizLmsService.UpdateBorrowedBookDetails(borrowedBook);
                return RedirectToAction("ReturnRenew", new { RenewedBorrowedBookId = borrowedBook.Id });
            }
            _bizLmsService.RemoveBorrowedBookDetails(borrowedBook);
            return RedirectToAction("ReturnRenew");
        }
    }
}
