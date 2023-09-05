namespace SelfHostWebServer
{
    using System.Configuration;

    public static class ApplicationContext
    {
        public static string FilePath { get; private set; }
        public static string BaseAddress { get; private set; }

        public static void InitializeApplicationContext()
        {
            FilePath = ConfigurationManager.AppSettings["FilePath"];

            BaseAddress = ConfigurationManager.AppSettings["BaseAddress"];

            if (string.IsNullOrEmpty(BaseAddress))
            {
                BaseAddress = "http://localhost:8080";
            }
        }
    }
}
