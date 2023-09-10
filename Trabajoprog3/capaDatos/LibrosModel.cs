using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class LibrosModel : DatabaseConnector
    {
        public int id { get; set; }
        public int icbn { get; set; }
        public string nombre { get; set; }
        public string autor { get; set; }
        public string genero { get; set; }
        public string fecha_lanzamiento { get; set; }
        public int cantidad_paginas { get; set; }


        public void Save()
        {
            this.Command.CommandText = $"INSERT INTO libros(icbn, nombre, autor, genero, fecha_lanzamiento, cantidad_paginas) " +
                $"VALUES({this.icbn}, '{this.nombre}', '{this.autor}', '{this.genero}', '{this.fecha_lanzamiento}', {this.cantidad_paginas})";

            this.Command.ExecuteNonQuery();
        }
        public List<LibrosModel> GetAllBooks()
        {
            this.Command.CommandText = "SELECT * FROM libros";
            this.Reader = this.Command.ExecuteReader();

            List<LibrosModel> result = new List<LibrosModel>();
            while (this.Reader.Read())
            {
                LibrosModel libro = new LibrosModel();
                libro.id = Int32.Parse(this.Reader["id"].ToString());
                libro.icbn = Int32.Parse(this.Reader["icbn"].ToString());
                libro.nombre = this.Reader["nombre"].ToString();
                libro.autor = this.Reader["autor"].ToString();
                libro.genero = this.Reader["genero"].ToString();
                libro.fecha_lanzamiento = this.Reader["fecha_lanzamiento"].ToString();
                libro.cantidad_paginas = Int32.Parse(this.Reader["cantidad_paginas"].ToString());
                result.Add(libro);
            }
            return result;
        }

        public void Delete()
        {
            this.Command.CommandText = $"DELETE FROM libros WHERE id = {this.id}";
            this.Command.ExecuteNonQuery();
        }

    }
}