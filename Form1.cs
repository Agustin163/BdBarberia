using System;
using System.Windows.Forms;

namespace BdBarberia
{
    public partial class Form1 : Form
    {
        ConexionTipoDeCorte conexion = new ConexionTipoDeCorte();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            dgvCortes.DataSource = conexion.Listar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Agregar(txtTipo.Text, decimal.Parse(txtPrecio.Text));
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvCortes.CurrentRow.Cells["idTipoDeCorte"].Value);
                conexion.Modificar(id, txtTipo.Text, decimal.Parse(txtPrecio.Text));
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvCortes.CurrentRow.Cells["idTipoDeCorte"].Value);
                conexion.Eliminar(id);
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCortes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTipo.Text = dgvCortes.CurrentRow.Cells["tipo"].Value.ToString();
            txtPrecio.Text = dgvCortes.CurrentRow.Cells["precio"].Value.ToString();
        }
    }
}
