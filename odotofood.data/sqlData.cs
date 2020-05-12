using odotofood.core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace odotofood.data
{
  public  class sqlData : IRestaurantData 
    {
        //to get Instance of DBcontext
        private readonly OdetofoodDBcontext db;

        public sqlData(OdetofoodDBcontext db)
        {
                this.db = db;
        }
        public Resturaunts Add(Resturaunts Data)
        {
            db.Add(Data);
            return Data;
        }

        public int commit()
        {
            return db.SaveChanges();

        }

        public int Count()
        {
            return db.Resturaunt.Count();
        }

        public Resturaunts delete(int id)
        {
            var d = GetDatabyID(id);
            if (d != null) 
            {
                db.Resturaunt.Remove(d);
               
            }
            return d;
        }

        public Resturaunts Edit(Resturaunts resdata)
        {
            //Attach Method means that object which come is already in DB 
            var entity = db.Resturaunt.Attach(resdata);
            entity.State = EntityState.Modified;
            return resdata; 
        }

        public IEnumerable<Resturaunts> GetData()
        {
            throw new NotImplementedException();
        }

        public Resturaunts GetDatabyID(int id)
        {
            return db.Resturaunt.Find(id);
        }

        public IEnumerable<Resturaunts> GetDatabyname(string term)
        {
            var q= from r in db.Resturaunt
                   where string.IsNullOrEmpty(term) || r.Name.Contains(term)
                   orderby r.Name
                   select r;
            return q;
        }
    }

       
    
}
