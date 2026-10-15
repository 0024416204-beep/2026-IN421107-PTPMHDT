using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;
using EduHub.Ch02.Observers;

namespace EduHub.Ch02.Services;

public class EventService
{
    private readonly IClubRepository _repo;
    private readonly List<IEventObserver> _observers = new();

    public EventService(IClubRepository repo)
    {
        _repo = repo;
    }

    public void RegisterObserver(IEventObserver observer)
    {
        _observers.Add(observer);
    }

    public Event CreateEvent(Guid clubId, string title, DateTime date)
    {
        var club = _repo.GetById(clubId) ?? throw new InvalidOperationException("Club not found");
        var ev = new Event { Id = Guid.NewGuid(), ClubId = clubId, Title = title, Date = date };

        var members = _repo.GetMembersByClubId(clubId);
        foreach (var member in members)
        {
            foreach (var observer in _observers)
            {
                observer.OnEventCreated(ev, club, member);
            }
        }
        return ev;
    }
}