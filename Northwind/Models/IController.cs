using System.Collections.Generic;

namespace Northwind.Models
{
    public interface IContext
    {
        List<Category> GetAll();

        Category Find(string id);

        IEnumerable<Product> FindBy(string id);
    }
}
