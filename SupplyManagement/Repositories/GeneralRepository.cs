using API.Context;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class GeneralRepository<Entity, key> : IRepository<Entity, key>
        where Entity : class
    {
        MyContext myContext;

        public GeneralRepository(MyContext myContext) 
        {
            this.myContext = myContext;
        }

        public virtual int Create(Entity Entity)
        {
            myContext.Set<Entity>().Add(Entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public virtual int Delete(key id)
        {
            var data = GetById(id);
            if (data == null)
                return 0;
            myContext.Set<Entity>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public virtual IEnumerable<Entity> GetAll()
        {
            return myContext.Set<Entity>().ToList();
        }

        public Entity GetById(key id)
        {
            return myContext.Set<Entity>().Find(id);
        }

        public virtual int Update(Entity Entity)
        {
            myContext.Entry(Entity).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }


    }
}
