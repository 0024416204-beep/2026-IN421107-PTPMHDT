using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Strategies;

public class ReportService
{
    private readonly IReportStrategy _strategy;

    public ReportService(IReportStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Generate(IEnumerable<Club> clubs, IEnumerable<Member> members)
    {
        _strategy.GenerateReport(clubs, members);
    }
}