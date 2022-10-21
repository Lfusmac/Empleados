using System;
using MySql.Data.MySqlClient;
using capaEntidad;
using capaDatos;
using System.Data;
using System.Windows.Forms;

namespace capaDatos
{
    public class CDEmpleado
    {
       

        //Parametros para que visual se conecte a MySql
        string CadenaConexion = "Server=localhost;User=root;Password=;Port=3306;database=empleado";

        //Prueba de conexión
        public void PruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);

            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión"+ ex.Message);
                throw;
            }
            mySqlConnection.Close();// cerrar conexión
            MessageBox.Show(" Conectado. ");
        }
        //Creamos Metodo para para comando de inserccion de datos
        
        public void Crear(CEEmpleado cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `empleados` (`nombre`, `apellido`, `numeroEmp`, `cargo`, `numeroOfc`, `foto`) VALUES ('"+ cE.Nombre + "', '"+ cE.Apellido + "', '"+ cE.NumeroEmp + "', '"+ cE.Cargo + "', '"+ cE.NumeroOfc + "', '"+ MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) +"');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show(" Registro creado. ");
        }
        //Creamos Metodo para  retorar un valor y realizar la consulta en la base datos
        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `empleados` LIMIT 1000;";
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlDataAdapter(Query, mySqlConnection);
            Adaptador.Fill(dataSet, "tbl");
            return dataSet;
            
        }

        //Creamos Metodo para  retorar un valor y realizar la consulta en la base datos

        public void Editar(CEEmpleado cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE `empleados` SET `nombre`='"+ cE.Nombre + "', `apellido`='"+ cE.Apellido + "', `numeroEmp`='"+ cE.NumeroEmp + "', `cargo`='"+ cE.Cargo + "', `numeroOfc`='"+ cE.NumeroOfc + "', `foto`='"+ MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) +"' WHERE  `ID`=" + cE.id+";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show(" Registro actualizado. ");
        }

        //Creamos Metodo para  eliminar datos la base datos

        public void Eliminar(CEEmpleado cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "DELETE FROM `empleados` WHERE  `ID`= " + cE.id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show(" Registro eliminado. ");
        }
    }
}