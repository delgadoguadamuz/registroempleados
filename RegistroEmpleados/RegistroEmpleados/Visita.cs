using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEmpleados
{
   public  class Visita
    {
 

            public int VisitaId { get; set; }

            public string NombreVisita { get; set; }

            public string Apellido { get; set; }

            public string Vendor { get; set; }

            public string Descripcion { get; set; }

            public DateTime FechaHora { get; set; }

           public int EmpleadoId { get; set; }

        public Empleado Empleado { get; set; }

        }
    }

