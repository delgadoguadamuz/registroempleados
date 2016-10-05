using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEmpleados;

namespace DataAccess
{
   public class DataVisita
    {

        public List<Visita> SelectAll()
        {
            using (ConexionString myConexionString = new ConexionString())
            {
                List<Visita> allVisitas = myConexionString.Visitas.ToList();
                return allVisitas;
            }
        }
        public Visita SelectById(int id)
        {
            using (ConexionString myConexionString = new ConexionString())
            {
                Visita VisitaFinded = myConexionString.Visitas.Where(visita => visita.VisitaId == id).SingleOrDefault();
                return VisitaFinded;
            }
        }
        public void Insert(Visita pVisita)
        {
            using(ConexionString myConexionString = new ConexionString())
            {
                myConexionString.Visitas.Add(pVisita);
                myConexionString.SaveChanges();
            }
        }
        public void Update(Visita pVisita)
        {
            using (ConexionString myConexionString = new ConexionString())
            {
                Visita objVisita = myConexionString.Visitas.Where(visita => visita.VisitaId == pVisita.VisitaId).SingleOrDefault();
                if (objVisita != null)
                {
                    objVisita.VisitaId = pVisita.VisitaId;
                    objVisita.NombreVisita = pVisita.NombreVisita;
                    objVisita.Vendor = pVisita.Vendor;
                    objVisita.FechaHora = pVisita.FechaHora;
                    objVisita.Descripcion= pVisita.Descripcion;
                  

                    myConexionString.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using(ConexionString myConexionString = new ConexionString())
            {
               Visita objVisita = myConexionString.Visitas.Where(o => o.VisitaId == id).SingleOrDefault();
                if (objVisita != null)
                {
                    myConexionString.Visitas.Remove(objVisita);
                    myConexionString.SaveChanges();
                }
            }
        }



    }
}
