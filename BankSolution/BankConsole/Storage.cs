using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankConsole;

public static class Storage
{
    // Ubicacion de archivo
    // static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\users.json";
    static readonly string filePath = @"D:\Documentos\EA\CURSOS JAMES\POO .NET\BankSolution\BankConsole\users.json";


    public static List<object> ObtenerLisObject()
    {
        string usersInFile = "";

        if (File.Exists(filePath))
            usersInFile = File.ReadAllText(filePath);

        var listObjects = JsonConvert.DeserializeObject<List<object>>(usersInFile);

        return listObjects;
    }

    public static List<User> ConvertList(List<object> listObjects){
        var listUsers = new List<User>();

        foreach (object obj in listObjects)
        {
            User newUser;
            JObject user = (JObject)obj;

            if (user.ContainsKey("TaxRegime"))
                newUser = user.ToObject<Client>();
            else
                newUser = user.ToObject<Employee>();

            listUsers.Add(newUser);
        }

        return listUsers;
    }


    public static List<User> ObtenerListaUser()
    {
        var listUsers = new List<User>();

        var listObjects = ObtenerLisObject();

        if (listObjects == null)
            return listUsers;

        listUsers = ConvertList(listObjects);

        return listUsers;
    }


    public static void WriteFormatoJSON(List<User> list)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings { Formatting = Formatting.Indented };

        // serializacion de Objeto a JSON
        string json = JsonConvert.SerializeObject(list, settings);

        File.WriteAllText(filePath, json);
    }


    public static void AddUser(User user)
    {
        var listUsers = new List<User>();
        var listObjects = ObtenerLisObject();

        if (listObjects != null)
            listUsers = ConvertList(listObjects);

        listUsers.Add(user);

        WriteFormatoJSON(listUsers);
    }


    public static List<User> GetNewUsers()
    {
        var listUsers = ObtenerListaUser();

        var newUserList = listUsers.Where(user => user.GetRegisterDate().Date.Equals(DateTime.Today)).ToList();

        return newUserList;
    }


    public static string DeleteUser(int Id)
    {
        var listUsers = ObtenerListaUser();

        var userToDelete = listUsers.Where(user => user.GetId() == Id).Single();

        listUsers.Remove(userToDelete);

        WriteFormatoJSON(listUsers);

        return "Success";
    }

}