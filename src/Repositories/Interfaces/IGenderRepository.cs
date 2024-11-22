using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;

namespace Api_Taller.src.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        /// <summary>
        /// Obtiene los géneros disponibles.
        /// </summary>
        /// <returns>Lista con los géneros disponibles. </returns>
        Task<IEnumerable<Gender>> GetGenders();


        /// <summary>
        /// Valida si un género existe.
        /// </summary>
        /// <param name="id">La id del género. </param>
        /// <returns>Booleano de confirmación. </returns>
        Task<bool> ValidGenderId(int id);  
    }
}