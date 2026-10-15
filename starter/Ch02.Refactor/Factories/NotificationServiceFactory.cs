using EduHub.Ch02.Interfaces;
namespace EduHub.Ch02.Factories;

public interface INotificationServiceFactory
{
    INotificationService Create(NotificationChannel channel);
}

public class NotificationServiceFactory : INotificationServiceFactory
{
    public INotificationService Create(NotificationChannel channel)
    {
        return channel switch
        {
            NotificationChannel.Gmail => new GmailNotificationService(),
            NotificationChannel.Yahoo => new YahooNotificationService(),
            NotificationChannel.Slack => new SlackNotificationService(),
            _ => new GenericEmailNotificationService()
        };
    }
}