
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEmpleados
{
    public class ConexionString : DbContext
    {
        public ConexionString() : base("name=ConexionString")
        {


        }

        public virtual DbSet<Visita> Visitas { get; set; }

       

        public virtual DbSet<Empleado> Empleados { get; set; }

    }
}