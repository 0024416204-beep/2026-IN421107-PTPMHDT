using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Strategies;

public class ConsoleReportStrategy : IReportStrategy
{
    public void GenerateReport(IEnumerable<Club> clubs, IEnumerable<Member> members)
    {
        foreach (var club in clubs)
        {
            var memberCount = members.Count(m => m.ClubId == club.Id);
            Console.WriteLine($"Club: {club.Name} | Members: {memberCount}");
        }
    }
}