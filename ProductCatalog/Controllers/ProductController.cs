using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductCatalog.Models;
using ProductCatalog.Interface;
using ProductCatalog.Repositories;

namespace ProductCatalog.Controllers
{
    /// <summary>
    /// Controlador para Producto.
    /// </summary>
    public class ProductController : ApiController
    {
        /// <summary>
        /// Se crea una instancia del repositorio para poder obtener los metodos.
        /// </summary>
        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable GetAllProducts()
        {
            return repository.Get();
        }

        /// <summary>
        /// Metodo que sirve para incluir un registro 
        /// </summary>
        /// <param name="item">Item de un Producto</param>
        /// <returns></returns>
        public Product PostProduct(Product item)
        {
            return repository.Add(item);
        }

        /// <summary>
        /// Método que sirve para actualizar la informacion de un producto.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public IEnumerable PutProduct(int id, Product product)
        {
            product.Id = id;
            if (repository.Update(product))
            {
                return repository.Get();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Invocaion del metodo para Borrar Producto.
        /// </summary>
        /// <param name="id">Identificador único del Producto</param>
        /// <returns>Verdadero para indicar que se llevó a cabo el borrado</returns>
        public bool DeleteProduct(int id)
        {
            if (repository.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
