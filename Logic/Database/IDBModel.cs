using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IDBModel
    {
       // public List<> GetNodes();
       // public void AddNode(Node node);

     //   public Node GetNode(Guid id);

      //  public void UpdateNode(Node node);

        public List<Stat> GetStatsFromDB();


    }
}