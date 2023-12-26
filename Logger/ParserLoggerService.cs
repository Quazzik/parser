namespace Logger
{
    public class ParserLogger
    {
        private readonly string logFilePath;

        public ParserLogger()
        {
            logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public void Log(string action)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {action}";

            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи лога: {ex.Message}");
            }
        }
    }