using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEmpleados;

namespace DataAccess
{
    public class DataEmpleado

        {
            public List<Empleado> SelectAll()
            {
                using (ConexionString myConexionString = new ConexionString())
                {
                    List<Empleado> allEmpleados = myConexionString.Empleados.ToList();
                    return allEmpleados;
                }
            }
        public Empleado SelectById(int id)
        {
            using (ConexionString myConexionString = new ConexionString())
            {
                Empleado EmpleadoFinded = myConexionString.Empleados.Where(customer => customer.EmpleadoId == id).SingleOrDefault();
                return EmpleadoFinded;
            }
        }

        public void Insert(Empleado pEmpleado)
        {
            using (ConexionString myConexionString = new ConexionString())
            {
                myConexionString.Empleados.Add(pEmpleado);
                myConexionString.SaveChanges();
            }
        }
        public void Update(Empleado pEmpleado)
        {
            using (ConexionString myConexionString = new ConexionString())
            {
                Empleado objEmpleado = myConexionString.Empleados.Where(customer => customer.EmpleadoId == pEmpleado.EmpleadoId).SingleOrDefault();
                if (objEmpleado != null)
                {
                    objEmpleado.Nombre = pEmpleado.Nombre;
                    objEmpleado.Apellido = pEmpleado.Apellido;
                    objEmpleado.EmpleadoId = pEmpleado.EmpleadoId;
                    myConexionString.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (ConexionString myConexionString = new ConexionString())
            {
                Empleado objEmpleado = myConexionString.Empleados.Where(c => c.EmpleadoId == id).SingleOrDefault();
                if (objEmpleado != null)
                {
                    myConexionString.Empleados.Remove(objEmpleado);
                    myConexionString.SaveChanges();
                }
            }
        }
    }
}


