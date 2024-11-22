using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Taller.src.Models
{
    public class Role
    {
        /// <summary>
        /// Id del rol.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del rol.
        /// </summary>
        public string Name { get; set; } = null!;
    }
}