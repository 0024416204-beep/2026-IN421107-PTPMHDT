using EduHub.Ch02.Domain;
namespace EduHub.Ch02.Interfaces;

public interface IClubRepository
{
    void AddClub(Club club);
    Club? GetById(Guid id);
    List<Club> GetAllClubs();
    void AddMember(Member member);
    List<Member> GetMembersByClubId(Guid clubId);
}