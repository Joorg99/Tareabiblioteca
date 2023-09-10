using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class SociosModel : DatabaseConnector
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int telefono { get; set; }
        public string apellido { get; set; }


        public void Save()
        {
            this.Command.CommandText = $"INSERT INTO socios(id, nombre, telefono, apellido) " +
                $"VALUES({this.id}, '{this.nombre}', '{this.telefono}', '{this.apellido}')";

            this.Command.ExecuteNonQuery();
        }
        public List<SociosModel> GetAllBooks()
        {
            this.Command.CommandText = "SELECT * FROM socios";
            this.Reader = this.Command.ExecuteReader();

            List<SociosModel> result = new List<SociosModel>();
            while (this.Reader.Read())
            {
                SociosModel socio = new SociosModel();
                socio.id = Int32.Parse(this.Reader["id"].ToString());
                socio.nombre = this.Reader["nombre"].ToString();
                socio.apellido = this.Reader["apellido"].ToString();
                socio.telefono = Int32.Parse(this.Reader["telefono"].ToString());
                result.Add(socio);
            }
            return result;
        }

        public void Delete()
        {
            this.Command.CommandText = $"DELETE FROM socios WHERE id = {this.id}";
            this.Command.ExecuteNonQuery();
        }

    }
}