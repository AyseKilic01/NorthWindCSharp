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
        public List<Products> GetUnitePrice(decimal price)
        {
            using (NWContext context = new NWContext())
            {
                return context.Products.Where(x => x.UnitPrice >= price).ToList();
            }
        }
        public List<Products> GetUnitePrice(decimal max, decimal min)
        {
            using (NWContext context = new NWContext())
            {
                return context.Products.Where(x => x.UnitPrice >= min && x.UnitPrice < max).ToList();
                //where ile direkt tablodan koşul ile veri alabiliyoruz
            }
        }
        public Products GetByID(int id)
        {
            using (NWContext context = new NWContext())
            {
                return context.Products.FirstOrDefault(x => x.ID == id);
                // return context.Products.SingleOrDefault(x => x.ID == id);
                //tabloda eğer gönderilen id varsa veri çek yoksa default null gönder firstordefault
                //tabloda eğer gönderilen id birden fazla ise sadece bir veriyi çek yoksa default null gönder singleordefault
            }
        }
    }
}
