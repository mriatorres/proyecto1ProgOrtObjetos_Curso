using System;

class Programa
{
    static string[,] datosAdministrador = { { "Andreni", "admin123", "Administrador" } }; // Matriz para almacenar los datos del administrador, contiene una fila con 3 columnas: usuario, contraseña y rol.
    static string[,] datosCajeros = new string[15, 3]; // Matriz ara almacenar los datos de hasta 15 cajeros, tiene 15 filas (cajeros) y 3 columnas (usuario, contraseña y rol).
    static string[,] datosConductores = new string[15, 1]; // Matriz ara almacenar los datos de hasta 15 conductores, tiene 15 filas (cajeros) y 1 columnas (usuario).
    static int contadorCajeros = 2; // Variables contadoras que mantienen el número actual de cajeros, conductores y rutas.
    static int contadorConductores = 2;
    static int contadorRutas = 2;
    static string[,] rutas = new string[10, 2]; // Matriz para almacenar las rutas creadas, tiene dos columnas para el nombre de la ruta y otra para la direccion por si se quiere implementar 
    static string[,] rutasConductor = new string[15, 2]; // Matriz para almacenar las rutas asignadas a los conductores, tiene 15 filas (uno por cada conductor) y 2 columnas (nombre de la ruta y conductor).

    static void Main(string[] args)
    {

        // Se inicializan los datos de los dos primeros cajeros.
        datosCajeros[0, 0] = "Rafael"; // Usuario del primer cajero
        datosCajeros[0, 1] = "rafael123";   // Contraseña del primer cajero
        datosCajeros[0, 2] = "Cajero";  // Rol del primer cajero

        datosCajeros[1, 0] = "Sandra"; // Usuario del segundo cajero
        datosCajeros[1, 1] = "sandra123";   // Contraseña del segundo cajero
        datosCajeros[1, 2] = "Cajero";  // Rol del segundo cajero

        // Se inicializan los datos de los dos primeros conductores.
        datosConductores[0, 0] = "John"; // Usuario del primer conductor
        datosConductores[1, 0] = "Oswaldo"; // Usuario del segundo conductor


        // Se inicializan los nombres de las dos primeras rutas.
        rutas[0, 0] = "Homecenter"; // Nombre de la primera ruta
        rutas[1, 0] = "IKEA"; // Nombre de la segunda ruta

        // Autenticación del usuario y mostrar el menú correspondiente según el rol.
        if (AutenticarUsuario())
        {
            // Si el rol es "Administrador", se muestra el menú de administrador.
            if (datosAdministrador[0, 2] == "Administrador")
                MostrarMenuAdministrador();
            else
                // Si no es administrador, muestra el menú de cajero.
                MostrarMenuCajero();
        }
    }

