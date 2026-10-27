using System.Diagnostics.Contracts;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepository : IGenreRepository
{
    public void AddGenre(Genre genre)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "insert into genres(name)values(@genres)";
        conn.Execute(query, genre);
        System.Console.WriteLine("Genre added !!");
    }

    public void Deletegenre(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "delete from genres where id = @id";
        conn.Execute(query, id);
        System.Console.WriteLine("Genre deleted !!");
    }

    public Genre? GetGenre(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from genres where id = @id";
        var genre = conn.QuerySingleOrDefault<Genre>(query, id);
        return genre;
    }

    public List<Genre> GetGenres()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from genres";
        var genre = conn.Query<Genre>(query).ToList();
        return genre;
    }

    public void UpdateGenre(Genre genre)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update genres set name = @name where id = @id";
        conn.Execute(query, genre);
    }

}
