namespace SelfHostWebServer.Service
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Сервис для чтения данных из файла
    /// </summary>
    public class ReadFileService
    {
        /// <summary>
        /// Получить данные из файла в виде объекта
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>объект</returns>
        public async Task<object> GetObjectFromFileAsync(string fileName)
        {
            var filePath = ApplicationContext.FilePath + fileName;

            try
            {
                using (FileStream fstream = File.OpenRead(filePath))
                {
                    byte[] buffer = new byte[fstream.Length];

                    await fstream.ReadAsync(buffer, 0, buffer.Length);

                    string jsonString = Encoding.Default.GetString(buffer);

                    dynamic jsonObj = JsonConvert.DeserializeObject(jsonString);

                    return jsonObj;
                }
            }
            catch (FileNotFoundException e) 
            {
                Console.WriteLine($"File {filePath} not found {e.Message}");
            }

            return null;
        }
    }
}
