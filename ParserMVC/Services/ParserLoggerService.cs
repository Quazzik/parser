namespace ParserMVC.Services
{
    public class ParserLoggerService
    {
        private readonly string logFilePath;

        public ParserLoggerService()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            logFilePath = Path.Combine(desktopPath, "log.txt");

            // Создание файла и запись о начале логгирования, если файла нет
            if (!File.Exists(logFilePath))
            {
                using (StreamWriter writer = File.CreateText(logFilePath))
                {
                    writer.WriteLine("=== Логгирование начато: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " ===");
                }
            }
        }

        public async Task Log(string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {message}";

            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    await writer.WriteLineAsync(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи лога: {ex.Message}");
            }
        }
    }
}