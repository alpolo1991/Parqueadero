namespace Parqueadero;

public class Factura
{
    private int _idFactura;
    private DateTime _fechaGenerada;
    private DateTime _horaIngreso;
    private DateTime _fechaIngreso;
    private DateTime _fechaSalida;
    private String _anotacion;
    private double _subTotal;
    private double _ivaMonto;
    private double _total;
    private int _idUsuarioF;
    private int _idParqueaderoF;

    private Usuario objUsuario = new Usuario();
    private Parqueadero objParqueadero = new Parqueadero();

    private List<Factura> Facturas;

    public Factura()
    {
        Facturas = new List<Factura>();

        Facturas.Add(new Factura(1, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, 15.000, 0.18,
            ((0.18 * 15.000) + 15.000), 1, 1, "Buen Servicio"));
        Facturas.Add(new Factura(2, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, 12.000, 0.19,
            ((0.19 * 12.000) + 12.000), 2, 1, "Seguro y confiable"));
    }

    public Factura(int idFactura, DateTime fechaGenerada, DateTime horaIngreso, DateTime fechaIngreso,
        DateTime fechaSalida, double subTotal, double ivaMonto,
        double total, int idUsuarioF, int idParqueaderoF, string anotacion)
    {
        _idFactura = idFactura;
        _fechaGenerada = fechaGenerada;
        _horaIngreso = horaIngreso;
        _fechaIngreso = fechaIngreso;
        _fechaSalida = fechaSalida;
        _subTotal = subTotal;
        _ivaMonto = ivaMonto;
        _total = total;
        _idUsuarioF = idUsuarioF;
        _idParqueaderoF = idParqueaderoF;
        _anotacion = anotacion;
    }

    public int IdFactura
    {
        get => _idFactura;
        set => _idFactura = value;
    }

    public DateTime FechaGenerada
    {
        get => _fechaGenerada;
        set => _fechaGenerada = value;
    }

    public DateTime HoraIngreso
    {
        get => _horaIngreso;
        set => _horaIngreso = value;
    }

    public DateTime FechaIngreso
    {
        get => _fechaIngreso;
        set => _fechaIngreso = value;
    }

    public DateTime FechaSalida
    {
        get => _fechaSalida;
        set => _fechaSalida = value;
    }

