using System;
using System.Data;
using System.Net.Http.Json;
using System.Windows.Forms;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CNEmpleado

    {
        CDEmpleado cDEmpleado = new CDEmpleado();

        //creamos metodo para validar informacion de la capa presentación

        public bool ValidarDatos(CEEmpleado empleado)
        {
            bool resultado = true;

            if (empleado.Nombre == String.Empty)
            {
                resultado = false;   
                MessageBox.Show("El Nombre es obligatorio");
            }

            if (empleado.Apellido == String.Empty)
            {
                resultado = false;
                MessageBox.Show("El Apellido es obligatorio");
            }

            if (empleado.NumeroEmp == String.Empty)
            {
                resultado = false;
                MessageBox.Show("El número de teléfono móvil empresarial es obligatorio");
            }

            if (empleado.Cargo == String.Empty)
            {
                resultado = false;
                MessageBox.Show("El Cargo es obligatorio");
            }

            if (empleado.NumeroOfc == String.Empty)
            {
                resultado = false;
                MessageBox.Show("El número de oficina es obligatorio");
            }
            if (empleado.Foto == null)
            {
                resultado = false;
                MessageBox.Show("El Foto es obligatoria");
            }

            return resultado;
        }

        public void PruebaMySql()
        {
            cDEmpleado.PruebaConexion();
        }

        public void CrearCliente(CEEmpleado cE)
        {
            cDEmpleado.Crear(cE);
        }
        public void EditarCliente(CEEmpleado cE)
        {
            cDEmpleado.Editar(cE);
        }

        public void EliminarCliente(CEEmpleado cE)
        {
            cDEmpleado.Eliminar(cE);
        }

        public DataSet ObtenerDatos()
        {
            return cDEmpleado.Listar();
        }

    }
}