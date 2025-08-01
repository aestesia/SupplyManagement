using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role, int>
    {
        private MyContext myContext;
        public RoleRepository(MyContext myContext) : base(myContext) 
        {
            this.myContext = myContext;
        }
    }
}
