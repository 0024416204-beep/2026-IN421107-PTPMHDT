using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Strategies;

public class CsvReportStrategy : IReportStrategy
{
    public void GenerateReport(IEnumerable<Club> clubs, IEnumerable<Member> members)
    {
        Console.WriteLine("ClubName,MemberCount");
        foreach (var club in clubs)
        {
            var memberCount = members.Count(m => m.ClubId == club.Id);
            Console.WriteLine($"{club.Name},{memberCount}");
        }
    }
}