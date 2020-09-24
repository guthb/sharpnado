using System;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Cars
{
    public class CarDb : DbContext
    {
        public DbSet<Car> Cars{get; set;}
    }
}
