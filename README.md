
# Parqueadero

Funcinamiento basico de registro de usuarios, carros etc.

## Para abrir y ejecutar una aplicación de consola en Visual Studio Code, puedes seguir estos pasos.

- 1 - Abre Visual Studio Code y selecciona Archivo > Abrir carpeta en el menú principal. Busca la carpeta donde se encuentra tu aplicación de consola y selecciónala.

- 2 - Abre el archivo Program.cs o el que contenga el método Main de tu aplicación. Si no tienes la extensión de C# instalada, Visual Studio Code te sugerirá que la instales. Haz clic en Instalar para agregar la extensión de C# a Visual Studio Code.

- 3 - La primera vez que editas un archivo .cs, Visual Studio Code te pide que agregues los recursos que faltan para compilar y depurar la aplicación. Haz clic en Sí; Visual Studio Code crea una carpeta .vscode con los archivos launch.json y tasks.json.

- 4 - Para ejecutar tu aplicación, presiona F5 o selecciona Ejecutar > Iniciar depuración en el menú. Visual Studio Code compilará y ejecutará tu aplicación en el terminal integrado.

- 5 - Para detener la ejecución, presiona Shift + F5 o selecciona Ejecutar > Detener depuración en el menú.
## Ejemplo de funcionamiento

- Cuando cuando se ejecuta el porgrama el Usuario es:

```console
Username: alfonso
Passwrod: 123456

Username: test
Passwrod: 123
```

```csharp
 public Usuario()
    {
        Usuarios = new List<Usuario>();

        Usuarios.Add(new Usuario(1, "Alfonso", "Gonzalez", "alfonso", "123456", "Cra 31 N 85 - 78", true, 31245678));
        Usuarios.Add(new Usuario(2, "Test", "Test", "test", "123", "Cra 21 N 58 - 88", false, 31245678));
    }
```

- Tambien puedes registrar tu usuario y realizar las prubas.

## Authors

- [@alpolo1991](https://github.com/alpolo1991)


## License

[MIT](https://choosealicense.com/licenses/mit/)


## Documentation

[Documentation](https://github.com/alpolo1991)
