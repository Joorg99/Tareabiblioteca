using capaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLogica
{
    public static class PrestamosController
    {
        public static void Create(int id, int libro, int socio, string fecha_prestamo, string fecha_devolucion)
        {
            PrestamosModel prestamo = new PrestamosModel();
            prestamo.libro = libro;
            prestamo.socio = socio;
            prestamo.fecha_prestamo = fecha_prestamo;
            prestamo.fecha_devolucion = fecha_devolucion;
            prestamo.id = id;
            prestamo.Save();
        }

        public static DataTable GetPrestamos()
        {
            PrestamosModel PrestamoTableModel = new PrestamosModel();
            List<PrestamosModel> prestamos = PrestamoTableModel.GetAllPrestamos();

            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("libro", typeof(int));
            table.Columns.Add("socio", typeof(int));
            table.Columns.Add("fechadevolucion", typeof(string));
            table.Columns.Add("fechaprestamo", typeof(string));


            foreach (PrestamosModel prestamo in prestamos)
            {
                DataRow row = table.NewRow();
                row["id"] = prestamo.id;
                row["libro"] = prestamo.libro;
                row["socio"] = prestamo.socio;
                row["fecha_devolucion"] = prestamo.fecha_devolucion;
                row["fecha_prestamo"] = prestamo.fecha_prestamo;
                table.Rows.Add(row);
            }
            return table;
        }

        public static void EliminarPrestamo(int id)
        {
            PrestamosModel prestamo = new PrestamosModel();
            prestamo.Delete();
        }
    }
}