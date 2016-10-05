using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEmpleados
{
   public  class Empleado
    {

        public int EmpleadoId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public List<Visita> Visitas { get; set; }

    }
}
