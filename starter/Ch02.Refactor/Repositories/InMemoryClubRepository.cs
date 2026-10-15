using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Repositories;

public class InMemoryClubRepository : IClubRepository
{
    private readonly List<Club> _clubs = new();
    private readonly List<Member> _members = new();

    public void AddClub(Club club) => _clubs.Add(club);

    public Club? GetById(Guid id) => _clubs.FirstOrDefault(c => c.Id == id);

    public List<Club> GetAllClubs() => _clubs;

    public void AddMember(Member member) => _members.Add(member);

    public List<Member> GetMembersByClubId(Guid clubId) => _members.Where(m => m.ClubId == clubId).ToList();
}