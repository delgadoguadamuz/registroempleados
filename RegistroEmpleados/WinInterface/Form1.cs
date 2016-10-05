using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroEmpleados;
using DataAccess;

namespace WinInterface
{
    public partial class Form1 : Form
    {
            private DataTable tableVisitas;
            private DataTable tableEmpleados;

            private DataTable tablecbxEmpleados;
            private DataTable tablecbxVisitas;

         

            private DataEmpleado EmpleadosManager;
            private DataVisita VisitasManager;
            
            public Form1()
            {
                InitializeComponent();

                tableEmpleados = new DataTable();
                tableEmpleados.Columns.Add("Id");
                tableEmpleados.Columns.Add("Nombre");
                tableEmpleados.Columns.Add("Apellido");
                

                tableVisitas = new DataTable();
                tableVisitas.Columns.Add("Id");
                tableVisitas.Columns.Add("NombreVisita");
                tableVisitas.Columns.Add("Vendor");
                tableVisitas.Columns.Add("Fecha");
                tableVisitas.Columns.Add("Descripcion");
                tableVisitas.Columns.Add("Empleado");
                

                tablecbxEmpleados = new DataTable();
                tablecbxEmpleados.Columns.Add("Id");
                tablecbxEmpleados.Columns.Add("Nombre");

                EmpleadosManager = new DataEmpleado();
                VisitasManager = new DataVisita();
                LoadEmpleados();
                LoadcbxEmpleados();
                LoadVisita();

        }

        public void LoadEmpleados()
        {
            tableEmpleados.Clear();
            List<Empleado> allEmpleados = EmpleadosManager.SelectAll();

            foreach (Empleado currentEmpleados in allEmpleados)
            {
                DataRow row = tableEmpleados.NewRow();
                row["Id"] = currentEmpleados.EmpleadoId;
                row["Nombre"] = currentEmpleados.Nombre;
                row["Apellido"] = currentEmpleados.Apellido;
             


                tableEmpleados.Rows.Add(row);
            }
            dgvEmpleados.DataSource = tableEmpleados;
        }

        public void LoadcbxEmpleados()
        {
            tablecbxEmpleados.Clear();
            List<Empleado> allEmpleados = EmpleadosManager.SelectAll();
            foreach (Empleado empleado in allEmpleados)
            {
                DataRow row = tablecbxEmpleados.NewRow();
                row["Id"] = empleado.EmpleadoId;
                row["nombre"] = empleado.Nombre;

                tablecbxEmpleados.Rows.Add(row);
            }
            
            cbxRespondable.DataSource = tablecbxEmpleados;
            cbxRespondable.ValueMember = "Id";
            cbxRespondable.DisplayMember = "Nombre";
        }

        public void LoadVisita()
        {
            tableVisitas.Clear();
            List<Visita> allVisita = VisitasManager.SelectAll();

            foreach (Visita currentVisitas in allVisita)
            {
                DataRow row = tableVisitas.NewRow();
                row["Id"] = currentVisitas.VisitaId;
                row["NombreVisita"] = currentVisitas.NombreVisita;
                row["Vendor"] = currentVisitas.Vendor;
                row["Fecha"] = currentVisitas.FechaHora;
                row["Descripcion"] = currentVisitas.Descripcion;
                row["Empleado"] = currentVisitas.Empleado.Nombre;



                tableVisitas.Rows.Add(row);
            }
            dgvVisitas.DataSource = tableVisitas;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Empleado epl = EmpleadosManager.SelectById(Convert.ToInt32(cbxRespondable.SelectedValue));

            Visita objVisita = new Visita();


            objVisita.NombreVisita = txtNombreProveedor.Text;
            objVisita.Vendor = txtEmpresa.Text;
            objVisita.FechaHora = Convert.ToDateTime (dtpFecha.Text);
            objVisita.Descripcion = txtDescripcion.Text;
            objVisita.EmpleadoId = Convert.ToInt32(cbxRespondable.SelectedValue);

            VisitasManager.Insert(objVisita);
            
            LoadVisita();
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {

            Empleado epl = EmpleadosManager.SelectById(Convert.ToInt32(cbxRespondable.SelectedValue));

            Empleado objEmpleados = new Empleado();


            objEmpleados.Nombre = txtNombre.Text;
            objEmpleados.Apellido = txtApellido.Text;

                 

            if (objEmpleados.EmpleadoId > 0)
            {
                EmpleadosManager.Update(objEmpleados);
            }
            else
            {
                EmpleadosManager.Insert(objEmpleados);
            }
            LoadEmpleados();



        }
        public void ClearVisita()
        {
            txtNombreProveedor.Text = string.Empty;
            txtEmpresa.Text = string.Empty;
            txtDescripcion.Text= string.Empty;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClearVisita();
        }

      
    }
}
