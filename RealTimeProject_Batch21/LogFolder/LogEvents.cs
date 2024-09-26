namespace RealTimeProject_Batch21.LogFolder
{
    //Log4Net, ''microsoft logging framework// Azure app sights
    //AWS - cloudwatch // SeriLog - Promethus and Grafana
    public static class LogEvents
    {
        public static void LogToFile(string title, string methodName, string className, string logMessage)
        {
            var finalMessage = title + " " + methodName + " " + className + " " + logMessage + "---" + DateTime.Now.ToLongDateString();
            StreamWriter logWriter;
            string fileName = "Logs.txt";

            if (!File.Exists(fileName))
            {
                logWriter = new StreamWriter(fileName);
            }
            else
            {
                logWriter = File.AppendText(fileName);
            }
            logWriter.WriteLine(finalMessage);
            logWriter.Close();
        }
    }
}
