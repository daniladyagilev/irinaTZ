using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Logic
{
    class GetRequest
    {
        
        public static string SaveHTMLPages(string site)
        {
            string html = "";
            for (int i = 0; i < site.Length; i++)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string directory = Directory.GetCurrentDirectory();
                        Console.WriteLine(site.ToString());

                        html += client.DownloadString(site.ToString());

                        File.WriteAllText(directory + @"\" + i + ".html", html);
                        Console.WriteLine("File save");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : " + e.ToString());
                }
            }
            return html;
        }
    }
}
