namespace EduHub.Ch02.Interfaces;

public interface INotificationService
{
    void Send(string recipient, string message);
}