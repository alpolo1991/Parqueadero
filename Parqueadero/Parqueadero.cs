namespace Parqueadero;

public class Parqueadero
{
    private int _idParqueadero;
    private String _nombreP;
    private String _direccion;
    private int _telefono;
    private bool _estadoParq;

    private List<Parqueadero> Parqueaderos;

    public Parqueadero()
    {
        Parqueaderos = new List<Parqueadero>();

        Parqueaderos.Add(new Parqueadero(1, "Seguro y Feliz", "Calle 80 N 24-12", 3475689, true));
    }

    public Parqueadero(int idParqueadero, string nombreP, string direccion, int telefono, bool estadoParq)
    {
        _idParqueadero = idParqueadero;
        _nombreP = nombreP;
        _direccion = direccion;
        _telefono = telefono;
        _estadoParq = estadoParq;
    }

    public int IdParqueadero
    {
        get => _idParqueadero;
        set => _idParqueadero = value;
    }

    public string NombreP
    {
        get => _nombreP;
        set => _nombreP = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Direccion
    {
        get => _direccion;
        set => _direccion = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Telefono
    {
        get => _telefono;
        set => _telefono = value;
    }

    public bool EstadoParq
    {
        get => _estadoParq;
        set => _estadoParq = value;
    }

    override
        public String ToString()
    {
        return "Parqueadero: ID-> " + IdParqueadero + " " +
               "[" +
               "\n ID: " + IdParqueadero +
               "\n Nombre Parqueader: " + NombreP +
               "\n Telefono: " + Telefono +
               "\n Dirección: " + Direccion +
               "\n Esta Disponible?: " + EstadoParq +
               "\n]";
    }

    public void ListarParqueaderos()
    {
        for (int i = 0; i < Parqueaderos.Count; i++)
        {
            Console.Write("\n" + Parqueaderos[i]);
        }
    }

    /*
     *  Console.Write("Ingrese el ID del Parqueaderos que desea ver -> ");
     *  int idParqueadero = Int32.Parse(Console.ReadLine());
     */
    public void ListarUnParqueadero(int idParqueadero)
    {
        bool encontrado = false;
        for (int i = 0; i < Parqueaderos.Count && encontrado == false; i++)
        {
            if (Parqueaderos[i].IdParqueadero == idParqueadero)
            {
                Console.WriteLine(Parqueaderos[i] + " ");
                encontrado = true;
            }
        }
    }

    /*
     * Console.Write("Ingrese el ID del Parqueadero a buscar -> ");
     * int idParqueadero = Int32.Parse(Console.ReadLine());
     * 
     */
    public Parqueadero Buscar_Un_Parqueadero(int idParqueadero)
    {
        Parqueadero buscada = null;
        bool encontrado = false;
        for (int i = 0; i < Parqueaderos.Count && encontrado == false; i++)
        {
            if (Parqueaderos[i].IdParqueadero == idParqueadero)
            {
                buscada = Parqueaderos[i];
                encontrado = true;
            }
        }

        return buscada;
    }

    public int ContarParqueaderos()
    {
        int TotalParqueaderos = 0;
        for (int i = 0; i < Parqueaderos.Count; i++)
        {
            TotalParqueaderos++;
        }

        return TotalParqueaderos;
    }

    /* Console.Write("Ingrese el ID del Parqueadero -> ");
    * int idParqueadero = Int32.Parse(Console.ReadLine());*/

    public int RegresaIDParqueadero(int idParqueadero)
    {
        int RetornaID = 0;
        for (int i = 0; i < Parqueaderos.Count; i++)
        {
            if (Parqueaderos[i].IdParqueadero == idParqueadero)
            {
                RetornaID = Parqueaderos[i].IdParqueadero;
            }
        }

        return RetornaID;
    }

    /*
    * Console.Write("Ingrese el ID del Nuevo Parqueadero -> ");
    * int idParqueadero = Int32.Parse(Console.ReadLine()); //// NO
    * 
    * Console.Write("Ingrese el Nombre -> ");
    * string nombreP = Console.ReadLine();
    * Console.Write("Ingrese la Dirección del Parqueadero -> ");
    * string direccion = Console.ReadLine();
    * Console.Write("Ingrese el Telefono del Parqueadero -> ");
    * int telefono = Int32.Parse(Console.ReadLine());
    * 
    */

    public void AgregarUnPaqueadero(int idParqueadero, string nombreP, string direccion, int telefono, bool estadoParq)
    {
        Parqueadero nueva = new Parqueadero(idParqueadero, nombreP, direccion, telefono, estadoParq);
        Parqueaderos.Add(nueva);
        Console.WriteLine("\nSe agrego el nuevo Parqueadero correctamente.\n");
    }

    /*
    * Console.Write("Ingrese el ID del Nuevo Parqueadero -> ");
    * int idParqueadero = Int32.Parse(Console.ReadLine()); //// NO
    * 
    * Console.Write("Ingrese el Nombre -> ");
    * string nombreP = Console.ReadLine();
    * Console.Write("Ingrese la Dirección del Parqueadero -> ");
    * string direccion = Console.ReadLine();
    * Console.Write("Ingrese el Telefono del Parqueadero -> ");
    * int telefono = Int32.Parse(Console.ReadLine());
    * 
    */
    public void EditarUnParqueadero(int idParqueadero, string nombreP, string direccion, int telefono, bool estadoParq)
    {
        foreach (var parqueadero in Parqueaderos)
        {
            if (parqueadero.IdParqueadero == idParqueadero)
            {
                parqueadero.NombreP = nombreP;
                parqueadero.Direccion = direccion;
                parqueadero.Telefono = telefono;
                parqueadero.EstadoParq = estadoParq;

                Console.WriteLine("\nSe modifica el ID: " + idParqueadero + " del Parqueadero correctamente.\n");
            }
        }
    }


    /*
    * Console.Write("Ingrese el ID del Parqueadero a eliminar -> ");
    * int idParqueadero = Int32.Parse(Console.ReadLine());
    */
    public void EliminarUnParqueadero(int idParqueadero)
    {
        Parqueadero buscado = Buscar_Un_Parqueadero(idParqueadero);
        if (buscado != null)
        {
            Parqueaderos.Remove(buscado);
            Console.WriteLine("Se elimino el Parqueadero correctamente.");
        }
        else
        {
            Console.WriteLine("El Parqueadero que desea eliminar no existe.");
        }
    }

    public void ConsultarDisponibilidad(int idParq)
    {
        bool encontrado = false;
        for (int i = 0; i < Parqueaderos.Count && encontrado == false; i++)
        {
            if (Parqueaderos[i].IdParqueadero == idParq)
            {
                //Console.WriteLine(peliculas[i].EstadoPelicula + " ");
                if (Parqueaderos[i].EstadoParq)
                {
                    Console.WriteLine(Parqueaderos[i] + " ");
                    Console.WriteLine();
                    Console.WriteLine("#########-----------------############");
                    Console.WriteLine("\tDISPONIBLE");
                    Console.WriteLine("#########-----------------############");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(Parqueaderos[i] + " ");
                    Console.WriteLine("#########-----------------############");
                    Console.WriteLine("\tNO DISPONIBLE");
                    Console.WriteLine("#########-----------------############");
                }

                encontrado = true;
            }
        }
    }

    /*
     * Console.Write("Ingrese la Disponibilidad del Parqueadero.");
     * Console.Write("1=>Disponible.");
     * Console.Write("2=>No Disponible.");
     * Console.Write("Ingrese una Opciṕn -> ");
     * int estado = Int32.Parse(Console.ReadLine());
    */
    public bool AgregarEstado(int estado)
    {
        bool isNuevoEstado = false;
        if (estado == 1)
        {
            isNuevoEstado = true;
        }
        else
        {
            isNuevoEstado = false;
        }

        return isNuevoEstado;
    }

    public void OperacionesParqueadero()
    {
        Boolean isSalirParq = true;

        while (isSalirParq)
        {
            Console.WriteLine("#####---######--> Menu Principal Paqueaderos <-- #####---######");
            Console.Write("\n\t1.Listar Todos los Paqueaderos.");
            Console.Write("\n\t2.Listar un Paqueadero.");
            Console.Write("\n\t3.Agregar un Nuevo Paqueadero.");
            Console.Write("\n\t4.Modificar un Paqueadero.");
            Console.Write("\n\t5.Eliminar un Paqueadero.");
            Console.Write("\n\t6.Consultar Estado Parqueadero.");
            Console.Write("\n\t7.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionPar = Int32.Parse(Console.ReadLine());

            switch (opcionPar)
            {
                case 1:
                {
                    Console.WriteLine("\n#####---######--> Lista Todos los Paqueaderos <--#####---######.");
                    ListarParqueaderos();
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("\n#####---######--> Lista Un Paqueadero <--#####---######.");

                    Console.Write("Ingrese el ID del Parqueaderos que desea ver -> ");
                    int idParqueadero = Int32.Parse(Console.ReadLine());

                    ListarUnParqueadero(idParqueadero);
                    Console.ReadKey();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("\n#####---######--> Agregar un Nuevo Paqueadero <--#####---######.");


                    /*Console.Write("Ingrese el ID del Nuevo Parqueadero -> ");
                    int idParqueadero = Int32.Parse(Console.ReadLine()); */

                    Console.Write("Ingrese el Nombre -> ");
                    string nombreP = Console.ReadLine();
                    Console.Write("Ingrese la Dirección del Parqueadero -> ");
                    string direccion = Console.ReadLine();
                    Console.Write("Ingrese el Telefono del Parqueadero -> ");
                    int telefono = Int32.Parse(Console.ReadLine());

                    int idParqueadero = ContarParqueaderos();

                    idParqueadero = idParqueadero + 1;

                    Console.WriteLine("Ingrese la Disponibilidad del Parqueadero.");
                    Console.WriteLine("1=>Disponible.");
                    Console.WriteLine("2=>No Disponible.");
                    Console.Write("Ingrese una Opciṕn -> ");
                    int estado = Int32.Parse(Console.ReadLine());

                    AgregarUnPaqueadero(idParqueadero, nombreP, direccion, telefono, AgregarEstado(estado));
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("\n#####---######--> Modificar un Paqueadero <--#####---######.");

                    Console.Write("Ingrese el ID del Nuevo Parqueadero -> ");
                    int idParqueadero = Int32.Parse(Console.ReadLine());

                    Console.Write("Ingrese el Nombre -> ");
                    string nombreP = Console.ReadLine();
                    Console.Write("Ingrese la Dirección del Parqueadero -> ");
                    string direccion = Console.ReadLine();
                    Console.Write("Ingrese el Telefono del Parqueadero -> ");
                    int telefono = Int32.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Ingrese la Disponibilidad del Parqueadero.");
                    Console.WriteLine("1=>Disponible.");
                    Console.WriteLine("2=>No Disponible.");
                    Console.Write("Ingrese una Opciṕn -> ");
                    int estado = Int32.Parse(Console.ReadLine());

                    EditarUnParqueadero(idParqueadero, nombreP, direccion, telefono, AgregarEstado(estado));
                    Console.ReadKey();
                    break;
                }
                case 5:
                {
                    Console.WriteLine("\n#####---######--> Elimina un Paqueadero <--#####---######.");

                    Console.Write("Ingrese el ID del Parqueadero a eliminar -> ");
                    int idParqueadero = Int32.Parse(Console.ReadLine());

                    EliminarUnParqueadero(idParqueadero);
                    Console.ReadKey();
                    break;
                }
                case 6:
                {
                    Console.WriteLine("\n#####---######--> Modificar un Paqueadero <--#####---######.");

                    Console.Write("Ingrese el ID del Nuevo Parqueadero -> ");
                    int idParqueadero = Int32.Parse(Console.ReadLine());
                    
                    ConsultarDisponibilidad(idParqueadero);
                    Console.ReadKey();
                    break;
                }
                case 7:
                {
                    Console.Write("Saliste del Menu Paqueadero Correctamente.\n");
                    isSalirParq = false;
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