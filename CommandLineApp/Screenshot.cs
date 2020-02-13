using System;
using System.Net;
using System.IO;

namespace CommandLineApp
{
    public class Screenshot
    {
        public static void GetScreenshot(string link, string format = "PNG", string output = "screenshot-1.PNG")
        {
            string path = $"//Users//training//Projects//CommandLineApp//CommandLineApp//{output}";
            string url = $"http://api.screenshotlayer.com/api/capture?url={link}&width=1366&access_key=7f12568da69ad43c0d2dd19a63b9d0a0&format={format}";
            WebClient webClient = new WebClient();
            int count = 1;
            string newoutput = output.Substring(0, output.IndexOf('.'));

            if (format != "PNG")
            {
                path = $"//Users//training//Projects//CommandLineApp//CommandLineApp//{newoutput}.{format}";
            }

            while (File.Exists(path))
            {
                count++;
                string incrementoutput = $"{newoutput.Substring(0, output.IndexOf('-'))}-{count}";
                path = $"//Users//training//Projects//CommandLineApp//CommandLineApp//{incrementoutput}.{format}";
            }

            webClient.DownloadFile(url, path);
        }
    }
}
