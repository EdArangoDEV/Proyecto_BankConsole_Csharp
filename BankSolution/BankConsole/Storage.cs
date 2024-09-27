using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankConsole;

public static class Storage
{
    // Ubicacion de archivo
    // static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\users.json";
    static readonly string filePath = @"D:\Documentos\EA\CURSOS JAMES\POO .NET\BankSolution\BankConsole\users.json";


    public static List<object> GetListObjects()
    {
        string usersInFile = "";

        if (File.Exists(filePath))
            usersInFile = File.ReadAllText(filePath);

        var listObjects = JsonConvert.DeserializeObject<List<object>>(usersInFile);

        return listObjects;
    }

    public static List<User> ConvertListObj(List<object> listObjects){
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


    public static List<User> GetListUsers()
    {
        var listUsers = new List<User>();

        var listObjects = GetListObjects();

        if (listObjects == null)
            return listUsers;

        listUsers = ConvertListObj(listObjects);

        return listUsers;
    }


    public static void WriteFormatToJSON(List<User> list)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings { Formatting = Formatting.Indented };

        // serializacion de Objeto a JSON
        string json = JsonConvert.SerializeObject(list, settings);

        File.WriteAllText(filePath, json);
    }


    public static void AddUser(User user)
    {
        var listUsers = new List<User>();
        var listObjects = GetListObjects();

        if (listObjects != null)
            listUsers = ConvertListObj(listObjects);

        listUsers.Add(user);

        WriteFormatToJSON(listUsers);
    }


    public static List<User> GetNewUsers()
    {
        var listUsers = GetListUsers();

        var newUserList = listUsers.Where(user => user.GetRegisterDate().Date.Equals(DateTime.Today)).ToList();

        return newUserList;
    }


    public static string DeleteUser(int Id)
    {
        var listUsers = GetListUsers();

        var userToDelete = listUsers.Where(user => user.GetId() == Id).Single();

        listUsers.Remove(userToDelete);

        WriteFormatToJSON(listUsers);

        return "Success";
    }

}