using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductCatalog.Models;

namespace ProductCatalog.Interface
{
    /// <summary>
    /// Interface para invocar los metodos desde el repositorio
    /// </summary>
    interface IProductRepository
    {
        Product Add(Product item);
        bool Update(Product item);
        bool Delete(int id);
        IEnumerable<Product> Get();
        Product Get(int id);
    }
}