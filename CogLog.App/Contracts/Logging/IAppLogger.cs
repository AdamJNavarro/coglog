namespace CogLog.App.Contracts.Logging;

public interface IAppLogger<T>
{
    void LogInfo(string message, params object[] args);

    void LogWarning(string message, params object[] args);
}
