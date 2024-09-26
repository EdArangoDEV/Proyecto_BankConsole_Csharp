using Newtonsoft.Json;

namespace BankConsole;

public class User 
{
    // para serializar propiedades privadas
    [JsonProperty]
    protected int Id { get; set; }
    [JsonProperty]
    protected string Name { get; set; }
    [JsonProperty]
    protected string Email { get; set; }
    [JsonProperty]
    protected decimal Balance { get; set; }
    [JsonProperty]
    protected DateTime RegisterDate { get; set; }

    // Constructores
    public User() {}

    public User(int Id, string Name, string Email, decimal Balance)
    {
        this.Id = Id;
        this.Name = Name;
        this.Email = Email;
        this.RegisterDate = DateTime.Now;
    }

    public int GetId(){
        return this.Id;
    }

    public DateTime GetRegisterDate(){
        return this.RegisterDate;
    }

    public virtual void SetBalance(decimal amount){
        decimal quantity = 0;

        if (amount > 0)
            quantity = amount;

        this.Balance += quantity;
    }

    // Metodo para mostrar datos
    public virtual string ShowData(){
        return $"ID: {this.Id}, Nombre: {this.Name}, Correo: {this.Email}, Saldo: {this.Balance}, Fecha de Registro: {this.RegisterDate.ToShortDateString()}";
    }

    // Metodo sobrecargado
    public string ShowData(string initialMessage){
        return $"{initialMessage} -> Nombre: {this.Name}, Correo: {this.Email}, Saldo: {this.Balance}, Fecha de Registro: {this.RegisterDate}";
    }

}