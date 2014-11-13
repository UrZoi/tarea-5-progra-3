using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatosOrigin
{
    class MetodosInterfaz : MetodosSQL

    {
        
        public void Mprincipal()
        {
            int opcmenu;

            Console.WriteLine("-------------------------------Menu Principal----------------------------------");
            Console.WriteLine(" 1.-Mostrar todos"));
            Console.WriteLine(" 2.-Nuevo registro");
            Console.WriteLine("3.-Editar ");
            Console.WriteLine("4.-Eliminar" );
            Console.WriteLine("registro  5.-Salir");
            Console.ReadLine();
            opcmenu = Convert.ToInt32(Console.ReadLine());

        }


        private void opcionesDelMenu(string opcmenu)
        {


            switch (opcmenu)
            {
                case "1": mostrar();
                    break;
                case "2": agregar();
                    break;
                case "3": editar();
                    break;
                case "4": eliminar();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("FATAL ERROR, dios matara un gatito cada que presiones un numero no indicado TTwTT ");
                    break;
            }

        }




        private void mostrar()
        {
            this.mostrarDatos();
        }
        private void agregar()
        {
            string con = "INSERT INTO persona VALUES('',";

            Console.Write("\t\tNombre: ");
            con += "'" + Console.ReadLine() + "', ";
            Console.Write("\t\tCodigo: ");
            con += "'" + Console.ReadLine() + "', ";
            Console.Write("\t\tTelefono: ");
            con += "'" + Console.ReadLine() + "', ";
            Console.Write("\t\temail: ");
            con += "'" + Console.ReadLine() + "' )";

            this.ejecutarConsulta(con);

        
        }
        private void editar()
        {
            this.mostrarDatos();

            Console.Write("\n\tPor Favor escriba el id de la tupla a editar o \"c\" para cancelar: ");
            string entradaUsuario = Console.ReadLine();
            if (entradaUsuario == "c" || entradaUsuario == "C")
                return;
            else
            {
                Console.Write("\n\tRealmente quiere editar la tupla con el id " + entradaUsuario + " (s para continuar):");
                string corroboracion = Console.ReadLine();

                if (corroboracion == "s" || corroboracion == "S")
                {
                    int entradaDeUsuario;
                    if (Int32.TryParse(entradaUsuario, out entradaDeUsuario))
                    {
                        if (this.verificarExistencia(entradaDeUsuario))
                        {
                            string valores = "";
                            Console.WriteLine("\t\tEditando id: " + entradaDeUsuario);
                            Console.Write("\t\tNombre: ");
                            valores += "nombre='" + Console.ReadLine() + "', ";
                            Console.Write("\t\tCodigo: ");
                            valores += "codigo='" + Console.ReadLine() + "', ";
                            Console.Write("\t\tTelefono: ");
                            valores += "telefono='" + Console.ReadLine() + "', ";
                            Console.Write("\t\temail: ");
                            valores += "email='" + Console.ReadLine() + "'";

                            this.ejecutarConsulta("UPDATE persona SET " + valores + " WHERE id=" + entradaDeUsuario);
                        }
                        else
                            Console.WriteLine("\n\t\tEl id ingresado no existe, verifiquelo.");
                    }
                    else
                        Console.WriteLine("\n\tVerifique el id que ingresó, solo se aceptan numeros enteros.");
                }
            }
        }
        private void eliminar()
        {
            this.mostrarDatos();

            Console.Write("\n\tPor Favor escriba el id de la tupla a eliminar o \"c\" para cancelar: ");
            string entradaUsuario = Console.ReadLine();

            if (entradaUsuario == "c" || entradaUsuario == "C")
                return;
            else
            {
                Console.Write("\n\tRealmente quiere editar la tupla con el id " + entradaUsuario + " (s para continuar):");
                string corroboracion = Console.ReadLine();

                if (corroboracion == "s" || corroboracion == "S")
                {
                    int entradaDeUsuario;
                    if (Int32.TryParse(entradaUsuario, out entradaDeUsuario))
                    {
                        if (this.verificarExistencia(entradaDeUsuario))
                            this.ejecutarConsulta("DELETE FROM persona WHERE id=" + entradaDeUsuario);
                        else
                            Console.WriteLine("\n\t\tEl id ingresado no existe, verifiquelo.");
                    }
                    else
                        Console.WriteLine("\n\tVerifique el id que ingresó, solo se aceptan numeros enteros.");
                }
            }
        }


    }
}
