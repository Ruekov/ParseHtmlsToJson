using System.Collections.Generic;
using System.IO;

namespace ParseHtmls
{
    class ParseToJson
    {
        public List<string> phrases = new List<string>();


        public void getAllHtmls(string path)
        {

            string[] allHtmlFiles = Directory.GetFileSystemEntries(path, "*.html", SearchOption.AllDirectories);

            ParseHtmls(allHtmlFiles);

        }


        public void ParseHtmls(string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                var getFileContents = System.IO.File.ReadAllText(filePath);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(getFileContents);
                var nodes = doc.DocumentNode.SelectNodes("//p");
                foreach (var item in nodes)
                {
                    phrases.Add(item.InnerText);
                }

            }

        }


    }
}
