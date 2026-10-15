using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Observers;

public class EmailNotifier : IEventObserver
{
    public void OnEventCreated(Event ev, Club club, Member member)
    {
        Console.WriteLine($"Email to {member.Email}: new event '{ev.Title}' at {club.Name}");
    }
}