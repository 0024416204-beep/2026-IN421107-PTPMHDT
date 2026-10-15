using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Repositories;

public class LoggingClubRepository : IClubRepository
{
    private readonly IClubRepository _innerRepo;
    private readonly IAppLogger _logger;

    public LoggingClubRepository(IClubRepository innerRepo, IAppLogger logger)
    {
        _innerRepo = innerRepo;
        _logger = logger;
    }

    public void AddClub(Club club)
    {
        _innerRepo.AddClub(club);
        _logger.Log($"Club created: {club.Name}");
    }

    public Club? GetById(Guid id) => _innerRepo.GetById(id);

    public List<Club> GetAllClubs() => _innerRepo.GetAllClubs();

    public void AddMember(Member member)
    {
        _innerRepo.AddMember(member);
        _logger.Log($"Member {member.Name} added to club ID {member.ClubId}");
    }

    public List<Member> GetMembersByClubId(Guid clubId) => _innerRepo.GetMembersByClubId(clubId);
}