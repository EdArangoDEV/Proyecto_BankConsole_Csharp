namespace BankConsole;

public abstract class Person
{
    // metodos abstractos solo se definen
    public abstract string GetName();

    public string GetCountry(){
        return "Mexico";
    }

}

// definicion de Interface
public interface IPerson
{
    string GetName();
    string GetCountry();
}