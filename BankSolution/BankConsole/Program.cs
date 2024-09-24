using BankConsole;

Client james = new Client(1,"James", "james@gmail.com", 4000, 'M');
james.SetBalance(2000);

Console.WriteLine(james.ShowData());

Employee pedro = new Employee(2,"pedro", "pedro@gmail.com", 4000, "IT");
pedro.SetBalance(2000);

Console.WriteLine(pedro.ShowData());


// Storage.AddUser(james);

// User pedro = new User(2,"Pedro","pedro@hotmail.com", 2500);
// Storage.AddUser(pedro);

// Console.WriteLine(pedro.ShowData());




