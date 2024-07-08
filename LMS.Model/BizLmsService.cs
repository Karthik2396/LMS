using LMS.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model
{
    public class BizLmsService : IBizLmsService
    {
        private readonly LmsContext _context;

        public BizLmsService(LmsContext context)
        {
            _context = context;       
        }

        public BookDetail AddBookDetail(BookDetail bookDetail)
        {
            _context.BookDetails.Add(bookDetail);
            _context.SaveChanges();
            return bookDetail;
        }

        public void AddBorrwed(Borrowed borrowed)
        {
            _context.Borroweds.Add(borrowed);
            _context.SaveChanges();
            return;
        }

        public void AddNewMember(MemberDetail member)
        {
            _context.MemberDetails.Add(member);
            _context.SaveChanges();
            return;
        }

        public bool CheckIfBookIsPresentUsingBookId(string bookId)
        {
            var book = _context.BookDetails.FirstOrDefault(w => w.BookId.ToLower().Trim().Equals(bookId.ToLower().Trim()));
            if (book == null) { return false; }
            return true;
        }

        public bool CheckIfMemberPresent(MemberDetail member)
        {
            var memberDetail = _context.MemberDetails.FirstOrDefault(w => w.MemberId == member.MemberId || w.Username == member.Username);
            if (memberDetail == null)
            {
                return false;
            }
            return true;
        }

        public BookDetail EditBookDetail(BookDetail bookDetail)
        {
            _context.Entry(bookDetail).State = EntityState.Modified; 
            _context.SaveChanges();
            return bookDetail;
        }

        public List<Category> GetBookCategories()
        {
            return _context.Categories.Select(s => s).ToList();
        }

        public BookDetail GetBookDetail(int id)
        {
            var BookDetails = _context.BookDetails.Where(w => w.Id == id).Include("CategoryNavigation").Select(s => s).FirstOrDefault();
            return BookDetails;
        }

        public BookDetail GetBookDetailByBookDetial(string bookId)
        {
            var book = _context.BookDetails.Where(w => w.BookId.ToLower().Trim().Equals(bookId.ToLower().Trim())).Select(s => s).FirstOrDefault();
            return book;
        }

        public List<BookDetail> GetBooksList()
        {
            var BookDetails = _context.BookDetails.Select(s => s).Include("CategoryNavigation").ToList();
            return BookDetails;
        }

        public List<Borrowed> GetBorrowedDetailsForMember(int memberId)
        {
            return _context.Borroweds.Where(w => w.MemberId == memberId).Include("Book").Select(s => s).ToList();
        }

        public Borrowed GetBorrowedDetailsFromId(int id)
        {
            return _context.Borroweds.FirstOrDefault(w => w.Id == id);
        }

        public List<Fine> GetFineCollected()
        {
            List<Fine> fineCollected = _context.Fines.Include("Member")
                    .Select(s => s).OrderBy(o => o.FineDate).ToList();
            return fineCollected;
        }

        public MemberDetail GetMemberDetail(int memberId)
        {
            return _context.MemberDetails.FirstOrDefault(w => w.Id == memberId);
        }

        public async Task<Librarian> LibrarianLogin(string username, string password)
        {
            var user = await _context.Librarians.Where(w => w.Username == username && w.Password == password).FirstOrDefaultAsync();
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<MemberDetail> MemberLogin(string username, string password)
        {
            var user = await _context.MemberDetails.Where(w => w.Username == username && w.Password == password).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void PayFine(Fine fine)
        {
            _context.Fines.Add(fine);
            _context.SaveChanges();
            return;
        }

        public void RemoveBook(int id)
        {
            var book = _context.BookDetails.FirstOrDefault(w => w.Id == id);
            _context.BookDetails.Remove(book);
            _context.SaveChanges();
        }

        public void RemoveBorrowedBookDetails(Borrowed borrowedBook)
        {
            _context.Borroweds.Remove(borrowedBook);
            _context.SaveChanges();
            return;
        }

        public void UpdateBorrowedBookDetails(Borrowed borrowedBook)
        {
            _context.Entry(borrowedBook).State = EntityState.Modified;
            _context.SaveChanges();
            return;
        }
    }
}
