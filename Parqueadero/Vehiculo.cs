namespace Parqueadero;

public class Vehiculo
{
    private int _idVehiculo;
    private String _modelo;
    private String _tipo;
    private String _marca;
    private String _placa;
    private String _color;
    private bool _estado;
    private int _idUsuarioV;

    private List<Vehiculo> Vehiculos;

    private Usuario objUsuario = new Usuario();

    public Vehiculo()
    {
        Vehiculos = new List<Vehiculo>();

        Vehiculos.Add(new Vehiculo(1, "M-2019", "Moto", "Chevrolet", "ZSP-123", "Azul", true, 1));
        Vehiculos.Add(new Vehiculo(2, "M-2020", "Carro", "Mazda CX 5", "OPS-852", "Rojo", true, 2));
        Vehiculos.Add(new Vehiculo(3, "M-2021", "Carro", "Ferrari F40", "WRT-456", "Negro", true, 1));
    }

    public Vehiculo(int idVehiculo, string modelo, string tipo, string marca, string placa, string color, bool estado,
        int idUsuarioV)
    {
        _idVehiculo = idVehiculo;
        _modelo = modelo;
        _tipo = tipo;
        _marca = marca;
        _placa = placa;
        _color = color;
        _estado = estado;
        _idUsuarioV = idUsuarioV;
    }

    public int IdVehiculo
    {
        get => _idVehiculo;
        set => _idVehiculo = value;
    }

