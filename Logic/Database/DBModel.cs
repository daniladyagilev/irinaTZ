using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Logic.Database;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Logic
{
    public class DBModel : IDBModel
    {
        public List<Stat> GetStatsFromDB() //rename to post stats to db
        {

            string createText = "https://yandex.ru";
            var htmls = GetRequest.SaveHTMLPages(createText);

            var pairs = new Analyze().Work(htmls);

            List<Stat> nodes = new List<Stat>();

            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var pair in pairs)
                {
                    Stat entry = new Stat
                    {
                       Word = pair.Key,
                       Quantity = pair.Value
                    };
                    nodes.Add(entry);
                    db.Stat.Add(entry);
                }
            }
            return nodes;
        }
    }
}