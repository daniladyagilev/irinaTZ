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
        public string[] site { get; private set; }

        public Analyze(string[] sites)
        {
            site = sites;
        }

        public void Work()
        {
            for (int i = 0; i < site.Length; i++)
            {
                Console.WriteLine("Words of - " + site[i]);
                Console.WriteLine("//////////////////////////////");
                string text = ReadTextFromSite(site[i]);

                if (text == null)
                {
                    Console.WriteLine("Bad respons from site, may be wrong");
                    break;
                }
                var result = Calc(text);
                result.Remove("");
                foreach (var pair in result)
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                Console.WriteLine("//////////////////////////////");
            }

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
            HtmlWeb htmlWeb = new HtmlWeb();
            try
            {
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(site);
                return document.DocumentNode.InnerText;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.ToString());
                return null;
            }
        }
    }
}