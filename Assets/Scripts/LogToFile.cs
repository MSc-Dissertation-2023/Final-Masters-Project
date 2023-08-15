using System.IO;
using UnityEngine;

public class LogToFile : MonoBehaviour
{
    private string logFilePath;

    void Start()
    {
        logFilePath = Path.Combine(Application.dataPath, "log.txt");
        File.WriteAllText(logFilePath, ""); // Clear the log file on start
        Application.logMessageReceived += LogMessage;
    }

    void LogMessage(string condition, string stackTrace, LogType type)
    {
        string logMessage = $"{type}: {condition}\n";
        File.AppendAllText(logFilePath, logMessage);
    }
}
