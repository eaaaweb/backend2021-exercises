using MbmStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MbmStore.Data
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBookList();
        Book GetBookById(int id);
        void SaveBook(Book book);
        Book DeleteBook(int bookId);
        bool BookExists(int id);
       
    }
}
