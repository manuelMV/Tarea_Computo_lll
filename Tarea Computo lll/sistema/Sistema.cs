using Usuario;
namespace Sistema
{
    interface IBaseDeDatos
    {
        public void verCliente();
        public void agregarCliente(Cliente cliente);
        public void eliminarCliente(Cliente cliente);
    }
    class SQLite : IBaseDeDatos
    {
        private List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente("Carlos","Melendez",18,"manuelmv15","1234") ,
            new Cliente("juan","zanches",35,"admin","1234",true),
         new Cliente("Mar�a", "L�pez", 25, "marialpz", "5678"),
         new Cliente("Juan", "P�rez", 30, "juan123", "abcd"),
         new Cliente("Luis", "Garc�a", 22, "luisgarcia", "efgh"),
         new Cliente("Ana", "Rodr�guez", 28, "anarodriguez", "ijkl"),
         new Cliente("Pedro", "G�mez", 35, "pedrogomez", "mnop"),
         new Cliente("Laura", "Mart�nez", 40, "lauramtz", "qrst"),
         new Cliente("Sof�a", "Hern�ndez", 27, "sofiahernandez", "uvwxyz"),
         new Cliente("Diego", "S�nchez", 33, "diegosanchez", "1111"),
         new Cliente("Isabella", "D�az", 19, "isabelladiaz", "2222"),
         new Cliente("Isabella", "D�az", 19, "2", "2"),

        };



        public void mostrarMenuEjecutivo()
        {
            int clienteEjecutivo = 0;
            string user = "", pass = "";
            int indice = 1;
            int menu = 0;
            bool acceso = false;
            Console.Clear();
            Console.WriteLine("Inicie sesi�n.");
            Thread.Sleep(500);

            Console.Write("Ingrese el usuario: ");
            user = Console.ReadLine();

            Console.Write("Ingrese la contrase�a: ");
            pass = Console.ReadLine();
           
            Console.Clear();
            Console.WriteLine("Buscando ...");
            Thread.Sleep(1000);
            Console.Clear();

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].clienteEjecutivo)
                {
                    clienteEjecutivo = i;
                    acceso = clientes[i].inicioDesecion(pass, user);
                }
            }
            if (acceso)
            {
                Console.WriteLine("Usuario encontrado");
                Thread.Sleep(1000);

                do
                {
                    Console.Clear();

                    Console.WriteLine("Menu de cliente ejecutivo\n1. Ver clientes\n2. Agregar clientes\n3. Eliminar clientes\n4. Salir");
                    menu = num_rango(1, 4);

                    switch (menu)
                    {
                        case 1: verCliente();Console.ReadKey(); break;
                        
                        case 2:
                            indice = clientes.Count - 1;
                            agregarCliente(clientes[indice]); break;
                      
                        case 3:
                            eliminarCliente(clientes[indice]);
                            break;
                    }
                } while (menu != 4);
            }
            else { Console.WriteLine("Usuario no encontrado"); }
            Console.Clear();
        }


        public void mostrarMenu()
        {
            string user = "", pass = "";
            int menu = 0;
            bool usuario = false;
            Console.Clear();
            Thread.Sleep(500);

            do
            {
                Console.WriteLine("Menu cliente normal\n1. Mostrar datos \n2. salir");
                menu = num_rango(1, 2);

                if (menu == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Inicie sesi�n.");
                    Thread.Sleep(500);

                    Console.Write("Ingrese el usuario: ");
                    user = Console.ReadLine();

                    Console.Write("Ingrese la contrase�a: ");
                    pass = Console.ReadLine();

                    Console.Clear();

                    Console.WriteLine("Buscando ...");
                    Thread.Sleep(1000);
                    Console.Clear();

                    for (int i = 0; i < clientes.Count; i++)
                    {
                        if (clientes[i].iniciodesecion(user, pass))
                        {
                            usuario = true;
                            Console.WriteLine("Usuario encontrado");
                            Thread.Sleep(1000);
                            Console.Clear();
                            
                            clientes[i].mostrardatos(0);
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    if (!usuario)
                    {
                        Console.WriteLine("Usuario no encontrado");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
            } while (menu != 2);
        }




        public void verCliente()
        {
            Console.WriteLine("Lista de clientes registrados:");
            for (int i = 0; i < clientes.Count; i++)
            {clientes[i].mostrardatos(i);}
        }


        public void agregarCliente(Cliente cliente)
        {
            Console.WriteLine("Ingrese el nombre del cliente:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del cliente:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del cliente:");
            int edad = num_po();

            Console.WriteLine("Ingrese el nombre de usuario del cliente:");
            string usuario = Console.ReadLine();

            Console.WriteLine("Ingrese la contrase�a del cliente:");
            string contrase�a = Console.ReadLine();

            clientes.Add(new Cliente(nombre, apellido, edad, usuario, contrase�a));
            Console.Clear();

            Console.WriteLine("Tarea realizada con �xito.");
            Thread.Sleep(1000);
            Console.Clear();
        }


        public void eliminarCliente(Cliente cliente)
        {
            int i = 0;
            verCliente();
            Console.WriteLine("Ingrese el �ndice del cliente a eliminar");
            i = num_rango(1, clientes.Count);

            clientes.Remove(clientes[i - 1]);
            Console.Clear();

            Console.WriteLine("Tarea realizada con �xito.");
            Thread.Sleep(1000);
            Console.Clear();

        }


        static int num_po()
        {
            int numero;

            do
            {
                Console.Write("Ingrese la edad: ");

            } while (!int.TryParse(Console.ReadLine(), out numero) || !Numero_Po(numero));
            return numero;
            static bool Numero_Po(int numero)
            {
                return numero > 0;
            }

        }


        static int num_rango(int num_min, int num_max)
        {

            int numero;

            do
            {

                Console.Write($"\nIngresa un n�mero entre {num_min} y {num_max}: ");

            } while (!int.TryParse(Console.ReadLine(), out numero) || !Numero_ran(numero, num_min, num_max));
            return numero;

            static bool Numero_ran(int numero, int num_min, int num_max)
            {
                if (numero >= num_min)
                {
                    if (numero <= num_max)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;

            }
        }
    }
}