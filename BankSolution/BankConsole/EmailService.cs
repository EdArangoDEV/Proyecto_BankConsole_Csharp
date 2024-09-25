using MailKit.Net.Smtp;
using MimeKit;

namespace BankConsole;

public static class EmailService
{

    // metodo para enviar correo
    public static void SendMail()
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("Eduardo Gutierrez", "Krcastillo42@gmail.com"));
        message.To.Add(new MailboxAddress("Admin", "Krcastillo42@gmail.com"));
        message.Subject = "BankConsole: Usuarios nuevos";
        message.Body = new TextPart("plain"){
            Text = GetEmailText()
        };

        using (var client = new SmtpClient()){
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("krcastillo42@gmail.com", "");
            client.Send(message);
            client.Disconnect(true);
            Console.WriteLine("Se envio correo...");
        }

    }

    // metodo para obetener informacion a enviar en el correo
    public static string GetEmailText()
    {

        List<User> newUsers = Storage.GetNewUsers();

        if (newUsers.Count == 0)
            return "No hay usuarios nuevos.";

        string emailText = "Usuarios agregados hoy:\n";

        foreach (User user in newUsers)
        {
            emailText += "\t " + user.ShowData() + "\n";
        }

        return emailText;
    }
}