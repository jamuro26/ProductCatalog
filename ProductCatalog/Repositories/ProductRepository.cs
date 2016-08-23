using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductCatalog.Models;
using ProductCatalog.Interface;

namespace ProductCatalog.Repositories
{
    /// <summary>
    /// Clase que contiene los metodos que realizan la logica de agregar, actualizar, obtener por id y todo, y borrar
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        DatabaseEntities ProductDB = new DatabaseEntities();

        /// <summary>
        /// Metodo para obtener una lista de la entidad Producto
        /// </summary>
        /// <returns>Lista de Productos.</returns>
        public IEnumerable<Product> Get()
        {
            return ProductDB.Product;
        }

        /// <summary>
        /// Metodo para obtener un registro de la entidad Producto.
        /// </summary>
        /// <param name="id">Identificador unico del producto</param>
        /// <returns>Entidad Producto por Id</returns>
        public Product Get(int id)
        {
            return ProductDB.Product.Find(id);
        }

        /// <summary>
        /// Metodo para agregar un registro a la entidad Producto.
        /// </summary>
        /// <param name="item">Item de tipo Producto para agregar</param>
        /// <returns></returns>
        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.CreatedDate = DateTime.Now;

            ProductDB.Product.Add(item);
            ProductDB.SaveChanges();
            return item;
        }

        /// <summary>
        /// Metodo que realiza la actualizacion de un producto.
        /// </summary>
        /// <param name="item">Item de Tipo Producto</param>
        /// <returns>Verdadero para indicar que se actualizó el registro</returns>
        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var products = ProductDB.Product.Single(a => a.Id == item.Id);
            products.Name = item.Name;
            products.Brand = item.Brand;
            products.Size = item.Size;
            products.Price = item.Price;
            products.QualityInStock = item.QualityInStock;
            products.UpdatedDate = DateTime.Now;
            ProductDB.SaveChanges();

            return true;
        }

        /// <summary>
        /// Metodo que realiza el borrado de un registro de Producto.
        /// </summary>
        /// <param name="id">Identificador unico del producto</param>
        /// <returns>Verdadero para indicar que se realizó la acción</returns>
        public bool Delete(int id)
        {
            

            Product products = ProductDB.Product.Find(id);
            ProductDB.Product.Remove(products);
            ProductDB.SaveChanges();

            return true;
        }
    }
}