using EduHub.Ch02.Interfaces;
namespace EduHub.Ch02.Factories;

public class GmailNotificationService : INotificationService
{
    public void Send(string recipient, string message) => Console.WriteLine($"Sending Gmail to {recipient}: {message}");
}
public class YahooNotificationService : INotificationService
{
    public void Send(string recipient, string message) => Console.WriteLine($"Sending Yahoo to {recipient}: {message}");
}
public class SlackNotificationService : INotificationService
{
    public void Send(string recipient, string message) => Console.WriteLine($"Slack notification: {message}");
}
public class GenericEmailNotificationService : INotificationService
{
    public void Send(string recipient, string message) => Console.WriteLine($"Sending generic email to {recipient}: {message}");
}