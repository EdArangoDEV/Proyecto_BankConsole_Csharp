using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using BankConsole;

//Client james = new Client(1,"James", "james@gmail.com", 4000, 'M');
//Console.WriteLine(james.ShowData());

//Employee pedro = new Employee(2,"pedro", "pedro@gmail.com", 4000, "IT");
//Console.WriteLine(pedro.ShowData());


// Storage.AddUser(james);
// Storage.AddUser(pedro);

// User pedro = new User(2,"Pedro","pedro@hotmail.com", 2500);
// Storage.AddUser(pedro);

// Console.WriteLine(pedro.ShowData());


if (args.Length == 0)
    EmailService.SendMail();
else
    ShowMenu();

static void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Menu opciones:");
    Console.WriteLine("1 - Crear un Usuario nuevo.");
    Console.WriteLine("2 - Eliminar un Usuario existente.");
    Console.WriteLine("3 - Salir.\n");
    Console.WriteLine("Seleccione una opción:");

    int option = 0;
    do
    {
        string input = Console.ReadLine();

        if (!int.TryParse(input, out option))
            Console.WriteLine("Debes ingresar un número (1, 2 o 3).");
        else if (option > 3) 
            Console.WriteLine("Debes ingresar un número válido (1, 2 o 3).");
    } while (option == 0 || option > 3);

    switch (option)
    {   
        case 1:
            CreateUser();
            break;
        case 2: 
            //DeleteUser();
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            Thread.Sleep(2000);
            Console.Clear();
            Environment.Exit(0);
            break;
    }
}    


static void CreateUser(){

    Console.Clear();
    Console.WriteLine("Ingresa la información del usuario:\n");

    Console.Write("ID: ");
    int Id = int.Parse(Console.ReadLine());

    Console.Write("Nombre: ");
    string name = Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    Console.Write("Saldo: ");
    decimal balance = decimal.Parse(Console.ReadLine());

    Console.Write("Escribe 'c' si el usuario es Cliente o 'e' si el usuario es empleado; ");
    char userType = char.Parse(Console.ReadLine());

    User newUser;

    if (userType.Equals('c'))
    {
        Console.Write("Escribe el regimen Fiscal:");
        char taxRegime = char.Parse(Console.ReadLine());

        newUser = new Client(Id, name, email, balance, taxRegime);
    }
    else
    {
        Console.Write("Escribe el Departamento");
        string department = Console.ReadLine();

        newUser = new Employee(Id, name, email, balance, department);
    }

    Storage.AddUser(newUser);

    Console.WriteLine("Usuario creado...");
    Thread.Sleep(2000);
    ShowMenu();
}



