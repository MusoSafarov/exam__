using Domain.Models;

namespace Domain.Iterfrances;

public interface ICategory
{
    List<Categories> GetAll();
    Categories GetById (int id);
    int Add(Categories c);
    bool Update(Categories c);
    bool Delete (int id);
}
