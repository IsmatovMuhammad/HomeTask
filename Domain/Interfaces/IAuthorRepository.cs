using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthorRepository
{
    void AddAuthor(Author author);
    List<Author> GetAuthors();
    Author GetAuthor(int id);
    void DeleteAuthor(int id);
    void UpdateAuthor(Author author);
}