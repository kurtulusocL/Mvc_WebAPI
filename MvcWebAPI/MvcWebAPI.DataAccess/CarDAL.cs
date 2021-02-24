using MvcWebAPI.DataAccess.dbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWebAPI.DataAccess
{
    public class CarDAL:BaseDAL
    {     
        public IEnumerable<Cars> GetAllCars()
        {
            return context.Cars.ToList();
        }
        public Cars GetById(int id)
        {
            return context.Cars.Find(id);
        }
        public Cars Create(Cars model)
        {
            context.Cars.Add(model);
            context.SaveChanges();
            return model;
        }

        public Cars Update(int id, Cars model)
        {
            var update = context.Cars.Find(id);
            if (update != null)
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
            return model;
        }
        public void Delete(int id)
        {
            var delete = context.Cars.Find(id);
            if (delete != null)
            {
                context.Cars.Remove(delete);
                context.SaveChanges();
            }
        }
        public bool IsCar(int id)
        {
            return context.Cars.Any(i => i.Id == id);
        }
    }
}
