using System.Security.Cryptography;
using System.Text;

namespace Parqueadero;

public class Usuario
{
    private int _idUsuario;
    private String _nombre;
    private String _apellidos;
    private string _username;
    private string _password;
    private String _direccion;
    private bool _isadmin;
    private int _telefono;

    private List<Usuario> Usuarios;

    public Usuario()
    {
        Usuarios = new List<Usuario>();

        Usuarios.Add(new Usuario(1, "Alfonso", "Gonzalez", "alfonso", "123456", "Cra 31 N 85 - 78", true, 31245678));
        Usuarios.Add(new Usuario(2, "Test", "Test", "test", "123", "Cra 21 N 58 - 88", false, 31245678));
    }

    public Usuario(int idUsuario, string nombre, string apellidos, string username, string password, string direccion,
        bool isadmin, int telefono)
    {
        _idUsuario = idUsuario;
        _nombre = nombre;
        _apellidos = apellidos;
        _username = username;
        _password = password;
        _direccion = direccion;
        _isadmin = isadmin;
        _telefono = telefono;
    }

    public int IdUsuario
    {
        get => _idUsuario;
        set => _idUsuario = value;
    }

    public string Nombre
    {
        get => _nombre;
        set => _nombre = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Apellidos
    {
        get => _apellidos;
        set => _apellidos = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Username
    {
        get => _username;
        set => _username = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Password
    {
        get => _password;
        set => _password = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Direccion
    {
        get => _direccion;
        set => _direccion = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool IsAdmin
    {
        get => _isadmin;
        set => _isadmin = value;
    }

    public int Telefono
    {
        get => _telefono;
        set => _telefono = value;
    }

    override
        public String ToString()
    {
        return "Usuario: ID-> " + IdUsuario + " " +
               "[" +
               "\n ID: " + IdUsuario +
               "\n Nombre: " + Nombre +
               "\n Apellidos: " + Apellidos +
               "\n Dirección: " + Direccion +
               "\n Es Admin?: " + IsAdmin +
               "\n Username: " + Username +
               "\n Telefono: " + Telefono +
               "\n]";
    }

    /*
   *  Console.Write("Ingrese el ID del Usuario que desea validar si tiene permisos de Administrador.");
     * Console.Write("ID Usuario ->: );
   *  int permiso = Int32.Parse(Console.ReadLine());
  */

    public bool ValidarPermiso(int idUser)
    {
        bool estado_encontrado = false;
        foreach (var usuario in Usuarios)
        {
            if (usuario.IdUsuario == idUser)
            {
                if (usuario.IsAdmin)
                {
                    estado_encontrado = true;
                }
                else
                {
                    estado_encontrado = false;
                }
            }
        }

        return estado_encontrado;
    }

    public void ConsultarPermiso(int idUser)
    {
        string estado_encontrado = null;
        foreach (var usuario in Usuarios)
        {
            if (usuario.IdUsuario == idUser)
            {
                if (usuario.IsAdmin)
                {
                    Console.WriteLine("\nNombre: {0} \nApellido: {1} \n", usuario.Nombre, usuario.Apellidos);
                    Console.WriteLine();
                    Console.WriteLine("#########-----------------############");
                    Console.WriteLine("\tADMINISTRADOR");
                    Console.WriteLine("#########-----------------############");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\nNombre: {0} \nApellido: {1} \n", usuario.Nombre,
                        usuario.Apellidos);
                    Console.WriteLine("#########-----------------############");
                    Console.WriteLine("\tNORMAL");
                    Console.WriteLine("#########-----------------############");
                }
            }
        }
    }

    /*
     * Console.Write("Ingrese el Nuevo Permiso al Usuario.");
     * Console.Write("1=>Admin -> ");
     * Console.Write("2=>Normal -> ");
     * Console.Write("Ingrese una Seleccion -> ");
     * int permiso = Int32.Parse(Console.ReadLine());
    */
    public bool AgregarPermiso(int permiso)
    {
        bool isNuevoPermiso = false;
        if (permiso == 1)
        {
            isNuevoPermiso = true;
        }
        else
        {
            isNuevoPermiso = false;
        }

        return isNuevoPermiso;
    }

    public void ModificarPermiso(int permiso, int idUser)
    {
        foreach (var usuario in Usuarios)
        {
            if (usuario.IdUsuario == idUser)
            {
                usuario.IsAdmin = AgregarPermiso(permiso);
                Console.WriteLine("Se Modifica el permiso del usuario: {0} correctamente.", usuario.Username);
            }
        }
    }

    public void ListarUsuarios()
    {
        for (int i = 0; i < Usuarios.Count; i++)
        {
            Console.Write("\n" + Usuarios[i]);
        }
    }

    /*
     *  Console.Write("Ingrese el ID del usuario que desea ver -> ");
     *  int idUser = Int32.Parse(Console.ReadLine());
     */
    public void ListarUnUsuario(int idUser)
    {
        bool encontrado = false;
        for (int i = 0; i < Usuarios.Count && encontrado == false; i++)
        {
            if (Usuarios[i].IdUsuario == idUser)
            {
                Console.WriteLine(Usuarios[i] + " ");
                encontrado = true;
            }
        }
    }

    /*
    public bool Listar_Un_Usuario(int idUser)
    {
        bool encontrado = false;
        for (int i = 0; i < Usuarios.Count && encontrado == false; i++)
        {
            if (Usuarios[i].IdUsuario == idUser)
            {
                encontrado = true;
            }
        }
        return encontrado;
    }*/

    /*
     * Console.Write("Ingrese el ID del usuario a buscar -> ");
     * int idUser = Int32.Parse(Console.ReadLine());
     * 
     */
    public Usuario Buscar_Un_usuario(int idUser)
    {
        Usuario buscada = null;
        bool encontrado = false;
        for (int i = 0; i < Usuarios.Count && encontrado == false; i++)
        {
            if (Usuarios[i].IdUsuario == idUser)
            {
                buscada = Usuarios[i];
                encontrado = true;
            }
        }

        return buscada;
    }

    /*
     * Console.Write("Ingrese el ID del usuario a eliminar -> ");
     * int idUser = Int32.Parse(Console.ReadLine());
     */
    public void EliminarUnUsuario(int idUser)
    {
        Usuario buscado = Buscar_Un_usuario(idUser);
        if (buscado != null)
        {
            Usuarios.Remove(buscado);
            Console.WriteLine("Se elimino el usuario correctamente.");
        }
        else
        {
            Console.WriteLine("El usuario que desea eliminar no existe.");
        }
    }

    /*
     * Console.Write("Ingrese el ID del usuario para ver su username -> ");
     * int idUser = Int32.Parse(Console.ReadLine());
     */
    public void ListarUsername(int idUser)
    {
        bool encontrado = false;
        for (int i = 0; i < Usuarios.Count && encontrado == false; i++)
        {
            if (Usuarios[i].IdUsuario == idUser)
            {
                Console.WriteLine(Usuarios[i].Username + " ");
                encontrado = true;
            }
        }
    }

    /*
     * Console.Write("Ingrese el ID del usuario para ver la contraseña -> ");
     * int idUser = Int32.Parse(Console.ReadLine());
     */
    public void ListarPassword(int idUser)
    {
        bool encontrado = false;
        for (int i = 0; i < Usuarios.Count && encontrado == false; i++)
        {
            if (Usuarios[i].IdUsuario == idUser)
            {
                Console.WriteLine(Usuarios[i].Password + " ");
                encontrado = true;
            }
        }
    }

    /*
     * Console.Write("Ingrese el ID del usuario para recuperar su username -> ");
     * int idUser = Int32.Parse(Console.ReadLine());
     * Console.Write("Ingrese el Nuevo Username -> ");
     * string newusername = String.Parse(Console.ReadLine());
     */
    public void RecuperarUsername(int idUser, string newusername)
    {
        foreach (var usuario in Usuarios)
        {
            if (usuario.IdUsuario == idUser)
            {
                usuario.Username = newusername;
                Console.WriteLine("El usuario {0} se modifico correctamente.", usuario.Username);
            }
        }
    }

    public bool RecuperarUsernamePassword(string password)
    {
        bool isCorrectPass = false;
        foreach (var usuario in Usuarios)
        {
            if (usuario.Password == password)
            {
                if (usuario.Password == password && usuario.IdUsuario == usuario.IdUsuario)
                {
                    isCorrectPass = true;
                }
            }
        }
        return isCorrectPass;
    }
    
    public bool RecuperarPasswordUsername(string username)
    {
        bool isCorrectPass = false;
        foreach (var usuario in Usuarios)
        {
            if (usuario.Username == username)
            {
                if (usuario.Username == username && usuario.IdUsuario == usuario.IdUsuario)
                {
                    isCorrectPass = true;
                }
            }
        }
        return isCorrectPass;
    }

    public int ObtenerIDUserPass(string password)
    {
        int GetIDUser = 0;
        bool isSeEncontro = false;
        for (int i = 0; i < Usuarios.Count && isSeEncontro == false; i++)
        {
            if (Usuarios[i].Password == password)
            {
                GetIDUser = Usuarios[i].IdUsuario;
            }
        }

        return GetIDUser;
    }
    
    public int ObtenerIDUser(string username)
    {
        int GetIDUser = 0;
        bool isSeEncontro = false;
        for (int i = 0; i < Usuarios.Count && isSeEncontro == false; i++)
        {
            if (Usuarios[i].Username == username)
            {
                GetIDUser = Usuarios[i].IdUsuario;
                isSeEncontro = true;
            }
        }

        return GetIDUser;
    }
    
    /*
     * Console.Write("Ingrese el ID del usuario para recuperar su username -> ");
     * int idUser = Int32.Parse(Console.ReadLine());
     * Console.Write("Ingrese la Nueva Contraseña -> ");
     * string newpassword = String.Parse(Console.ReadLine());
     */
    public void RecuperarPassword(int idUser, string newpassword)
    {
        foreach (var usuario in Usuarios)
        {
            if (usuario.IdUsuario == idUser)
            {
                usuario.Password = newpassword;
                Console.WriteLine("Se modifico contraseñas correctamente.");
                Console.WriteLine("Username: {0}\n Nueva Contraseña: {1}", usuario.Username, usuario.Password);
            }
        }
    }

    public int ContarUsuarios()
    {
        int TotalUsuarios = 0;
        for (int i = 0; i < Usuarios.Count; i++)
        {
            TotalUsuarios++;
        }

        return TotalUsuarios;
    }
    
    /* Console.Write("Ingrese el ID del usuario -> ");
    * int idUser = Int32.Parse(Console.ReadLine());*/
    
    public int RegresaIDUser(int idUser)
    {
        int RetornaID = 0;
        for (int i = 0; i < Usuarios.Count; i++)
        {
            if (Usuarios[i].IdUsuario == idUser)
            {
                RetornaID = Usuarios[i].IdUsuario;
            }
        }
        return RetornaID;
    }

    /*
    * Console.Write("Ingrese el ID del Usuario a Modificar -> ");
    * int idUser = Int32.Parse(Console.ReadLine());
    * Console.Write("Ingrese el Nuevo Nombre -> ");
    * string nombre = String.Parse(Console.ReadLine());
    * Console.Write("Ingrese el Nuevo Apellido -> ");
    * string apellidos = String.Parse(Console.ReadLine());
    * Console.Write("Ingrese la Nueva Dirección -> ");
    * string direccion = String.Parse(Console.ReadLine());
    * Console.Write("Ingrese el Nuevo Telefono -> ");
    * int telefono = Int32.Parse(Console.ReadLine());
    */
    public void EditarUsuario(int idUser, string nombre, string apellidos, string direccion, int telefono)
    {
        foreach (var usuario in Usuarios)
        {
            if (usuario.IdUsuario == idUser)
            {
                usuario.Nombre = nombre;
                usuario.Apellidos = apellidos;
                usuario.Direccion = direccion;
                usuario.Telefono = telefono;

                Console.WriteLine("\nSe modifica el ID: " + idUser + " del usuario correctamente.\n");
            }
        }
    }

    /*
    * Console.Write("Ingrese el ID del Usuario a Modificar -> ");
    * int idUser = Int32.Parse(Console.ReadLine()); //// NO
    * 
    * Console.Write("Ingrese el Nombre -> ");
    * string nombre = String.Parse(Console.ReadLine());
    * Console.Write("Ingrese el Apellido -> ");
    * string apellidos = String.Parse(Console.ReadLine());
    * Console.Write("Ingrese el Username -> ");
    * string username = String.Parse(Console.ReadLine());
    * Console.Write("Ingrese la Contraseña -> ");
    * string password = String.Parse(Console.ReadLine());
    * Console.Write("Ingrese la Dirección -> ");
    * string direccion = String.Parse(Console.ReadLine());
    * Console.Write("Ingrese el Telefono -> ");
    * int telefono = Int32.Parse(Console.ReadLine());
    * 
    * Console.Write("Seleccione si es admin o usuario normal.");
    * Console.Write("1=>Admin -> ");
    * Console.Write("2=>Normal -> ");
    * Console.Write("Ingrese una opción -> ");
    * int permiso = Int32.Parse(Console.ReadLine());
    */
    public void AgregarUnUsuario(int idUser, string nombre, string apellidos, string username, string password,
        string direccion,
        bool permiso, int telefono)
    {
        Usuario nueva = new Usuario(idUser, nombre, apellidos, username, password, direccion,
            permiso, telefono);
        Usuarios.Add(nueva);
        Console.WriteLine("\nSe agrego el nuevo usuario correctamente.\n");
    }

    public bool IsLogin(string username, string password)
    {
        bool isLogin = false;
        for (int i = 0; i < Usuarios.Count && isLogin == false; i++)
        {
            if (Usuarios[i].Username.Equals(username))
            {
                if (Usuarios[i].Password.Equals(password))
                {
                    isLogin = true;
                    //break;
                }
            }
        }
        return isLogin;
    }

    public void OperacionesUsuario()
    {
        Boolean isSalirUser = true;

        while (isSalirUser)
        {
            Console.WriteLine("#####---######--> Menu Principal Usuarios <-- #####---######");
            Console.Write("\n\t1.Listar Todos los Usuarios.");
            Console.Write("\n\t2.Listar un Usuario.");
            Console.Write("\n\t3.Agregar un Nuevo Usuario.");
            Console.Write("\n\t4.Modificar un Usuario.");
            Console.Write("\n\t5.Modificar el Username.");
            Console.Write("\n\t6.Listar el Username.");
            Console.Write("\n\t7.Modificar la Contraseña.");
            Console.Write("\n\t8.Listar la Contraseña.");
            Console.Write("\n\t9.Eliminar un Usuario.");
            Console.Write("\n\t10.Consultar Permiso de un Usuario.");
            Console.Write("\n\t11.Modificar Permiso de un Usuario.");
            Console.Write("\n\t12.Desea Salir.?");
            Console.Write("\n\nIngrese el numero de la opción deseada: ");
            int opcionUser = Int32.Parse(Console.ReadLine());

            switch (opcionUser)
            {
                case 1:
                {
                    Console.WriteLine("\n#####---######--> Lista Todos los Usuarios <--#####---######.");
                    ListarUsuarios();
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("\n#####---######--> Listar Un Usuario <--#####---######.");
                    Console.Write("Ingrese el ID del usuario a listar -> ");
                    int idUser = Int32.Parse(Console.ReadLine());
                    ListarUnUsuario(idUser);
                    Console.ReadKey();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("\n#####---######--> Agregar Un Nuevo Usuario <--#####---######.");

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
                    
                    int totalIdUser = ContarUsuarios();
                    totalIdUser = totalIdUser + 1;

                    AgregarUnUsuario(totalIdUser, nombre, apellidos, username, password, direccion,
                        AgregarPermiso(permiso), telefono);
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("\n#####---######--> Modificar un Usuario <--#####---######.");

                    Console.Write("Ingrese el ID del Usuario a Modificar -> ");
                    int idUser = Int32.Parse(Console.ReadLine());
                    Console.Write("Ingrese el Nuevo Nombre -> ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el Nuevo Apellido -> ");
                    string apellidos = Console.ReadLine();
                    Console.Write("Ingrese la Nueva Dirección -> ");
                    string direccion = Console.ReadLine();
                    Console.Write("Ingrese el Nuevo Telefono -> ");
                    int telefono = Int32.Parse(Console.ReadLine());

                    EditarUsuario(idUser, nombre, apellidos, direccion, telefono);
                    Console.ReadKey();
                    break;
                }
                case 5:
                {
                    Console.WriteLine("\n#####---######--> Modificar el Username <--#####---######.");

                    Console.Write("Ingrese el ID del usuario para recuperar su username -> ");
                    int idUser = Int32.Parse(Console.ReadLine());
                    Console.Write("Ingrese el Nuevo Username -> ");
                    string newusername = Console.ReadLine();

                    RecuperarUsername(idUser, newusername);
                    Console.ReadKey();
                    break;
                }
                case 6:
                {
                    Console.WriteLine("\n#####---######--> Listar el Username <--#####---######.");

                    Console.Write("Ingrese el ID del usuario para ver su username -> ");
                    int idUser = Int32.Parse(Console.ReadLine());

                    ListarUsername(idUser);
                    Console.ReadKey();
                    break;
                }
                case 7:
                {
                    Console.WriteLine("\n#####---######--> Modificar la Contraseña <--#####---######.");

                    Console.Write("Ingrese el ID del usuario que desea recuperar la username -> ");
                    int idUser = Int32.Parse(Console.ReadLine());
                    Console.Write("Ingrese la Nueva Contraseña -> ");
                    string newpassword = Console.ReadLine();

                    RecuperarPassword(idUser, newpassword);
                    Console.ReadKey();
                    break;
                }
                case 8:
                {
                    Console.WriteLine("\n#####---######--> Listar la Contraseña <--#####---######.");


                    Console.Write("Ingrese el ID del usuario para ver la contraseña -> ");
                    int idUser = Int32.Parse(Console.ReadLine());

                    ListarPassword(idUser);
                    Console.ReadKey();
                    break;
                }
                case 9:
                {
                    Console.WriteLine("\n#####---######--> Eliminar un Usuario. <--#####---######.");


                    Console.Write("Ingrese el ID del usuario a eliminar -> ");
                    int idUser = Int32.Parse(Console.ReadLine());

                    EliminarUnUsuario(idUser);
                    Console.ReadKey();
                    break;
                }
                case 10:
                {
                    Console.WriteLine("\n#####---######--> Consultar Permiso de un Usuario. <--#####---######.");


                    Console.WriteLine("Ingrese el ID del Usuario que desea validar si tiene permisos de Administrador.");
                    Console.Write("ID Usuario ->: ");
                    int idUser = Int32.Parse(Console.ReadLine());


                    ConsultarPermiso(idUser);
                    Console.ReadKey();
                    break;
                }
                case 11:
                {
                    Console.WriteLine("\n#####---######--> Modificar Permiso de un Usuario. <--#####---######.");
                    
                    Console.Write("ID Usuario ->: ");
                    int idUser = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el Nuevo Permiso al Usuario.");
                    Console.WriteLine("1=>Admin -> ");
                    Console.WriteLine("2=>Normal -> ");
                    Console.Write("Ingrese una Seleccion -> ");
                    int permiso = Int32.Parse(Console.ReadLine());

                    ModificarPermiso(permiso, idUser);
                    Console.ReadKey();
                    break;
                }
                case 12:
                {
                    Console.Write("Saliste del Menu Usuarios Correctamente.\n");
                    isSalirUser = false;
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