    public string Anotacion
    {
        get => _anotacion;
        set => _anotacion = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double SubTotal
    {
        get => _subTotal;
        set => _subTotal = value;
    }

    public double IvaMonto
    {
        get => _ivaMonto;
        set => _ivaMonto = value;
    }

    public double Total
    {
        get => _total;
        set => _total = value;
    }

    public int IdUsuarioF
    {
        get => _idUsuarioF;
        set => _idUsuarioF = value;
    }

    public int IdParqueaderoF
    {
        get => _idParqueaderoF;
        set => _idParqueaderoF = value;
    }

    override
        public String ToString()
    {
        return "Factura: " + IdFactura + " [" +
               "\n ID: " + IdFactura +
               "\n Fecha Generada: " + FechaGenerada +
               "\n Fecha Ingreso: " + FechaIngreso +
               "\n Hora Ingreso: " + HoraIngreso +
               "\n Fecha Salida: " + FechaSalida +
               "\n Sub Total: " + SubTotal +
               "\n Iva: " + IvaMonto +
               "\n Total: " + Total +
               "\n IdUsuario: " + IdUsuarioF +
               "\n IdParqueadero: " + IdParqueaderoF +
               "\n Anotación: " + Anotacion +
               "\n]\n";
    }

    public void ListarFacturas()
    {
        for (int i = 0; i < Facturas.Count; i++)
        {
            Console.Write("\n" + Facturas[i]);
        }
    }

    /*
     *  Console.Write("Ingrese el ID de la factura que desea ver -> ");
     *  int idFact = Int32.Parse(Console.ReadLine());
     */
    public void ListarUnaFactura(int idFact)
    {
        bool encontrado = false;
        for (int i = 0; i < Facturas.Count && encontrado == false; i++)
        {
            if (Facturas[i].IdFactura == idFact)
            {
                Console.WriteLine(Facturas[i] + " ");
                encontrado = true;
            }
        }
    }
    
    /*
    *  Console.Write("Ingrese el ID de la factura que desea ver -> ");
    *  int idFact = Int32.Parse(Console.ReadLine());
    */
    public void ListarUnaFacturaU(int idUser)
    {
        bool encontrado = false;
        for (int i = 0; i < Facturas.Count && encontrado == false; i++)
        {
            if (Facturas[i].IdUsuarioF == idUser)
            {
                Console.WriteLine(Facturas[i] + " ");
                encontrado = true;
            }
        }
    }

    /*
     * Console.Write("Ingrese el ID de la Factura a buscar -> ");
     * int idFact = Int32.Parse(Console.ReadLine());
     * 
     */
    public Factura Buscar_Una_Factura(int idFact)
    {
        Factura buscada = null;
        bool encontrado = false;
        for (int i = 0; i < Facturas.Count && encontrado == false; i++)
        {
            if (Facturas[i].IdFactura == idFact)
            {
                buscada = Facturas[i];
                encontrado = true;
            }
        }

        return buscada;
    }

    public int ContarFacturas()
    {
        int TotalFacturas = 0;
        for (int i = 0; i < Facturas.Count; i++)
        {
            TotalFacturas++;
        }

        return TotalFacturas;
    }

    /* Console.Write("Ingrese el ID del Parqueadero -> ");
    * int idFact = Int32.Parse(Console.ReadLine());*/

    public int RegresaIDFactura(int idFact)
    {
        int RetornaID = 0;
        for (int i = 0; i < Facturas.Count; i++)
        {
            if (Facturas[i].IdFactura == idFact)
            {
                RetornaID = Facturas[i].IdFactura;
            }
        }

        return RetornaID;
    }

    /*
        Console.Write("Ingrese el ID de la Nueva Factura -> ");
        int idFactura = Int32.Parse(Console.ReadLine());

        Console.Write("\nIngrese el Nuevo SubTotal: ");
        double subTotal = Double.Parse(Console.ReadLine());
        Console.Write("\nIngrese el Nuevo Iva: ");
        double ivaMonto = Double.Parse(Console.ReadLine());
        double total = (subtotal * iva) + subtotal;
        
        Console.Write("Ingrese el ID del usuario -> ");
        int idUser = Int32.Parse(Console.ReadLine());
        
        Console.Write("Ingrese el ID del Parqueadero -> ");
        int idParqueadero = Int32.Parse(Console.ReadLine());

    */

    public void AgregarUnaFactura(int idFactura, DateTime fechaGenerada, DateTime horaIngreso, DateTime fechaIngreso,
        DateTime fechaSalida, double subTotal, double ivaMonto,
        double total, int idUsuarioF, int idParqueaderoF, string anotacion)
    {
        //objUsuario.RegresaIDUser(idUser);
        //objParqueadero.RegresaIDParqueadero(idParqueadero);
        Factura nueva = new Factura(idFactura, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, subTotal,
            ivaMonto, total, idUsuarioF, idParqueaderoF, anotacion);
        Facturas.Add(nueva);
        Console.WriteLine("\nSe agrego el nuevo Parqueadero correctamente.\n");
    }

    /*
    Console.Write("Ingrese el ID de la Nueva Factura -> ");
    int idFactura = Int32.Parse(Console.ReadLine());

    Console.Write("\nIngrese el Nuevo SubTotal: ");
    double subTotal = Double.Parse(Console.ReadLine());
    Console.Write("\nIngrese el Nuevo Iva: ");
    double ivaMonto = Double.Parse(Console.ReadLine());
    double total = (subtotal * iva) + subtotal;
        
    Console.Write("Ingrese el Nuevo ID del usuario -> ");
    int idUser = Int32.Parse(Console.ReadLine());
        
    Console.Write("Ingrese el Nuevo ID del Parqueadero -> ");
    int idParqueadero = Int32.Parse(Console.ReadLine());

    */

    public void EditarUnaFactura(int idFactura, double subTotal, double ivaMonto, double total, int idUsuarioF,
        int idParqueaderoF, string anotacion)
    {
        foreach (var factura in Facturas)
        {
            if (factura.IdFactura == idFactura)
            {
                factura.SubTotal = subTotal;
                factura.IvaMonto = ivaMonto;
                factura.Total = total;
                factura.IdUsuarioF = idUsuarioF;
                factura.IdParqueaderoF = idParqueaderoF;
                factura.Anotacion = anotacion;

                Console.WriteLine("\nSe modifica el ID: " + idFactura + " de la Factura correctamente.\n");
            }
        }
    }

    /*
   * Console.Write("Ingrese el ID de la Factura a eliminar -> ");
   * int idFactura = Int32.Parse(Console.ReadLine());
   */
    public void EliminarUnaFactura(int idFactura)
    {
        Factura buscado = Buscar_Una_Factura(idFactura);
        if (buscado != null)
        {
            Facturas.Remove(buscado);
            Console.WriteLine("Se elimino la Factura correctamente.");
        }
        else
        {
            Console.WriteLine("La Factura que desea eliminar no existe.");
        }
    }

    public void OperacionesFacturas()
    {
        Boolean isSalirFact = true;

        while (isSalirFact)
        {
            Console.WriteLine("#####---######--> Menu Principal Facturas <-- #####---######");
            Console.Write("\n\t1.Listar Todas las Facturas.");
            Console.Write("\n\t2.Listar una Factura.");
            Console.Write("\n\t3.Agregar Nueva Factura.");
            Console.Write("\n\t4.Modificar una Factura.");
            Console.Write("\n\t5.Eliminar una Factura.");
            Console.Write("\n\t6.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionFact = Int32.Parse(Console.ReadLine());

            switch (opcionFact)
            {
                case 1:
                {
                    Console.WriteLine("\n#####---######--> Lista Todos las Facturas <--#####---######.");
                    ListarFacturas();
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("\n#####---######--> Lista una Factura <--#####---######.");

                    Console.Write("Ingrese el ID de la factura que desea ver -> ");
                    int idFact = Int32.Parse(Console.ReadLine());

                    ListarUnaFactura(idFact);
                    Console.ReadKey();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("\n#####---######--> Agrega una Nueva Factura <--#####---######.");

                    Console.Write("\nIngrese una Anotación -> ");
                    string anotacion = Console.ReadLine();
                    Console.Write("\nIngrese el Nuevo SubTotal: ");
                    double subTotal = Double.Parse(Console.ReadLine());
                    Console.Write("\nIngrese el Nuevo Iva: ");
                    double ivaMonto = Double.Parse(Console.ReadLine());
                    double total = (subTotal * ivaMonto) + subTotal;

                    Console.Write("Ingrese el ID del usuario -> ");
                    int idUser = Int32.Parse(Console.ReadLine());

                    Console.Write("Ingrese el ID del Parqueadero -> ");
                    int idParqueadero = Int32.Parse(Console.ReadLine());


                    int idFact = ContarFacturas();
                    idFact = idFact + 1;
                    
                    int totalIdUser = objUsuario.ContarUsuarios();
                    int totalParq = objParqueadero.ContarParqueaderos();
                    
                    if (idUser > totalIdUser || idUser < totalIdUser)
                    {
                        Console.WriteLine("El ID del Usuario Ingresado no existe, por favor validar");
                    }
                    else
                    {
                        if (idParqueadero > totalParq || idParqueadero < totalParq)
                        {
                            Console.WriteLine("El ID del Parqueadero Ingresado no existe, por favor validar");
                        }
                        else
                        {
                            AgregarUnaFactura(idFact, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, subTotal,
                                ivaMonto, total, objUsuario.RegresaIDUser(idUser),
                                objParqueadero.RegresaIDParqueadero(idParqueadero), anotacion);
                        }
                    }

                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("\n#####---######--> Modificar una Factura <--#####---######.");


                    Console.Write("Ingrese el ID de la Factura a Modificar -> ");
                    int idFact = Int32.Parse(Console.ReadLine());
                    
                    Console.Write("\nIngrese una Anotación -> ");
                    string anotacion = Console.ReadLine();

                    Console.Write("\nIngrese el Nuevo SubTotal: ");
                    double subTotal = Double.Parse(Console.ReadLine());
                    Console.Write("\nIngrese el Nuevo Iva: ");
                    double ivaMonto = Double.Parse(Console.ReadLine());
                    double total = (subTotal * ivaMonto) + subTotal;

                    Console.Write("Ingrese el Nuevo ID del usuario -> ");
                    int idUser = Int32.Parse(Console.ReadLine());

                    Console.Write("Ingrese el Nuevo ID del Parqueadero -> ");
                    int idParqueadero = Int32.Parse(Console.ReadLine());
                    
                    int totalIdUser = objUsuario.ContarUsuarios();
                    int totalParq = objParqueadero.ContarParqueaderos();

                    if (idUser > totalIdUser || idUser < totalIdUser)
                    {
                        Console.WriteLine("El ID del Usuario Ingresado no existe, por favor validar");
                    }
                    else
                    {
                        if (idParqueadero > totalParq || idParqueadero < totalParq)
                        {
                            Console.WriteLine("El ID del Parqueadero Ingresado no existe, por favor validar");
                        }
                        else
                        {
                            EditarUnaFactura(idFact, subTotal, ivaMonto, total, objUsuario.RegresaIDUser(idUser),
                                objParqueadero.RegresaIDParqueadero(idParqueadero), anotacion);
                            Console.ReadKey();
                        }
                    }
                    break;
                }
                case 5:
                {
                    Console.WriteLine("\n#####---######--> Eliminar una Factura <--#####---######.");


                    Console.Write("Ingrese el ID de la Factura a eliminar -> ");
                    int idFact = Int32.Parse(Console.ReadLine());

                    EliminarUnaFactura(idFact);

                    Console.ReadKey();
                    break;
                }
                case 6:
                {
                    Console.Write("Saliste del Menu Factura Correctamente.\n");
                    isSalirFact = false;
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