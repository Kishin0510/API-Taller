using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        /// <summary>
        /// Obtiene todas las compras.
        /// </summary>
        /// <returns>Lista con todas las compras. </returns>
        Task<IEnumerable<Purchase>> GetAllPurchases();

        /// <summary>
        /// Crea una boleta de compra nueva. 
        /// </summary>
        /// <param name="purchase">La compra a añadir. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> CreatePurchase(Purchase purchase);

        /// <summary>
        /// Obtiene las compras de un usuario por su id.
        /// </summary>
        /// <param name="id">La id del usuario. </param>
        /// <returns></returns>
        Task<IEnumerable<Purchase>> GetPurchaseById(int id);


        /// <summary>
        /// Busca compras por nombre de usuario y fecha.
        /// </summary>
        /// <param name="nameQuery">Nombre del usuario. </param>
        /// <param name="dateQuery">Fecha de creación. </param>
        /// <returns></returns>
        Task<IEnumerable<Purchase>> SearchPurchases(String nameQuery, string dateQuery);
        
    }
}