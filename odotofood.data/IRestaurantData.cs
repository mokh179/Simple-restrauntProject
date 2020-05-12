using odotofood.core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace odotofood.data
{
    public interface IRestaurantData
    {
        IEnumerable<Resturaunts> GetData();
        IEnumerable<Resturaunts> GetDatabyname(string term);
        Resturaunts GetDatabyID(int id);
        Resturaunts Edit(Resturaunts resdata);
        Resturaunts Add(Resturaunts Data);
        Resturaunts delete(int id);
        int Count();
        int commit();
    }
    public class InMemoryRestaurantData :IRestaurantData
    {
       readonly List<Resturaunts> resturaunts;
        public InMemoryRestaurantData()
        {
            resturaunts = new List<Resturaunts>()
            {
                new Resturaunts {ID=1,Name="Awlad Taha",location="Alex",Type=CuisineType.Indian},
                new Resturaunts {ID=2,Name="Sobhy Kaber",location="Cairo",Type=CuisineType.Italian}

            };
        }

        public Resturaunts Edit(Resturaunts resdata)
        {
            var data= resturaunts.SingleOrDefault(r => resdata.ID==r.ID);
            if (data!=null)
            {
                data.Name = resdata.Name;
                data.location = resdata.location;
                data.Type = resdata.Type;
            }
            return data;
        }
        public int commit()
        {
            return 0;
        }
        public IEnumerable<Resturaunts> GetData()
        {
            return from r in resturaunts
                   orderby r.Name
                   select r; 
        }

        public Resturaunts GetDatabyID(int id)
        {
            return resturaunts.SingleOrDefault(r => r.ID == id);
        }

        public IEnumerable<Resturaunts> GetDatabyname(string term =null)
        {
            return from r in resturaunts
                   where string.IsNullOrEmpty(term)|| r.Name.Contains(term)
                   orderby r.Name
                   select r;
        }

        public Resturaunts Add(Resturaunts Data)
        {
            resturaunts.Add(Data);
            Data.ID = resturaunts.Max(i => i.ID) + 1;
            return Data;

        }

        public Resturaunts delete(int id)
        {
            var d = resturaunts.FirstOrDefault(r => r.ID == id);
            if (d != null) 
            {
               resturaunts.Remove(d);
            }
            return d;
        }

        public int Count()
        {
            return resturaunts.Count();
        }
    }
}
//M0.Kh@led1911/20