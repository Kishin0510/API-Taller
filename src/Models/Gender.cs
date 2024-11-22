using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class Gender
    {
        /// <summary>
        /// Id del género.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tipo de género.
        /// </summary>
        public string Type { get; set; } = null!;
    }
}