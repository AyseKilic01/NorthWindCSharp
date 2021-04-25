using NortWindCSharp.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortWindCSharp.DAL
{
    class ProductDal
    {
        public List<Products> GetAll()
        {
            using (NWContext context = new NWContext())
            {
                return context.Products.ToList();
            }
        }
        public void Add(Products products)
        {
            using (NWContext context = new NWContext())
            {
                //context.Products.Add(products);
                var entity = context.Entry(products);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(Products products)
        {
            using (NWContext context = new NWContext())
            {
                var entity = context.Entry(products);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Products products)
        {
            using (NWContext context = new NWContext())
            {
                var entity = context.Entry(products);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
