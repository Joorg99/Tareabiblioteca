using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class PrestamosModel : DatabaseConnector
    {
        public string fecha_devolucion { get; set; }
        public string fecha_prestamo { get; set; }
        public int socio { get; set; }
        public int libro { get; set; }
        public int id { get; set; }


        public void Save()
        {
            this.Command.CommandText = $"INSERT INTO prestamos(socio, libro, fecha_devolucion, fecha_prestamo) " +
                $"VALUES('{this.libro} '{this.id}' '{this.socio}', '{this.fecha_prestamo}', '{this.fecha_devolucion}')";

            this.Command.ExecuteNonQuery();
        }
        public List<PrestamosModel> GetAllBooks()
        {
            this.Command.CommandText = "SELECT * FROM prestamos";
            this.Reader = this.Command.ExecuteReader();

            List<PrestamosModel> result = new List<PrestamosModel>();
            while (this.Reader.Read())
            {
                PrestamosModel Prestamo = new PrestamosModel();
                Prestamo.id = this.Reader["id"].ToString();
                Prestamo.socio = this.Reader["socio"].ToString();
                Prestamo.libro = this.Reader["libro"].ToString();
                Prestamo.fecha_prestamo = this.Reader["fecha_prestamo"].ToString();
                Prestamo.fecha_devolucion = this.Reader["fecha_devolucion"].ToString();
                result.Add(Prestamo);
            }
            return result;
        }

        public void Delete()
        {
            this.Command.CommandText = $"DELETE FROM prestamos WHERE id = {this.id}";
            this.Command.ExecuteNonQuery();
        }

    }
}
