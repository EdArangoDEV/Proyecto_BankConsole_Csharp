namespace BankConsole;

public class User
{
    private int Id { get; set; }
    private string Name { get; set; }
    private string Email { get; set; }
    private decimal Balance { get; set; }
    private DateTime RegisterDate { get; set; }

    // Constructores
    public User(){
        this.Balance = 1000;
    }

    public User(int Id, string Name, string Email, decimal Balance)
    {
        this.Id = Id;
        this.Name = Name;
        this.Email = Email;
        this.Balance = Balance;
        this.RegisterDate = DateTime.Now;
    }

    public void SetBalance(decimal Balance){
        if (Balance < 0)
            this.Balance = 0;
        else
            this.Balance = Balance;
    }

    // Metodo para mostrar datos
    public string ShowData(){
        return $"Nombre: {this.Name}, Correo: {this.Email}, Saldo: {this.Balance}, Fecha de Registro: {this.RegisterDate}.";
    }


}