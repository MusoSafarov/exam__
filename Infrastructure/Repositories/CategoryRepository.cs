using System.Xml.XPath;
using Domain.Iterfrances;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategory
{
    public int Add(Categories c)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "insert into categories(name) values(@name)";
        var cmd = new NpgsqlCommand(query,conn);
        cmd.Parameters.AddWithValue("name",c.Name);
        cmd.ExecuteNonQuery();
        return c.Id;
    }

    public bool Delete(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "delete from categories where id = @id";
        var cmd = new NpgsqlCommand(query,conn);
        cmd.Parameters.AddWithValue("id",id);
        cmd.ExecuteNonQuery();
        return true;
    }

    public List<Categories> GetAll()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select * from categories";
        var cmd = new NpgsqlCommand(query,conn);
        var data = cmd.ExecuteReader();
        var categories1 = new List<Categories>();
        while (data.Read())
        {
            var ct = new Categories();
            ct.Id = data.GetInt32(0);
            ct.Name = data.GetString(1);
            categories1.Add(ct);
        }
        return categories1;
    }

    public Categories GetById(int id)
    {
        using  var conn = Database.Connection();
        conn.Open();
        var query = "select * from categories where id = @id";
        var cmd = new NpgsqlCommand(query,conn);
        cmd.Parameters.AddWithValue("id",id);
        var data = cmd.ExecuteReader();
        while (data.Read())
        {
            Categories cate = new Categories();
            cate.Id = data.GetInt32(0);
            cate.Name = data.GetString(1);
            return cate;
        }
        return null!;
    }

    public bool Update(Categories c)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "update categories set name = @name where id = @id";
        var cmd = new NpgsqlCommand(query,conn);
        cmd.Parameters.AddWithValue("name",c.Name);
        cmd.Parameters.AddWithValue("id",c.Id);
        cmd.ExecuteNonQuery();
        return true;


    }

}
