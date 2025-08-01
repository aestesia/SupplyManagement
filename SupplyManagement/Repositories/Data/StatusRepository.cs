using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class StatusRepository : GeneralRepository<Status, int>
    {
        private MyContext myContext;
        public StatusRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
