using Microsoft.EntityFrameworkCore;
using odotofood.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace odotofood.data
{
    public class OdetofoodDBcontext :DbContext
    {
        //to make My DBcontext 
        public OdetofoodDBcontext(DbContextOptions<OdetofoodDBcontext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Resturaunts> Resturaunt { get; set; } 
    }
}
