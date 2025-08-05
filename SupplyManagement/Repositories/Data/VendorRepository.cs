using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class VendorRepository : GeneralRepository<Vendor, int>
    {
        private MyContext myContext;
        public VendorRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public override int Create(Vendor vendor)
        {
            throw new NotSupportedException("Create is not allowed.");
        }

        //public int Update(Vendor vendor)
        //{
        //    var data = myContext.Vendors
        //        .Include(x => x.Company)
        //        .SingleOrDefault(x => x.Id == vendor.Id);

        //    var checkStatus = data.Company.StatusId;

        //    if (checkStatus != 1)
        //        return 2;

        //    myContext.Entry(vendor).State = EntityState.Modified;
        //    var result = myContext.SaveChanges();
        //    return result;
        //}

    }
}
