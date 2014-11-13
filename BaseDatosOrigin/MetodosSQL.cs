using System;
using MySql.Data.MySqlClient;

namespace BaseDatosOrigin
{
    class MetodosSQL : conexionDb
    {
        

        public void mostrarDatos()
        {
            int id;
            string nombre, codigo, telefono, email;

            this.abrirConexion();
            MySqlCommand comandoConsulta = new MySqlCommand("SELECT * FROM persona", miConexion);
            MySqlDataReader datosConsulta = comandoConsulta.ExecuteReader();

            if (!datosConsulta.HasRows)
                Console.WriteLine("No hay datos disponibles en la base de datos ");
            else
                while (datosConsulta.Read())
                {
                    id = Convert.ToInt32(datosConsulta["id"]);
                    nombre = datosConsulta["nombre"].ToString();
                    codigo = datosConsulta["codigo"].ToString();
                    telefono = datosConsulta["telefono"].ToString();
                    email = datosConsulta["email"].ToString();

                    Console.WriteLine("\n\tId: " + id + "\tNombre: " + nombre + "\tCodigo: " + codigo + "\n\tTeléfono: " + telefono + "\tEmail: " + email);
                }
            this.cerrarConexion();
        }

        public void ejecutarConsulta(string consulta)
        {
            this.abrirConexion();
            MySqlCommand comandoConsulta = new MySqlCommand(consulta, miConexion);
            comandoConsulta.ExecuteNonQuery();
            this.cerrarConexion();
            Console.WriteLine("\n\t\tAcción Realizada Satisfactoriamente.");
        }

        public bool verificarExistencia(int id)
        {
            this.abrirConexion();
            MySqlCommand comandoConsulta = new MySqlCommand("SELECT id FROM persona WHERE id = " + id, miConexion);
            MySqlDataReader datosConsulta = comandoConsulta.ExecuteReader();
            bool tieneDatos = datosConsulta.HasRows;
            this.cerrarConexion();
            if (tieneDatos)
                return true;
            else
                return false;

        }

    }
}