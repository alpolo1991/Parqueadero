namespace Parqueadero;

public class Carro : Vehiculo
{
    //private Vehiculo objVehiculo = new Vehiculo();
    private Usuario objUsuario = new Usuario();

    public void OperacionesCarros()
    {
        Boolean isSalirCarro = true;

        while (isSalirCarro)
        {
            Console.WriteLine("#####---######--> Menu Principal Carros <-- #####---######");
            Console.Write("\n\t1.Listar Todos los Carros.");
            Console.Write("\n\t2.Agregar un Carro.");
            Console.Write("\n\t3.Modificar un Carro.");
            Console.Write("\n\t4.Eliminar un Carro.");
            Console.Write("\n\t5.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionMoto = Int32.Parse(Console.ReadLine());

            switch (opcionMoto)
            {
                case 1:
                {
                    Console.WriteLine("\n#####---######--> Lista Todos los Carros <--#####---######.");

                    /*
                    Console.WriteLine("\nSeleccione el Tipo.");
                    Console.WriteLine("1=>Carro -> ");
                    Console.WriteLine("2=>Moto -> ");
                    Console.WriteLine("3=>Otros -> ");
                    Console.Write("\nIngrese una opción -> ");
                    int tipo = Int32.Parse(Console.ReadLine());
                    */
                    ListarTipos("Carro");
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("\n#####---######--> Agregar un Carro <--#####---######.");
                    
                    /*Console.Write("Ingrese el ID del Nuevo Vehiculo -> ");
                    int idVeh = Int32.Parse(Console.ReadLine());*/

                    Console.Write("\nIngrese el Modelo del Carro -> ");
                    String modelo = Console.ReadLine();
                    /*
                    Console.WriteLine("\nSeleccione el Tipo.");
                    Console.WriteLine("1=>Carro -> ");
                    Console.WriteLine("2=>Moto -> ");
                    Console.WriteLine("3=>Otros -> ");
                    Console.Write("\nIngrese una opción -> ");
                    int tipo = Int32.Parse(Console.ReadLine());
                    */
                    Console.Write("\nIngrese Nombre Marca -> ");
                    String marca = Console.ReadLine();
                    Console.Write("\nIngrese la Placa -> ");
                    String placa = Console.ReadLine();
                    Console.Write("\nIngrese el Color de la Moto -> ");
                    String color = Console.ReadLine();

                    Console.WriteLine("\nSeleccione un estado.");
                    Console.WriteLine("1=>Disponible -> ");
                    Console.WriteLine("2=>No Disponible -> ");
                    Console.Write("\nIngrese la opción -> ");
                    int estado = Int32.Parse(Console.ReadLine());

                    Console.Write("Ingrese el ID del usuario -> ");
                    int idUser = Int32.Parse(Console.ReadLine());

                    int totalIdUser = objUsuario.ContarUsuarios();

                    if (idUser > totalIdUser || idUser < totalIdUser)
                    {
                        Console.WriteLine("El ID de Usuario Ingresado no existe, por favor validar.");
                    }
                    else
                    {
                        int totalVeh = ContarVehiculo();
                        totalVeh = totalVeh + 1;
                        AgregarUnVehiculo(totalVeh, modelo, "Carro", marca, placa, color, AgregarEstado(estado),
                            idUser);
                    }

                    Console.ReadKey();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("\n#####---######--> Modificar un Carro <--#####---######.");

                    Console.Write("Ingrese el ID del Carro a Modificar -> ");
                    int idVeh = Int32.Parse(Console.ReadLine());

                    Console.Write("\nIngrese el Modelo -> ");
                    String modelo = Console.ReadLine();

                    /*
                    Console.WriteLine("\nSeleccione el Tipo.");
                    Console.WriteLine("1=>Carro -> ");
                    Console.WriteLine("2=>Moto -> ");
                    Console.WriteLine("3=>Otros -> ");
                    Console.Write("\nIngrese una opción -> ");
                    int tipo = Int32.Parse(Console.ReadLine());
                    */
                    
                    Console.Write("\nIngrese Nombre de la Marca -> ");
                    String marca = Console.ReadLine();
                    Console.Write("\nIngrese la Placa -> ");
                    String placa = Console.ReadLine();
                    Console.Write("\nIngrese el Color del Carro -> ");
                    String color = Console.ReadLine();

                    Console.WriteLine("\nSeleccione un estado.");
                    Console.WriteLine("1=>Disponible -> ");
                    Console.WriteLine("2=>No Disponible -> ");
                    Console.Write("\nIngrese la opción -> ");
                    int estado = Int32.Parse(Console.ReadLine());

                    Console.Write("Ingrese el ID del usuario -> ");
                    int idUser = Int32.Parse(Console.ReadLine());

                    int totalIdUser = objUsuario.ContarUsuarios();

                    if (idUser > totalIdUser || idUser < totalIdUser)
                    {
                        Console.WriteLine("El ID de Usuario Ingresado no existe, por favor validar");
                    }
                    else
                    {
                        EditarUnVehiculo(idVeh, modelo, "Carro", marca, placa, color, AgregarEstado(estado),
                            idUser);
                    }

                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("\n#####---######--> Eliminar un Carro <--#####---######.");
                    
                    Console.Write("Ingrese el ID del Carro a eliminar -> ");
                    int idVeh = Int32.Parse(Console.ReadLine());

                    Eliminar_un_Tipo(idVeh, "Carro");

                    Console.ReadKey();
                    break;
                }
                case 5:
                {
                    Console.Write("Saliste del Menu Carro Correctamente.\n");
                    isSalirCarro = false;
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