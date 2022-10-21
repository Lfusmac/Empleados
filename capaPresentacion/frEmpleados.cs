using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;
using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frEmpleados : Form

    {
        //Definimos una variable global

        CNEmpleado cNEmpleado = new CNEmpleado();

        public frEmpleados()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // accedemos al metodo  para limpiar el formulario
            LimpiarForm();
        }

        // cremaos metodo para limpiar el formulario
        private void LimpiarForm()
        {
            
            txtID.Value = 0;
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtNumeroEmp.Text = String.Empty;
            txtCargo.Text = String.Empty;
            txtNumeroOfc.Text = String.Empty;
            picFoto.Image = null;
        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // seleccionar imagen
            ofdFoto.FileName = String.Empty;
            

            //valiamos si se selecciono la imagen

            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                //accedemos al metodo load para que cargue la foto
                picFoto.Load(ofdFoto.FileName);
            }

            ofdFoto.FileName = String.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            bool resultado;
            CEEmpleado  cEEmpleado = new CEEmpleado();
            cEEmpleado.id = (int)txtID.Value;
            cEEmpleado.Nombre = txtNombre.Text;
            cEEmpleado.Apellido = txtApellido.Text;
            cEEmpleado.NumeroEmp = txtNumeroEmp.Text;
            cEEmpleado.Cargo = txtCargo.Text;
            cEEmpleado.NumeroOfc = txtNumeroOfc.Text;
            cEEmpleado.Foto = picFoto.ImageLocation;

            resultado = cNEmpleado.ValidarDatos(cEEmpleado);
            //Validos que los campos esten diligenciados
            if (resultado == false)
            {
                return;
            }
            //validos si el usuario existe se actuliza los datos
            if (cEEmpleado.id == 0 )
            {
                cNEmpleado.CrearCliente(cEEmpleado);
            }
            else
            {
                cNEmpleado.EditarCliente(cEEmpleado);
            }
            

            CargarDatos();
            LimpiarForm();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // validamos si el usuario desea eliminar el empleado
            if (txtID.Value == 0)
            {
                return;
            }
            if (MessageBox.Show("Deseas eliminar el registro ?","Titulo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CEEmpleado cE = new CEEmpleado();
                cE.id = (int)txtID.Value;
                cNEmpleado.EliminarCliente(cE);

                CargarDatos();
                LimpiarForm();
            }
        }

        private void frEmpleados_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            gridDatos.DataSource = cNEmpleado.ObtenerDatos().Tables["tbl"]; // para acceder a la tabla que quiero mostrar en el grid

        }
        //para llevar los valores que estan en los campos de texto cuando se da doble click
        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Value = (int)gridDatos.CurrentRow.Cells["id"].Value;
            txtNombre.Text = gridDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["apellido"].Value.ToString();
            txtNumeroEmp.Text = gridDatos.CurrentRow.Cells["numeroEmp"].Value.ToString();
            txtCargo.Text = gridDatos.CurrentRow.Cells["cargo"].Value.ToString();
            txtNumeroOfc.Text = gridDatos.CurrentRow.Cells["numeroOfc"].Value.ToString();
            picFoto.Load(gridDatos.CurrentRow.Cells["foto"].Value.ToString()) ;
        }
    }
}