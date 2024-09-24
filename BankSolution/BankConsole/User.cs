using Newtonsoft.Json;

namespace BankConsole;

public class User
{
    // para serializar propiedades privadas
    [JsonProperty]
    private int Id { get; set; }
    [JsonProperty]
    private string Name { get; set; }
    [JsonProperty]
    private string Email { get; set; }
    [JsonProperty]
    private decimal Balance { get; set; }
    [JsonProperty]
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
        SetBalance(Balance);
        this.RegisterDate = DateTime.Now;
    }

    public void SetBalance(decimal amount){
        decimal quantity = 0;

        if (amount > 0)
            quantity = amount;

        this.Balance += quantity;
    }

    // Metodo para mostrar datos
    public string ShowData(){
        return $"Nombre: {this.Name}, Correo: {this.Email}, Saldo: {this.Balance}, Fecha de Registro: {this.RegisterDate}.";
    }

    // Metodo sobrecargado
    public string ShowData(string initialMessage){
        return $"{initialMessage} -> Nombre: {this.Name}, Correo: {this.Email}, Saldo: {this.Balance}, Fecha de Registro: {this.RegisterDate}.";
    }

}