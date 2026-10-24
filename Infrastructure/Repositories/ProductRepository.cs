using System.Runtime.InteropServices;
using Domain.Iterfrances;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class ProductRepository : IProduct
{
    public int Add(Products p)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "insert into products(name,price,quantity,category_id) values(@name,@price,@quantity,@category_id)";
        var cmd = new NpgsqlCommand(query,conn);
        cmd.Parameters.AddWithValue("name",p.Name);
        cmd.Parameters.AddWithValue("price",p.Price);
        cmd.Parameters.AddWithValue("quantity",p.Quantity);
        cmd.Parameters.AddWithValue("category_id",p.Category_Id);
        cmd.ExecuteNonQuery();
        return p.Id;
    }

    public bool Delete(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "delete from products where id = @id";
        var cmd = new NpgsqlCommand(query,conn);
        cmd.Parameters.AddWithValue("id",id);
        cmd.ExecuteNonQuery();
        return true;
    }

    public List<Products> GetAll()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select * from products";
        var cmd = new NpgsqlCommand(query,conn);
        var data = cmd.ExecuteReader();
        var productds = new List<Products>();
        while (data.Read())
        {
            var ct = new Products();
            ct.Id = data.GetInt32(0);
            ct.Name = data.GetString(1);
            ct.Price = data.GetDecimal(2);
            ct.Quantity = data.GetInt32(3);
            ct.Category_Id = data.GetInt32(4);
            productds.Add(ct);
        }
        return productds;
    }

    public Products GetById(int id)
    {
        using  var conn = Database.Connection();
        conn.Open();
        var query = "select * from products where id = @id";
        var cmd = new NpgsqlCommand(query,conn);
        cmd.Parameters.AddWithValue("id",id);
        var data = cmd.ExecuteReader();
        while(data.Read())
        {
            Products products = new Products()
            {
                Id = data.GetInt32(0),
                Name = data.GetString(1),
                Price = data.GetDecimal(2),
                Quantity = data.GetInt32(3),
                Category_Id = data.GetInt32(4)
            };
            return products;
        }
        return null!;
    }

    public List<Products> SearchByName(string term)
    {
        throw new NotImplementedException();
    }


    public bool Update(Products p)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "update products set name = @name, price = @price, quantity = @quantity, category_id = @category_id where id = @id";
        var cmd = new NpgsqlCommand(query,conn);
        cmd.Parameters.AddWithValue("name",p.Name);
        cmd.Parameters.AddWithValue("price",p.Price);
        cmd.Parameters.AddWithValue("quantity",p.Quantity);
        cmd.Parameters.AddWithValue("category_id",p.Category_Id);
        cmd.Parameters.AddWithValue("id",p.Id);
        cmd.ExecuteNonQuery();
        return true;
    }
    

}
