using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaLogica

{
    public static class LibrosController
    {
        public static void Create(int icbn, string nombre, string autor, string genero, string fecha_lanzamiento, int cantidad_paginas)
        {
            LibrosModel libro = new LibrosModel();
            libro.icbn = icbn;
            libro.nombre = nombre;
            libro.autor = autor;
            libro.genero = genero;
            libro.fecha_lanzamiento = fecha_lanzamiento;
            libro.cantidad_paginas = cantidad_paginas;
            libro.Save();
        }

        public static DataTable GetBooks()
        {
            LibrosModel BookTableModel = new LibrosModel();
            List<LibrosModel> libros = BookTableModel.GetAllBooks();

            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("icbn", typeof(string));
            table.Columns.Add("nombre", typeof(string));
            table.Columns.Add("autor", typeof(string));
            table.Columns.Add("genero", typeof(string));
            table.Columns.Add("fecha_lanzamiento", typeof(string));
            table.Columns.Add("cantidad_paginas", typeof(int));

            foreach (LibrosModel libro in libros)
            {
                DataRow row = table.NewRow();
                row["id"] = libro.id;
                row["icbn"] = libro.icbn;
                row["nombre"] = libro.nombre;
                row["autor"] = libro.autor;
                row["genero"] = libro.genero;
                row["fecha_lanzamiento"] = libro.fecha_lanzamiento;
                row["cantidad_paginas"] = libro.cantidad_paginas;
                table.Rows.Add(row);
            }
            return table;
        }

        public static void EliminarLibro(int id)
        {
            LibrosModel libro = new LibrosModel();
            libro.id = id;
            libro.Delete();
        }
    }
}