    public string Modelo
    {
        get => _modelo;
        set => _modelo = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Marca
    {
        get => _marca;
        set => _marca = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Placa
    {
        get => _placa;
        set => _placa = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Color
    {
        get => _color;
        set => _color = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool Estado
    {
        get => _estado;
        set => _estado = value;
    }

    public string Tipo
    {
        get => _tipo;
        set => _tipo = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int IdUsuarioV
    {
        get => _idUsuarioV;
        set => _idUsuarioV = value;
    }

    override
        public String ToString()
    {
        return "Vehiculo: ID-> " + IdVehiculo + " [" +
               "\n ID: " + IdVehiculo +
               "\n Tipo: " + Tipo +
               "\n Modelo: " + Modelo +
               "\n Marca: " + Marca +
               "\n Color: " + Color +
               "\n Placa: " + Placa +
               "\n Estado: " + Estado +
               "\n Id Usuario: " + IdUsuarioV +
               "\n]\n";
    }

    public void ListarVehiculos()
    {
        for (int i = 0; i < Vehiculos.Count; i++)
        {
            Console.Write("\n" + Vehiculos[i]);
        }
    }

    /*
    *  Console.Write("Ingrese el ID del Vehiculo que desea ver -> ");
    *  int idVeh = Int32.Parse(Console.ReadLine());
    */
    public void ListarUnaVehiculo(int idVeh)
    {
        bool encontrado = false;
        for (int i = 0; i < Vehiculos.Count && encontrado == false; i++)
        {
            if (Vehiculos[i].IdVehiculo == idVeh)
            {
                Console.WriteLine(Vehiculos[i] + " ");
                encontrado = true;
            }
        }
    }

    /*
    Console.WriteLine("\nSeleccione el Tipo.");
    Console.WriteLine("1=>Carro -> ");
    Console.WriteLine("2=>Moto -> ");
    Console.WriteLine("3=>Otros -> ");
    Console.Write("\nIngrese una opción -> ");
    String tipo = Console.ReadLine()
    AgregarTipo(tipo);
    */
    public void ListarTipos(string tipo)
    {
        foreach (var vehiculo in Vehiculos)
        {
            if (vehiculo.Tipo == tipo)
            {
                Console.WriteLine(vehiculo + " ");
            }
        }
    }

    /*
     * Console.Write("Ingrese el ID del Vehiculo a buscar -> ");
     * int idVeh = Int32.Parse(Console.ReadLine());
     */
    public Vehiculo Buscar_Un_Vehiculo(int idVeh)
    {
        Vehiculo buscada = null;
        bool encontrado = false;
        for (int i = 0; i < Vehiculos.Count && encontrado == false; i++)
        {
            if (Vehiculos[i].IdVehiculo == idVeh)
            {
                buscada = Vehiculos[i];
                encontrado = true;
            }
        }

        return buscada;
    }

    /*
     * Console.Write("Ingrese el Tipo -> ");
     * String tipo = Console.ReadLine();
     */
    public Vehiculo Buscar_Un_Tipo(int idVeh, string tipo)
    {
        Vehiculo buscada = null;
        bool encontrado = false;
        for (int i = 0; i < Vehiculos.Count && encontrado == false; i++)
        {
            if (Vehiculos[i].Tipo.Equals(tipo) && Vehiculos[i].IdVehiculo == idVeh)
            {
                buscada = Vehiculos[i];
                encontrado = true;
            }
        }

        return buscada;
    }

    public int ContarVehiculo()
    {
        int TotalVehiculo = 0;
        for (int i = 0; i < Vehiculos.Count; i++)
        {
            TotalVehiculo++;
        }

        return TotalVehiculo;
    }

    /* Console.Write("Ingrese el ID del Vehiculo -> ");
   * int idVeh = Int32.Parse(Console.ReadLine());*/

    public int RegresaIDVehiculo(int idVeh)
    {
        int RetornaID = 0;
        for (int i = 0; i < Vehiculos.Count; i++)
        {
            if (Vehiculos[i].IdVehiculo == idVeh)
            {
                RetornaID = Vehiculos[i].IdVehiculo;
            }
        }

        return RetornaID;
    }

    public string AgregarTipo(int tipo)
    {
        string nuevoTipo = null;
        if (tipo == 1)
        {
            nuevoTipo = "Carro";
        }
        else
        {
            if (tipo == 2)
            {
                nuevoTipo = "Moto";
            }
            else
            {
                nuevoTipo = "Otro";
            }
        }

        return nuevoTipo;
    }

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

    /*
       Console.Write("Ingrese el ID del Nuevo Vehiculo -> ");
       int idVeh = Int32.Parse(Console.ReadLine());

       Console.Write("\nIngrese el Modelo -> ");
       String modelo = Console.ReadLine()
       
        Console.WriteLine("\nSeleccione el Tipo.");
        Console.WriteLine("1=>Carro -> ");
        Console.WriteLine("2=>Moto -> ");
        Console.WriteLine("3=>Otros -> ");
        Console.Write("\nIngrese una opción -> ");
        String tipo = Console.ReadLine()
        AgregarTipo(tipo);
       
       Console.Write("\nIngrese Nombre de la Marca -> ");
       String marca = Console.ReadLine()
       Console.Write("\nIngrese la Placa -> ");
       String placa = Console.ReadLine()
       Console.Write("\nIngrese el Color del Vehiculo -> ");
       String color = Console.ReadLine()
       
        Console.WriteLine("\nSeleccione un estado.");
        Console.WriteLine("1=>Disponible -> ");
        Console.WriteLine("2=>No Disponible -> ");
        Console.Write("\nIngrese la opción -> ");
        String estado = Console.ReadLine()
        AgregarEstado(estado);

       
       Console.Write("Ingrese el ID del usuario -> ");
       int idUser = Int32.Parse(Console.ReadLine());

   */
    public void AgregarUnVehiculo(int idVeh, string modelo, string tipo, string marca, string placa, string color,
        bool estado, int idUsuarioV)
    {
        //objUsuario.RegresaIDUser(idUser);
        Vehiculo nueva = new Vehiculo(idVeh, modelo, tipo, marca, placa, color, estado, idUsuarioV);
        Vehiculos.Add(nueva);
        Console.WriteLine("\nSe agrego el nuevo Vehiculo correctamente.\n");
    }

    /*
      Console.Write("Ingrese el ID del Vehiculo a Modificar -> ");
      int idVeh = Int32.Parse(Console.ReadLine());

      Console.Write("\nIngrese el Modelo -> ");
      String modelo = Console.ReadLine()
      
       Console.WriteLine("\nSeleccione el Tipo.");
       Console.WriteLine("1=>Carro -> ");
       Console.WriteLine("2=>Moto -> ");
       Console.WriteLine("3=>Otros -> ");
       Console.Write("\nIngrese una opción -> ");
       String tipo = Console.ReadLine()
       AgregarTipo(tipo);
      
      Console.WriteLine("\nIngrese Nombre de la Marca -> ");
      String marca = Console.ReadLine()
      Console.Write("\nIngrese la Placa -> ");
      String placa = Console.ReadLine()
      Console.Write("\nIngrese el Color del Vehiculo -> ");
      String color = Console.ReadLine()
      
       Console.WriteLine("\nSeleccione un estado.");
       Console.WriteLine("1=>Disponible -> ");
       Console.WriteLine("2=>No Disponible -> ");
       Console.Write("\nIngrese la opción -> ");
       String estado = Console.ReadLine()
       AgregarEstado(estado);

      
      Console.Write("Ingrese el ID del usuario -> ");
      int idUser = Int32.Parse(Console.ReadLine());

  */
    public void EditarUnVehiculo(int idVeh, string modelo, string tipo, string marca, string placa, string color,
        bool estado, int idUsuarioV)
    {
        foreach (var vehiculo in Vehiculos)
        {
            if (vehiculo.IdVehiculo == idVeh)
            {
                vehiculo.Modelo = modelo;
                vehiculo.Tipo = tipo;
                vehiculo.Marca = marca;
                vehiculo.Placa = placa;
                vehiculo.Color = color;
                vehiculo.Estado = estado;
                vehiculo.IdUsuarioV = idUsuarioV;

                Console.WriteLine("\nSe modifica el ID: " + idVeh + " del Vehiculo correctamente.\n");
            }
        }
    }

    /*
    * Console.Write("Ingrese el ID del Vehiculo a eliminar -> ");
    * int idVeh = Int32.Parse(Console.ReadLine());
    */
    public void EliminarUnVehiculo(int idVeh)
    {
        Vehiculo buscado = Buscar_Un_Vehiculo(idVeh);
        if (buscado != null)
        {
            Vehiculos.Remove(buscado);
            Console.WriteLine("Se elimino el Vehiculo correctamente.");
        }
        else
        {
            Console.WriteLine("El Vehiculo que desea eliminar no existe.");
        }
    }

    public void Eliminar_un_Tipo(int idVeh, string tipo)
    {
        Vehiculo buscadoTipo = Buscar_Un_Tipo(idVeh, tipo);
        //Vehiculo buscado = Buscar_Un_Vehiculo(idVeh);
        if (buscadoTipo != null)
        {
            Vehiculos.Remove(buscadoTipo);
            Console.WriteLine("Se elimino correctamente.");
        }
        else
        {
            Console.WriteLine("El dato que desea eliminar no existe.");
        }
    }
    
    

    public void OperacionesVehiculos()
    {
        Boolean isSalirVeh = true;

        while (isSalirVeh)
        {
            Console.WriteLine("#####---######--> Menu Principal Vehiculos <-- #####---######");
            Console.Write("\n\t1.Listar Todos los Vehiculos.");
            Console.Write("\n\t2.Ir a Menu Motos.");
            Console.Write("\n\t3.Ir a Menu Carros.");
            Console.Write("\n\t4.Agregar un Vehiculo.");
            Console.Write("\n\t5.Modificar un Vehiculo.");
            Console.Write("\n\t6.Eliminar un Vehiculo.");
            Console.Write("\n\t7.Listar un Vehiculo.");
            Console.Write("\n\t8.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionVeh = Int32.Parse(Console.ReadLine());

            switch (opcionVeh)
            {
                case 1:
                {
                    Console.WriteLine("\n#####---######--> Listar Todos los Vehiculos <--#####---######.");
                    ListarVehiculos();
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("\n#####---######--> Menu Principal Motos <--#####---######.");
                    Moto objMoto = new Moto();
                    objMoto.OperacionesMoto();
                    Console.ReadKey();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("\n#####---######--> Menu Principal Carros <--#####---######.");
                    Carro objCarro = new Carro();
                    objCarro.OperacionesCarros();
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("\n#####---######--> Agregar un Vehiculo <--#####---######.");


                    /*Console.Write("Ingrese el ID del Nuevo Vehiculo -> ");
                    int idVeh = Int32.Parse(Console.ReadLine());*/

                    Console.Write("\nIngrese el Modelo -> ");
                    String modelo = Console.ReadLine();

                    Console.WriteLine("\nSeleccione el Tipo.");
                    Console.WriteLine("1=>Carro -> ");
                    Console.WriteLine("2=>Moto -> ");
                    Console.WriteLine("3=>Otros -> ");
                    Console.Write("\nIngrese una opción -> ");
                    int tipo = Int32.Parse(Console.ReadLine());

                    Console.Write("\nIngrese Nombre de la Marca -> ");
                    String marca = Console.ReadLine();
                    Console.Write("\nIngrese la Placa -> ");
                    String placa = Console.ReadLine();
                    Console.Write("\nIngrese el Color del Vehiculo -> ");
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
                        int totalVeh = ContarVehiculo();
                        totalVeh = totalVeh + 1;
                        AgregarUnVehiculo(totalVeh, modelo, AgregarTipo(tipo), marca, placa, color,
                            AgregarEstado(estado),
                            idUser);
                    }

                    Console.ReadKey();
                    break;
                }
                case 5:
                {
                    Console.WriteLine("\n#####---######--> Modificar un Vehiculo <--#####---######.");

                    Console.Write("Ingrese el ID del Vehiculo a Modificar -> ");
                    int idVeh = Int32.Parse(Console.ReadLine());

                    Console.Write("\nIngrese el Modelo -> ");
                    String modelo = Console.ReadLine();

                    Console.WriteLine("\nSeleccione el Tipo.");
                    Console.WriteLine("1=>Carro -> ");
                    Console.WriteLine("2=>Moto -> ");
                    Console.WriteLine("3=>Otros -> ");
                    Console.Write("\nIngrese una opción -> ");
                    int tipo = Int32.Parse(Console.ReadLine());

                    Console.Write("\nIngrese Nombre de la Marca -> ");
                    String marca = Console.ReadLine();
                    Console.Write("\nIngrese la Placa -> ");
                    String placa = Console.ReadLine();
                    Console.Write("\nIngrese el Color del Vehiculo -> ");
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
                        EditarUnVehiculo(idVeh, modelo, AgregarTipo(tipo), marca, placa, color, AgregarEstado(estado),
                            idUser);
                    }


                    Console.ReadKey();
                    break;
                }
                case 6:
                {
                    Console.WriteLine("\n#####---######--> Eliminar un Vehiculo <--#####---######.");


                    Console.Write("Ingrese el ID del Vehiculo a eliminar -> ");
                    int idVeh = Int32.Parse(Console.ReadLine());

                    EliminarUnVehiculo(idVeh);

                    Console.ReadKey();
                    break;
                }
                case 7:
                {
                    Console.WriteLine("\n#####---######--> Lista Un Vehiculo con ID Específico <--#####---######.");
                    
                    Console.Write("Ingrese el ID del Vehiculo que desea ver -> ");
                    int idVeh = Int32.Parse(Console.ReadLine());

                    ListarUnaVehiculo(idVeh);
                    Console.ReadKey();
                    break;
                }
                case 8:
                {
                    Console.Write("Saliste del Menu Vehiculo Correctamente.\n");
                    isSalirVeh = false;
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