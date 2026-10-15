using EduHub.Ch02.Domain;
using EduHub.Ch02.Factories;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Services;

public class ClubService
{
    private readonly IClubRepository _repo;
    private readonly INotificationServiceFactory _notifFactory;

    public ClubService(IClubRepository repo, INotificationServiceFactory notifFactory)
    {
        _repo = repo;
        _notifFactory = notifFactory;
    }

    public void CreateClub(string name, string description, string presidentEmail, NotificationChannel channel)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Club name is required");

        var club = new Club { Id = Guid.NewGuid(), Name = name, Description = description };
        _repo.AddClub(club);

        var notifService = _notifFactory.Create(channel);
        notifService.Send(presidentEmail, $"Club {name} created successfully!");
    }
}