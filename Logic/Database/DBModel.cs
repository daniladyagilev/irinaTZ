using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Logic.Database;
using Microsoft.EntityFrameworkCore;

namespace Logic
{
    public class DBModel : IDBModel
    {
        public List<Stat> GetStats()
        {

            List<Stat> nodes = new List<Stat>();

            using (ApplicationContext db = new ApplicationContext())
            {
                var rows = db.Stat.ToList();
                foreach (var row in rows)
                {
                    Stat entry = new Stat
                    {
                        Id = row.Id,
                        Quantity = row.Quantity,
                        Word = row.Word
                    };
                    nodes.Add(entry);
                }
            }
            return nodes;
        }
    }
}