using System;
using MySql.Data.MySqlClient;

namespace BaseDatosOrigin
{
    class conexionDb
    {
        protected MySqlConnection miConexion;
        public conexionDb()
        {
        }

        protected void abrirConexion()
        {
            string connectionString =
                "Server=localhost;" +
                "Database=programacioniii;" +
                "User ID= root;" +
                "Password=;" +
                "Pooling=false;";
            this.miConexion = new MySqlConnection(connectionString);
            this.miConexion.Open();
        }

        protected void cerrarConexion()
        {
            this.miConexion.Close();
            this.miConexion = null;
        }
    }
}