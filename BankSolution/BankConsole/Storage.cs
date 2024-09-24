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

        var listUsers = JsonConvert.DeserializeObject<List<object>>(usersInFile);

        if (listUsers == null)
            listUsers = new List<object>();

        listUsers.Add(user);

        JsonSerializerSettings settings = new JsonSerializerSettings {Formatting = Formatting.Indented};
        
        // serializacion de Objeto a JSON
        json = JsonConvert.SerializeObject(listUsers, settings);

        File.WriteAllText(filePath, json);

    }

}