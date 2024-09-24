using BankConsole;

Client james = new Client(1,"James", "james@gmail.com", 4000, 'M');
//Console.WriteLine(james.ShowData());

Employee pedro = new Employee(2,"pedro", "pedro@gmail.com", 4000, "IT");
//Console.WriteLine(pedro.ShowData());


Storage.AddUser(james);
Storage.AddUser(pedro);

// User pedro = new User(2,"Pedro","pedro@hotmail.com", 2500);
// Storage.AddUser(pedro);

// Console.WriteLine(pedro.ShowData());




