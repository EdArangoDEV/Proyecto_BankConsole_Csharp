using BankConsole;

User james = new User(1,"James", "james@gmail.com", 4000);
james.SetBalance(100);

Console.WriteLine(james.ShowData("La informacion del usuario es la siguiente"));

Storage.AddUser(james);

User pedro = new User(2,"Pedro","pedro@hotmail.com", 2500);
Storage.AddUser(pedro);

//Console.WriteLine(pedro.ShowData());




