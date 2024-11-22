using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {

        /// <summary>
        /// Obtiene todos los tipos de productos.
        /// </summary>
        /// <returns>Lista con los tipos de productos. </returns>
        Task<IEnumerable<ProductType>> GetProductTypes();

        /// <summary>
        /// Valida si un tipo de producto existe.
        /// </summary>
        /// <param name="id">La id del tipo. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> ValidProductType(int id);

        /// <summary>
        /// Obtiene un tipo de producto por su id.
        /// </summary>
        /// <param name="id">La id del tipo. </param>
        /// <returns>El tipo de producto. </returns>
        Task<ProductType?> GetProductType(int id);
    }
}