    static bool AutenticarUsuario() // Método para autenticar al usuario ingresando su usuario, contraseña y rol.
    {

        int intentos = 3; // Número máximo de intentos permitidos para autenticarse.

        for (int i = 0; i < intentos; i++)  // Ciclo For para permitir al usuario varios intentos de autenticación.
        {
            Console.Write("Ingrese su usuario: "); // Solicita al usuario que ingrese su nombre de usuario.
            string usuario = Console.ReadLine();

            Console.Write("Ingrese su contraseña: ");  // Solicita al usuario que ingrese su contraseña.
            string contraseña = Console.ReadLine();

            Console.Write("Ingrese su rol (Administrador/Cajero): ");  // Solicita al usuario que ingrese su rol (Administrador o Cajero).
            string rol = Console.ReadLine();

            if (usuario == datosAdministrador[0, 0] && contraseña == datosAdministrador[0, 1] && rol.Equals(datosAdministrador[0, 2], StringComparison.OrdinalIgnoreCase)) // Condicional If para autenticar al admin comparando los datos ingresados 
            {
                Console.WriteLine($"Bienvenido {usuario}, Rol: {rol}");
                return true; // La autenticación fue exitosa para el administrador.
            }

            for (int j = 0; j < contadorCajeros; j++) // Ciclo For para la autenticacion de cajeros (mirar si es un cajero registrado) 
            {
                if (usuario == datosCajeros[j, 0] && contraseña == datosCajeros[j, 1] && rol.Equals(datosCajeros[j, 2], StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Bienvenido {usuario}, Rol: {rol}");
                    MostrarMenuCajero();  // Muestra el menú de cajero, ya que es un usuario cajero autenticado.
                    return false; // Finaliza la autenticación con éxito para el cajero.
                }
            }
            Console.WriteLine("Datos incorrectos. Intente nuevamente.");  // Mensaje de error si los datos ingresados no coinciden con ningún usuario registrado.
        }
        Console.WriteLine("Se ha excedido el número de intentos. Contacte a soporte técnico."); // Mensaje de error cuando se excede el número de intentos de autenticación.
        return false; // La autenticación ha fallado después de todos los intentos permitidos.
    }

    static void MostrarMenuCajero() // Método para mostrar el menú del cajero y ejecutar las opciones seleccionadas.
    {
        bool salir = false; // Variable booleana para controlar el ciclo del menú. Inicialmente se establece en false para entrar al ciclo.

        while (!salir)  // Ciclo While ya que se repite hasta que el usuario decida salir.
        {
            // Imprime el encabezado y las opciones del menú de cajero.
            Console.WriteLine("\n--- Menú Cajero ---");
            Console.WriteLine("1. Gestión de cuenta cajero");
            Console.WriteLine("2. Gestión de rutas");
            Console.WriteLine("3. Realizar venta");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");  // Solicita al usuario que seleccione una opción.
            string opcion = Console.ReadLine();


            switch (opcion) // Evalúa la opción ingresada por el usuario por mediode un switch y casos para llevar al usuario a donde solicitó
            {
                case "1":  // Opción 1: Ejecuta el método para gestionar la cuenta del cajero.
                    GestionarCuentaCajero();
                    break;
                case "2": // Opción 2: Ejecuta el método para gestionar las rutas.
                    GestionarRutas();
                    break;
                case "3": // Opción 3: Ejecuta el método para realizar una venta.
                    RealizarVenta();
                    break;
                case "4": // Opción 4: Cambia la variable `salir` a true para terminar el bucle y salir del menú.
                    salir = true;
                    Console.WriteLine("Saliendo del menú de Cajero...");
                    break;
                default: // Opción predeterminada en caso de que el usuario ingrese una opción inválida.
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }

    static void GestionarCuentaCajero()  // Método para gestionar la cuenta del cajero, permitiendo actualizar el usuario y la contraseña.
    {
        Console.WriteLine("\n--- Gestión cuenta cajero ---");  // Muestra el título de la sección.

        Console.Write("Ingrese el nuevo usuario: ");  // Solicita el nuevo nombre de usuario para el cajero.
        string nuevoUsuario = Console.ReadLine();

        Console.Write("Ingrese la nueva contraseña: ");  // Solicita la nueva contraseña para el cajero.
        string nuevaContraseña = Console.ReadLine();

        // Actualiza los datos del primer cajero en la matriz `datosCajeros`.
        datosCajeros[0, 0] = nuevoUsuario;    // Guarda el nuevo usuario en la posición correspondiente.
        datosCajeros[0, 1] = nuevaContraseña; // Guarda la nueva contraseña en la posición correspondiente.

        Console.WriteLine("Cuenta del cajero actualizada correctamente."); // Confirma que la cuenta del cajero se ha actualizado correctamente.
    }


    static void GestionarRutas() // Método para gestionar las rutas, con opciones para crear, editar, ver y asignar rutas.
    {
        bool salir = false; // Variable booleana para controlar el ciclo del menú de rutas.

        while (!salir) // Ciclo While para que se repita hasta que el usuario decida salir.
        {
            // Muestra el título y las opciones del menú de gestión de rutas.
            Console.WriteLine("\n--- Gestión de Rutas ---");
            Console.WriteLine("1. Crear ruta");
            Console.WriteLine("2. Editar ruta");
            Console.WriteLine("3. Ver lista de rutas");
            Console.WriteLine("4. Asignar ruta a conductor");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: "); // Solicita al usuario que seleccione una opción del menú.
            string opcion = Console.ReadLine();

            switch (opcion) // Evalúa la opción ingresada por el usuario y ejecuta la acción correspondiente haciendo uso de un switch y casos
            {
                case "1": // Opción 1: Ejecuta el método para crear una nueva ruta.
                    CrearRuta();
                    break;
                case "2": // Opción 2: Ejecuta el método para editar una ruta existente.
                    EditarRuta();
                    break;
                case "3": // Opción 3: Ejecuta el método para ver la lista de rutas.
                    VerListaRutas();
                    break;
                case "4": // Opción 4: Ejecuta el método para asignar una ruta a un conductor.
                    AsignarRutaConductor();
                    break;
                case "5": // Opción 5: Cambia la variable `salir` a true para terminar el bucle y salir del menú de rutas.
                    salir = true;
                    Console.WriteLine("Saliendo del menú de rutas...");
                    break;
                default: // Opción predeterminada en caso de que el usuario ingrese una opción inválida.
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }

    static void CrearRuta() // Método para crear una nueva ruta en el sistema.
    {
        if (contadorRutas >= 10) // Verifica si ya se ha alcanzado el límite máximo de rutas (10) usando condicional If
        {
            Console.WriteLine("No se pueden agregar más rutas.");
            return; // Sale del método si el límite se ha alcanzado.
        }

        Console.Write("Ingrese el nombre de la ruta: "); // Solicita al usuario ingresar el nombre de la nueva ruta.
        string nombreRuta = Console.ReadLine();
        rutas[contadorRutas, 0] = nombreRuta; // Guarda el nombre de la ruta en la matriz `rutas` en la posición de `contadorRutas`.

        Console.WriteLine("Ruta creada correctamente."); // Confirma que la ruta fue creada exitosamente.
        contadorRutas++;  // Incrementa el contador de rutas.      
    }

    static void EditarRuta() // Método para editar el nombre de una ruta existente.
    {
        Console.Write("Ingrese el número de la ruta a editar: ");  // Solicita el número de la ruta que se desea editar.
        int numRuta = int.Parse(Console.ReadLine()) - 1; // Convierte la entrada a índice de matriz (base 0).

        if (numRuta >= 0 && numRuta < contadorRutas) // Verifica si el número de ruta ingresado está dentro del rango actual de rutas, utilizando condicionales If y Else 
        {
            Console.Write("Ingrese el nuevo nombre de la ruta: "); // Solicita el nuevo nombre para la ruta seleccionada.
            rutas[numRuta, 0] = Console.ReadLine(); // Actualiza el nombre de la ruta.

            Console.WriteLine("Ruta editada correctamente."); // Confirma que la ruta ha sido editada correctamente.
        }
        else
        {
            Console.WriteLine("Número de ruta no válido."); // Mensaje de error si el número de ruta es inválido.
        }
    }
    static void VerListaRutas()  // Método para mostrar la lista de todas las rutas creadas.
    {
        Console.WriteLine("\n--- Lista de Rutas ---");  // Imprime el título de la sección de rutas.

        for (int i = 0; i < contadorRutas; i++)  // Recorre la lista de rutas existentes y las muestra en la consola usando ciclo For 
        {
            Console.WriteLine($"Ruta {i + 1}: {rutas[i, 0]}"); // Muestra el número y el nombre de la ruta.
        }
    }
    static void AsignarRutaConductor() // Método para asignar una ruta específica a un conductor.
    {
        Console.Write("Ingrese el número de la ruta a asignar: "); // Solicita el número de la ruta que se desea asignar a un conductor.
        int numRuta = int.Parse(Console.ReadLine()) - 1; // Convierte la entrada a índice de matriz (base 0).

        Console.Write("Ingrese el nombre del conductor: ");  // Solicita el nombre del conductor al cual se asignará la ruta.
        rutas[numRuta, 1] = Console.ReadLine(); // Almacena el nombre del conductor en la columna correspondiente.

        Console.WriteLine("Ruta asignada al conductor correctamente."); // Confirma que la ruta ha sido asignada al conductor correctamente.
    }

    static void RealizarVenta()  // Método para realizar una venta de tiquetes.
    {

        Console.Write("\nIngrese el nombre del comprador: ");  // Solicita el nombre del comprador.
        string nombreComprador = Console.ReadLine();

        Console.Write("Seleccione el número de la ruta: "); // Solicita el número de la ruta en la que se realizará la venta.
        int numRuta = int.Parse(Console.ReadLine()) - 1; // Convierte la entrada a índice de matriz (base 0).

        Console.Write("Ingrese la cantidad de tiquetes: "); // Solicita la cantidad de tiquetes que se desean comprar.
        int cantidadTiquetes = int.Parse(Console.ReadLine());

        Console.WriteLine($"Venta realizada a {nombreComprador} en la ruta {rutas[numRuta, 0]} con {cantidadTiquetes} tiquetes."); // Muestra la confirmación de la venta con los detalles del comprador, la ruta y la cantidad de tiquetes.
    }
    static void MostrarMenuAdministrador()   // Método para mostrar el menú de opciones del administrador.
    {
        bool salir = false; // Variable booleana para controlar el ciclo del menú de administración.

        while (!salir)   // Ciclo While para que se repita hasta que el administrador decida salir.
        {
            // Muestra el título y las opciones del menú de administración.
            Console.WriteLine("\n--- Menú Administración ---");
            Console.WriteLine("1. Gestión de cuenta administrador");
            Console.WriteLine("2. Gestión de cajeros");
            Console.WriteLine("3. Gestión de conductores");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");  // Solicita al administrador que seleccione una opción del menú
            string opcion = Console.ReadLine();

            switch (opcion) // Evalúa la opción ingresada y ejecuta la acción correspondiente haciendo uso de un switch y casos
            {
                case "1":  // Opción 1: Ejecuta el método para gestionar la cuenta del administrador.
                    GestionarCuentaAdministrador();
                    break;
                case "2": // Opción 2: Ejecuta el método para gestionar los cajeros.
                    GestionarCajeros();
                    break;
                case "3":  // Opción 3: Ejecuta el método para gestionar los conductores.
                    GestionarConductores();
                    break;
                case "4": // Opción 4: Cambia la variable `salir` a true para terminar el bucle y salir del menú de administración.
                    Console.WriteLine("Saliendo del menú de Administrador...");
                    salir = true;
                    break;
                default: // Opción predeterminada en caso de que el usuario ingrese una opción inválida.
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }
    static void GestionarCuentaAdministrador()  // Método para actualizar los datos de la cuenta del administrador.
    {
        Console.WriteLine("\n--- Gestión cuenta administrador ---"); // Muestra el título de la sección de gestión de cuenta del administrador.

        Console.Write("Ingrese el nuevo usuario: ");  // Solicita el nuevo nombre de usuario para el administrador y lo actualiza en "datosAdministrador".
        datosAdministrador[0, 0] = Console.ReadLine();

        Console.Write("Ingrese la nueva contraseña: "); // Solicita la nueva contraseña para el administrador y la actualiza en "datosAdministrador".
        datosAdministrador[0, 1] = Console.ReadLine();

        Console.WriteLine("Cuenta del administrador actualizada correctamente."); // Confirma que la cuenta del administrador ha sido actualizada correctamente.
    }
    static void GestionarCajeros()  // Método para gestionar la información de los cajeros.
    {
        bool salir = false;  // Variable booleana para controlar el ciclo del menú de gestión de cajeros.

        while (!salir) // Ciclo While que se repite hasta que el usuario decida salir.
        {
            // Muestra el título y las opciones del menú de gestión de cajeros.
            Console.WriteLine("\n--- Gestión de Cajeros ---");
            Console.WriteLine("1. Crear cajero");
            Console.WriteLine("2. Editar cajero");
            Console.WriteLine("3. Ver lista de cajeros");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: "); // Solicita al usuario seleccionar una opción del menú.
            string opcion = Console.ReadLine();

            switch (opcion) // Evalúa la opción ingresada y ejecuta la acción correspondiente haciendo uso de un switch y casos
            {
                case "1": // Opción 1: Ejecuta el método para agregar un nuevo cajero.
                    AgregarCajero();
                    break;
                case "2": // Opción 2: Ejecuta el método para editar la información de un cajero existente.
                    EditarCajero();
                    break;
                case "3": // Opción 2: Ejecuta el método para editar la información de un cajero existente.
                    VerCajeros();
                    break;
                case "4": // Opción 4: Cambia la variable `salir` a true para terminar el bucle y salir del menú de cajeros.
                    salir = true;
                    break;
                default: // Opción predeterminada en caso de que el usuario ingrese una opción inválida.
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }
    static void GestionarConductores() // Método para gestionar la información de los conductores.
    {
        bool salir = false; // Variable booleana para controlar el ciclo del menú de gestión de conductores.

        while (!salir) // Bucle que se repite hasta que el usuario decida salir.
        {
            // Muestra el título y las opciones del menú de gestión de conductores.
            Console.WriteLine("\n--- Gestión de Conductores ---");
            Console.WriteLine("1. Crear conductor");
            Console.WriteLine("2. Editar conductor");
            Console.WriteLine("3. Asignar ruta a conductor");
            Console.WriteLine("4. Ver lista de rutas de un conductor");
            Console.WriteLine("5. Ver lista de conductores");
            Console.WriteLine("6. Salir");

            Console.Write("Seleccione una opción: "); // Solicita al usuario seleccionar una opción del menú.
            string opcion = Console.ReadLine();

            switch (opcion)  // Evalúa la opción ingresada y ejecuta la acción correspondiente por medio de un switch y casos
            {
                case "1":  // Opción 1: Ejecuta el método para agregar un nuevo conductor.
                    AgregarConductor();
                    break;
                case "2": // Opción 2: Ejecuta el método para editar la información de un conductor existente.
                    EditarConductor();
                    break;
                case "3":  // Opción 3: Ejecuta el método para asignar una ruta a un conductor.
                    AsignarRutaAConductor();
                    break;
                case "4":  // Opción 3: Ejecuta el método para asignar una ruta a un conductor.
                    VerRutasDeConductor();
                    break;
                case "5":  // Opción 5: Ejecuta el método para ver la lista de todos los conductores.
                    VerConductores();
                    break;
                case "6":  // Opción 6: Cambia la variable `salir` a true para terminar el bucle y salir del menú de conductores.
                    salir = true;
                    break;
                default: // Opción predeterminada en caso de que el usuario ingrese una opción inválida.
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }
    static void AgregarCajero()  // Método para agregar un nuevo cajero al sistema.
    {
        if (contadorCajeros >= 15)  // Verifica si se ha alcanzado el límite de cajeros permitidos (15).
        {
            Console.WriteLine("No se pueden agregar más cajeros.");
            return; // Sale del método si no se pueden agregar más cajeros.
        }

        Console.Write("Ingrese el nombre de usuario del cajero: "); // Solicita el nombre de usuario y la contraseña del nuevo cajero.
        string usuario = Console.ReadLine();

        Console.Write("Ingrese la contraseña del cajero: ");
        string contraseña = Console.ReadLine();

        datosCajeros[contadorCajeros, 0] = usuario;  // Almacena los datos ingresados en la matriz "datosCajeros".
        datosCajeros[contadorCajeros, 1] = contraseña;
        datosCajeros[contadorCajeros, 2] = "Cajero";
        contadorCajeros++; // Incrementa el contador de cajeros.

        Console.WriteLine("Cajero agregado correctamente.");
    }


    static void EditarCajero() // Método para editar los datos de un cajero existente.
    {
        Console.Write("Ingrese el número del cajero a editar: "); // Método para editar los datos de un cajero existente.
        int num = int.Parse(Console.ReadLine()) - 1; // Convierte la entrada a índice de matriz (base 0).


        if (num >= 0 && num < contadorCajeros) // Verifica si el número de cajero ingresado es válido.
        {
            Console.Write("Ingrese el nuevo nombre de usuario del cajero: "); // Solicita el nuevo nombre de usuario y la nueva contraseña del cajero.
            datosCajeros[num, 0] = Console.ReadLine();

            Console.Write("Ingrese la nueva contraseña del cajero: ");
            datosCajeros[num, 1] = Console.ReadLine();

            Console.WriteLine("Cajero editado correctamente.");
        }
        else
        {
            Console.WriteLine("Número de cajero no válido.");
        }
    }

    static void VerCajeros()  // Método para mostrar la lista de todos los cajeros.
    {
        Console.WriteLine("\n--- Lista de Cajeros ---");

        for (int i = 0; i < contadorCajeros; i++) // Recorre la matriz `datosCajeros` y muestra el nombre de usuario de cada cajero.
        {
            Console.WriteLine($"Cajero {i + 1}: {datosCajeros[i, 0]}");
        }
    }
    static void AgregarConductor() // Recorre la matriz `datosCajeros` y muestra el nombre de usuario de cada cajero.
    {

        if (contadorConductores >= 15)   // Verifica si se ha alcanzado el límite de conductores permitidos (15).
        {
            Console.WriteLine("No se pueden agregar más conductores.");
            return; // Sale del método si no se pueden agregar más conductores.
        }

        Console.Write("Ingrese el nombre de usuario del conductor: "); // Solicita el nombre de usuario  del nuevo conductor.
        string usuario = Console.ReadLine();


        // Almacena los datos ingresados en la matriz `datosConductores`.
        datosConductores[contadorConductores, 0] = usuario;
        contadorConductores++; // Incrementa el contador de conductores.

        Console.WriteLine("Conductor agregado correctamente.");
    }

    static void EditarConductor() // Método para editar la información de un conductor.
    {
        Console.Write("Ingrese el número del conductor a editar: ");  // Solicita al usuario el número del conductor que se desea editar.       
        int num = int.Parse(Console.ReadLine()) - 1; // Lee la entrada del usuario, la convierte a entero y resta 1 para ajustar el índice (comienza en 0).

        if (num >= 0 && num < contadorConductores)  // Verifica si el número ingresado es válido (dentro del rango de conductores existentes).
        {
            Console.Write("Ingrese el nuevo nombre de usuario del conductor: ");  // Solicita el nuevo nombre de usuario para el conductor.
            datosConductores[num, 0] = Console.ReadLine();  // Actualiza el nombre del conductor en el arreglo de datos.

            Console.WriteLine("Conductor editado correctamente."); // Confirma que la edición fue exitosa.
        }
        else
        {
            Console.WriteLine("Número de conductor no válido."); // Mensaje de error si el número del conductor no es válido.
        }
    }
    static void AsignarRutaAConductor() // Método estático para asignar una ruta a un conductor.
    {

        Console.Write("Ingrese el número de la ruta a asignar: ");  // Solicita al usuario el número de la ruta que se desea asignar.        
        int numRuta = int.Parse(Console.ReadLine()) - 1; // Lee la entrada del usuario, la convierte a entero y ajusta el índice.

        if (numRuta < 0 || numRuta >= contadorRutas) // Verifica si el número de la ruta ingresado es válido.
        {
            Console.WriteLine("Número de ruta no válido."); // Mensaje de error si el número de ruta no es válido.
            return; // Sale del método si la ruta no es válida.
        }
        Console.Write("Ingrese el nombre del conductor: ");   // Solicita el nombre del conductor al que se le asignará la ruta.
        string nombreConductor = Console.ReadLine();

        bool conductorExiste = false; // Verifica si el conductor existe en el sistema.

        for (int i = 0; i < contadorConductores; i++) // Recorre el arreglo de conductores para buscar el nombre ingresado.
        {
            if (datosConductores[i, 0] == nombreConductor) // Si se encuentra el conductor, se establece la variable a true y se rompe el ciclo.
            {
                conductorExiste = true;
                break;
            }
        }
        if (!conductorExiste) // Si el conductor no existe, se muestra un mensaje y se sale del método.
        {
            Console.WriteLine("Conductor no encontrado.");
            return;
        }
        // Asigna la ruta al conductor encontrado.
        rutasConductor[numRuta, 0] = rutas[numRuta, 0]; // Asigna el nombre de la ruta.
        rutasConductor[numRuta, 1] = nombreConductor;   // Asigna el nombre del conductor.

        Console.WriteLine($"Ruta {rutas[numRuta, 0]} asignada al conductor {nombreConductor} correctamente."); // Confirma que la ruta fue asignada correctamente.
    }
    static void VerRutasDeConductor()  // Método para ver las rutas asignadas a un conductor.
    {
        Console.Write("Ingrese el nombre del conductor: "); // Solicita al usuario el nombre del conductor.
        string nombreConductor = Console.ReadLine();

        Console.WriteLine($"\n--- Rutas asignadas al conductor {nombreConductor} ---"); // Muestra un encabezado para las rutas asignadas.
        bool rutasAsignadas = false; // Booleano para verificar si se encontraron rutas.

        for (int i = 0; i < contadorRutas; i++) // Recorre el arreglo de rutas para verificar si hay rutas asignadas al conductor.
        {

            if (rutasConductor[i, 1] == nombreConductor)  // Si la ruta pertenece al conductor, se muestra la ruta.
            {
                Console.WriteLine($"Ruta {i + 1}: {rutasConductor[i, 0]}");
                rutasAsignadas = true; // Se ha encontrado al menos una ruta.
            }
        }
        if (!rutasAsignadas) // Si no se encontraron rutas asignadas, se muestra un mensaje correspondiente.
        {
            Console.WriteLine("No se encontraron rutas asignadas para este conductor.");
        }
    }
    static void VerConductores() // Método estático para ver la lista de conductores.
    {

        Console.WriteLine("\n--- Lista de Conductores ---"); // Muestra un encabezado para la lista de conductores.       
        for (int i = 0; i < contadorConductores; i++) // Recorre el arreglo de conductores y muestra cada uno.
        {
            Console.WriteLine($"Conductor {i + 1}: {datosConductores[i, 0]}");
        }
    }
}