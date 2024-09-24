using Newtonsoft.Json;

namespace BankConsole;

public static class Storage
{
    // Ubicacion de archivo
    static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\users.json";

    public static void AddUser(User user){
        string json = "", usersInFile = "";

        if (File.Exists(filePath))
            usersInFile = File.ReadAllText(filePath);

        var listUsers = JsonConvert.DeserializeObject<List<User>>(usersInFile);

        if (listUsers == null)
            listUsers = new List<User>();

        listUsers.Add(user);
        
        // serializacion de Objeto a JSON
        json = JsonConvert.SerializeObject(listUsers);

        File.WriteAllText(filePath, json);

    }

}