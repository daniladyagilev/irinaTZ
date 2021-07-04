using System;
using System.Collections.Generic;
using System.Linq;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using Microsoft.CodeAnalysis;
using System.Reflection;
using Microsoft.CodeAnalysis.Emit;
using HtmlAgilityPack;

namespace Logic
{
    public class Analyze
    {
        /// <summary>
        /// Number words
        /// and quantity
        /// </summary>


        public Dictionary<string, int> Work(string site)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
                string text = ReadTextFromSite(site);

                if (text == null)
                {
                    Console.WriteLine("Bad respons from site, may be wrong");
                }
                var result = Calc(text);
                result.Remove("");
                res = result;
            return res;
        }

        static Dictionary<string, int> Calc(string site)
        {
            var res = new Dictionary<string, int>();
            foreach (var word in site.Split
                (' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t').Skip(1))
            {
                var count = 0;
                res.TryGetValue(word, out count);
                res[word] = count + 1;
            }
            return res;
        }


        public string ReadTextFromSite(string site)
        {
            
            var document = new HtmlDocument();
            document.LoadHtml(site);
            var tempString = new StringBuilder();
            foreach (HtmlNode style in document.DocumentNode.Descendants("style").ToArray())
            {
                style.Remove();
            }
            foreach (HtmlNode script in document.DocumentNode.Descendants("script").ToArray())
            {
                script.Remove();
            }
            foreach (HtmlTextNode node in document.DocumentNode.SelectNodes("//*[not(self::script or self::style)]/text()[normalize-space()]"))
            {
                tempString.AppendLine(node.InnerText);
            }
            return Convert.ToString(tempString);
        }

        
    }
}