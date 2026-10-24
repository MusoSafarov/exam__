using System.Reflection.Metadata;
using Domain.Models;

namespace Domain.Iterfrances;

public interface IProduct
{
    List<Products> GetAll();
    Products GetById (int id);
    int Add(Products p);
    bool Update(Products p);
    bool Delete (int id);
    List<Products> SearchByName(string term);
}
