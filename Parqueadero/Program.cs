// See https://aka.ms/new-console-template for more information

using System;
using Parqueadero;

/*
 * Universidad Nacional Abierta y a Distancia (UNAD)
 * Escuela de Ciencias Básicas, Tecnología e Ingeniería – ECBTI
 * Programación (213023_137)
 * Autor: Alfonso Gonzalez Posso
 * Etapa 3 - Ejercicio 9
 * 
 */

namespace Parqueadero // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario objUsusario = new Usuario();

            Boolean isSalirMenu = true;

            while (isSalirMenu)
            {
                Console.Write("#####---######--> Menu Principal Login <-- #####---######");
                Console.Write("\n\t1.Iniciar Sesión.");
                Console.Write("\n\t2.Registrarse.");
                Console.Write("\n\t3.Recuperar Username.");
                Console.Write("\n\t4.Recuperar Contraseña.");
                Console.Write("\n\t5.Salir del Programa.?");
                Console.Write("\n\nIngrese el numero de la opción deseada: ");
                int opcionMenu = Int32.Parse(Console.ReadLine());

                switch (opcionMenu)
                {
                    case 1:
                    {
                        Console.WriteLine("#####---######--> Iniciar Sesión <-- #####---######");
                        Console.Write("Ingrese Username -> ");
                        string username = Console.ReadLine();
                        Console.Write("Ingrese Password -> ");
                        string password = Console.ReadLine();

                        bool isLogin = objUsusario.IsLogin(username, password);

                        int isGetIDUser = objUsusario.ObtenerIDUser(username);

                        bool isAdmin = objUsusario.ValidarPermiso(isGetIDUser);

                        if (isLogin)
                        {
                            Console.WriteLine("#####---######--> Ingresate Correctamente <-- #####---######\n");
                            if (isAdmin)
                            {
                                Console.WriteLine("#####---######--> Panel Administración <-- #####---######\n");
                                PrincipalLoginAdmin(isGetIDUser, username);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("#####---######--> Panel Usuario <-- #####---######\n");
                                PrincipalLoginNOAdmin(isGetIDUser, username);
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error::Usuario o Contraseña es Incorrecto");
                            Console.ReadKey();
                        }

                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("\n#####---######--> Registrarse <--#####---######.\n");

                        Console.Write("Ingrese el Nombre -> ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el Apellido -> ");
                        string apellidos = Console.ReadLine();
                        Console.Write("Ingrese el Username -> ");
                        string username = Console.ReadLine();
                        Console.Write("Ingrese la Contraseña -> ");
                        string password = Console.ReadLine();
                        Console.Write("Ingrese la Dirección -> ");
                        string direccion = Console.ReadLine();
                        Console.Write("Ingrese el Telefono -> ");
                        int telefono = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Seleccione si es admin o usuario normal.");
                        Console.WriteLine("1=>Admin -> ");
                        Console.WriteLine("2=>Normal -> ");
                        Console.Write("\nIngrese una opción -> ");
                        int permiso = Int32.Parse(Console.ReadLine());

                        int totalIdUser = objUsusario.ContarUsuarios();
                        totalIdUser = totalIdUser + 1;

                        objUsusario.AgregarUnUsuario(totalIdUser, nombre, apellidos, username, password, direccion,
                            objUsusario.AgregarPermiso(permiso), telefono);
                        Console.ReadKey();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("\n#####---######--> Recuperar Username <--#####---######.\n");

                        Console.Write("Por favor ingrese la contraseña->  ");
                        string password = Console.ReadLine();

                        bool isCorrectPass = objUsusario.RecuperarUsernamePassword(password);
                        int isGetIDUserPass = objUsusario.ObtenerIDUserPass(password);

                        if (isCorrectPass)
                        {
                            Console.Write("Ingrese Su Nuevo Username -> ");
                            string newusername = Console.ReadLine();

                            objUsusario.RecuperarUsername(isGetIDUserPass, newusername);
                        }
                        else
                        {
                            Console.WriteLine("La contraseña Ingresada es Incorrecta.\n");
                        }

                        Console.ReadKey();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("\n#####---######--> Recuperar Contraseña <--#####---######.\n");

                        Console.Write("Por favor ingrese el Username->  ");
                        string username = Console.ReadLine();

                        bool isCorrectPass = objUsusario.RecuperarPasswordUsername(username);
                        int isGetIDUser = objUsusario.ObtenerIDUser(username);

                        if (isCorrectPass)
                        {
                            Console.Write("Ingrese Su Nuevo Password-> ");
                            string newpassword = Console.ReadLine();

                            objUsusario.RecuperarPassword(isGetIDUser, newpassword);
                        }
                        else
                        {
                            Console.WriteLine("La contraseña Ingresada es Incorrecta.\n");
                        }

                        Console.ReadKey();
                        break;
                    }
                    case 5:
                    {
                        Console.Write("Cerraste Sesión Correctamente.\n");
                        isSalirMenu = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Ingresaste un valor incorrector.\nPor favor vuelve a validar.");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }

        public static void PrincipalLoginAdmin(int GetIDUSer, string username)
        {
            Console.WriteLine("#####- ::Usuario Login:: {0} -######", username);
            Console.WriteLine("#####- ::ID User Login:: {0} -######\n", GetIDUSer);

            Usuario objUsusario = new Usuario();
            Parqueadero objParqueadero = new Parqueadero();
            Factura objFactuta = new Factura();
            Vehiculo objVehiculo = new Vehiculo();

            Boolean isSalirProgram = true;

            while (isSalirProgram)
            {
                Console.Write("#####---######--> DashBoard Principal ADMIN <-- #####---######");
                Console.Write("\n\t1.Ir a Menu Usuarios.");
                Console.Write("\n\t2.Ir a Menu Parqueaderos.");
                Console.Write("\n\t3.Ir a Menu Facturas.");
                Console.Write("\n\t4.Ir a Menu Vehiculos.");
                Console.Write("\n\t5.Cerrar Sesión.?");
                Console.Write("\n\nIngrese el numero de la opción deseada: ");
                int opcionProgram = Int32.Parse(Console.ReadLine());

                switch (opcionProgram)
                {
                    case 1:
                    {
                        Console.WriteLine("#####---######--> Menu Principal Usuarios <-- #####---######");
                        objUsusario.OperacionesUsuario();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("#####---######--> Menu Principal Parqueaderos <-- #####---######");
                        objParqueadero.OperacionesParqueadero();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("#####---######--> Menu Principal Facturas <-- #####---######");
                        objFactuta.OperacionesFacturas();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("#####---######--> Menu Principal Vehiculos <-- #####---######");
                        objVehiculo.OperacionesVehiculos();
                        break;
                    }
                    case 5:
                    {
                        Console.Write("Saliste del Menu Principal Correctamente.\n");
                        isSalirProgram = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Ingresaste un valor incorrector.\nPor favor vuelve a validar.");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }

        public static void PrincipalLoginNOAdmin(int GetIDUSer, string username)
        {
            Console.WriteLine("#####- ::Usuario Login:: {0} -######", username);
            Console.WriteLine("#####- ::ID User Login:: {0} -######\n", GetIDUSer);

            Usuario objUsusario = new Usuario();
            Parqueadero objParqueadero = new Parqueadero();
            Factura objFactuta = new Factura();
            Vehiculo objVehiculo = new Vehiculo();

            Boolean isSalirProgram = true;

            while (isSalirProgram)
            {
                Console.Write("#####---######--> DashBoard Usuario Principal <-- #####---######");
                Console.Write("\n\t1.Listar tu Usuario.");
                Console.Write("\n\t2.Modificar tu Usuario.");
                Console.Write("\n\t3.Ver tu Facturas.");
                Console.Write("\n\t4.Cambiar tu Username.");
                Console.Write("\n\t5.Cambiar tu Password.");
                Console.Write("\n\t6.Cerrar Sesión.?");
                Console.Write("\n\nIngrese el numero de la opción deseada: ");
                int opcionProgram = Int32.Parse(Console.ReadLine());

                switch (opcionProgram)
                {
                    case 1:
                    {
                        Console.WriteLine(
                            "#####---######--> DashBoard Usuario Principal -- Listar tu Usuario <-- #####---######");
                        objUsusario.ListarUnUsuario(GetIDUSer);
                        Console.ReadKey();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine(
                            "#####---######--> DashBoard Usuario Principal -- Modificar tu Usuario <-- #####---######");
                        Console.Write("Ingrese el Nuevo Nombre -> ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el Nuevo Apellido -> ");
                        string apellidos = Console.ReadLine();
                        Console.Write("Ingrese la Nueva Dirección -> ");
                        string direccion = Console.ReadLine();
                        Console.Write("Ingrese el Nuevo Telefono -> ");
                        int telefono = Int32.Parse(Console.ReadLine());

                        objUsusario.EditarUsuario(GetIDUSer, nombre, apellidos, direccion, telefono);
                        Console.ReadKey();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine(
                            "#####---######--> DashBoard Usuario Principal -- Ver tu Factura <-- #####---######");

                        objFactuta.ListarUnaFacturaU(GetIDUSer);
                        Console.ReadKey();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine(
                            "#####---######--> DashBoard Usuario Principal -- Cambiar tu Username <-- #####---######");
                        
                        Console.Write("Ingrese el Nuevo Username -> ");
                        string newusername = Console.ReadLine();

                        objUsusario.RecuperarUsername(GetIDUSer, newusername);
                        Console.ReadKey();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine(
                            "#####---######--> DashBoard Usuario Principal -- Cambiar tu Password <-- #####---######");

                        Console.Write("Ingrese la Nueva Contraseña -> ");
                        string newpassword = Console.ReadLine();

                        objUsusario.RecuperarPassword(GetIDUSer, newpassword);
                        Console.ReadKey();
                        break;
                    }
                    case 6:
                    {
                        Console.Write("Saliste del Menu Principal Correctamente.\n");
                        isSalirProgram = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Ingresaste un valor incorrector.\nPor favor vuelve a validar.");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }
}