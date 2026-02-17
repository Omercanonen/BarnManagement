namespace BarnManagement.Core.Logging
{
    public class FileLogger : ILoggerService
    {
        private readonly string _logDirectory;

        public FileLogger()
        {
            _logDirectory = Path.Combine(Application.StartupPath, "Logs");
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }
        }

        public void LogInfo(string message)
        {
            WriteLog("INFO", message);
        }

        public void LogWarning(string message)
        {
            WriteLog("WARNING", message);
        }

        public void LogError(string message, Exception? ex = null)
        {
            // Eğer exception varsa mesajın sonuna detayını ekle
            string finalMessage = ex != null
                ? $"{message} | Exception: {ex.Message}"
                : message;

            WriteLog("ERROR", finalMessage);
        }

        private void WriteLog(string level, string message)
        {
            try
            {
                string fileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
                string filePath = Path.Combine(_logDirectory, fileName);

                string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {level} - {message}";

                lock (this)
                {
                    File.AppendAllText(filePath, logLine + Environment.NewLine);
                }
            }
            catch
            {
            }
        }
    }
}
