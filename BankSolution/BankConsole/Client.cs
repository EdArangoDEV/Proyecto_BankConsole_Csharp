namespace BankConsole;

public class Client : User, IPerson
{
    private char TaxRegime { get; set; }

    // constructor que implementa el constructor de la clase padre
    public Client(int Id, string Name, string Email, decimal Balance, char TaxRegime) : base(Id, Name, Email, Balance)
    {
        this.TaxRegime = TaxRegime;
    }

    // sobrescritura de metedos
    public override void SetBalance(decimal amount)
    {
        base.SetBalance(amount);

        if(TaxRegime.Equals('M'))
            Balance += (amount * 0.02m);
    }

    public override string ShowData()
    {
        return base.ShowData() + $", Regimen Fiscal: {this.TaxRegime}";
    }

    public string GetName()
    {
        return this.Name;
    }

    public string GetCountry()
    {
        throw new NotImplementedException();
    }
}