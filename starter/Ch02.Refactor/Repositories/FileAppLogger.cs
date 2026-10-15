using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Repositories;

public class FileAppLogger : IAppLogger
{
    private readonly string _logFilePath = "club-log.txt";

    public void Log(string message)
    {
        File.AppendAllText(_logFilePath, $"[{DateTime.Now}] {message}\n");
    }
}