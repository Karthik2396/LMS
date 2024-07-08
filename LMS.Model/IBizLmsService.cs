using LMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model
{
    public interface IBizLmsService
    {
        BookDetail AddBookDetail(BookDetail bookDetail);
        void AddBorrwed(Borrowed borrowed);
        void AddNewMember(MemberDetail member);
        bool CheckIfBookIsPresentUsingBookId(string bookId);
        bool CheckIfMemberPresent(MemberDetail member);
        BookDetail EditBookDetail(BookDetail bookDetail);
        List<Category> GetBookCategories();
        BookDetail GetBookDetail(int id);
        BookDetail GetBookDetailByBookDetial(string bookId);
        List<BookDetail> GetBooksList();
        List<Borrowed> GetBorrowedDetailsForMember(int memberId);
        Borrowed GetBorrowedDetailsFromId(int id);
        List<Fine> GetFineCollected();
        MemberDetail GetMemberDetail(int memberId);
        Task<Librarian> LibrarianLogin(string username, string password);
        Task<MemberDetail> MemberLogin(string username, string password);
        void PayFine(Fine fine);
        void RemoveBook(int id);
        void RemoveBorrowedBookDetails(Borrowed borrowedBook);
        void UpdateBorrowedBookDetails(Borrowed borrowedBook);
    }
}
