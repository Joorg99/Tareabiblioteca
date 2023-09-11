using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaLogica;

namespace Trabajoprog3
{
    public partial class libreria : Form
    {
        public libreria()
        {
            InitializeComponent();
     
        }
        public void RecargarTabla()
        {
            DataTable dataTableLibros = LibrosController.GetLibros();
            dataGridView1.DataSource = dataTableLibros;

            DataTable dataTableSocios = SociosController.GetSocios();
            dataGridViewCustomers.DataSource = dataTableSocios;

            DataTable dataTablePrestamos = PrestamosController.GetPrestamos();
            dataGridViewPrestamos.DataSource = dataTablePrestamos;
        }

        public void LimpiarBoxes()
        {
            txtidlibro.Clear();
            txticbn.Clear();
            txtgenero.Clear();
            txtautor.Clear();
            txtnombrelibro.Clear();
            txtlanzamiento.Clear();

            txtsocionombre.Clear();
            txtsocioapellido.Clear();
            txtsociotel.Clear();
            txtidsocio.Clear();

            txtlibroprestamo.Clear();
            txtdevolucion.Clear();
            txtidprestamo.Clear();
            txtprestamo.Clear();
            txtsocioprestamo.Clear();
        }
        private void añadirLibro()
        {
            LibrosController.Create(Int32.Parse(txticbn.Text), txtnombrelibro.Text, txtautor.Text, txtgenero.Text, txtgenero.Text, Int32.Parse(txtpaginas.Text));
            MessageBox.Show("Libro agregado con exito");
            RecargarTabla();
            LimpiarBoxes();
        }
        private void añadirSocio()
        {
            SociosController.Create(txtsocionombre.Text, txtsocioapellido.Text, Int32.Parse(txtsociotel.Text));
            MessageBox.Show("Se ha añadido al socio con exito");
            RecargarTabla();
            LimpiarBoxes();
        }
        private void añadirPrestamo()
        {
            PrestamosController.Create(Int32.Parse(txtidprestamo.Text), Int32.Parse(txtprestamo.Text), txtsocioprestamo.Text, txtdevolucion.Text);
            MessageBox.Show("Prestamo creado");
            RecargarTabla();
            LimpiarBoxes();
        }

        private void eliminarLibro()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int id = (int)dataGridView1.Rows[selectedIndex].Cells["id"].Value;
                DataTable dataTableBooks = (DataTable)dataGridView1.DataSource;
                dataTableBooks.Rows.RemoveAt(selectedIndex);
                MessageBox.Show("Se elimino el libro");

                LibrosController.EliminarLibro(id);
                dataGridView1.DataSource = dataTableBooks;
                RecargarTabla();

            }
        }

        private void eliminarPrestamo()
        {
            if (dataGridViewPrestamos.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewPrestamos.SelectedRows[0].Index;
                int id = (int)dataGridViewPrestamos.Rows[selectedIndex].Cells["id"].Value;
                DataTable dataTablePrestamo = (DataTable)dataGridViewPrestamos.DataSource;
                dataTablePrestamo.Rows.RemoveAt(selectedIndex);
                MessageBox.Show("El prestamo fue eliminado");

                PrestamosController.EliminarPrestamo(id);
                dataGridViewPrestamos.DataSource = dataTablePrestamo;
                RecargarTabla);

            }
        }
        private void eliminarSocio()
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                int id = (int)dataGridViewCustomers.Rows[selectedIndex].Cells["id"].Value;
                DataTable dataTableSocio = (DataTable)dataGridViewCustomers.DataSource;
                dataTableSocio.Rows.RemoveAt(selectedIndex);
                MessageBox.Show("El socio fue eliminado completamente");

                SociosController.EliminarSocio(id);
                dataGridViewCustomers.DataSource = dataTableSocio;
                RecargarTabla();

            }
        }

        private void libreria_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void agregarlibrobtn_Click(object sender, EventArgs e)
        {
            añadirLibro();
        }

        private void eliminarlibrobtn_Click(object sender, EventArgs e)
        {
            eliminarLibro();
        }

        private void agregarsociobtn_Click(object sender, EventArgs e)
        {
            añadirSocio();
        }

        private void eliminarsociobtn_Click(object sender, EventArgs e)
        {
            eliminarSocio();
        }

        private void agregarprestamobtn_Click(object sender, EventArgs e)
        {
            añadirPrestamo();
        }

        private void eliminarprestamobtn_Click(object sender, EventArgs e)
        {
            eliminarPrestamo();
        }
        private void modlibrobtn_Click(object sender, EventArgs e)
        {
            RecargarTabla();
        }

        private void modificarsociobtn_Click(object sender, EventArgs e)
        {
            RecargarTabla();
        }

        private void modificarprestamobtn_Click(object sender, EventArgs e)
        {
            RecargarTabla();
        }
    }
}
