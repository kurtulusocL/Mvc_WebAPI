using MvcWebAPI.DataAccess.dbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWebAPI.DataAccess
{
    public class BrandDAL : BaseDAL
    {
        public IEnumerable<Brands> GetAllBrands()
        {
            return context.Brands;
        }
        public Brands GetById(int id)
        {
            return context.Brands.Find(id);
        }
        public Brands Create(Brands model)
        {
            context.Brands.Add(model);
            context.SaveChanges();
            return model;
        }

        public Brands Update(int id, Brands model)
        {
            var update = context.Brands.Find(id);
            if (update != null)
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
            return model;
        }
        public void Delete(int id)
        {
            var delete = context.Brands.Find(id);
            if (delete != null)
            {
                context.Brands.Remove(delete);
                context.SaveChanges();
            }
        }
        public bool IsBrand(int id)
        {
            return context.Brands.Any(i => i.Id == id);
        }
    }
}
