using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Strategies;

public interface IReportStrategy
{
    void GenerateReport(IEnumerable<Club> clubs, IEnumerable<Member> members);
}