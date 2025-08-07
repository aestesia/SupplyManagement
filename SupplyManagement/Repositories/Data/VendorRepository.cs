using API.Context;
using API.DTO;
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

        public override int Update(Vendor vendor)
        {
            throw new NotSupportedException("This Update is not allowed.");
        }

        public int Update(UpdateVendorDto updateVendorDto)
        {
            var vendor = myContext.Vendors.Find(updateVendorDto.Id);

            if (vendor == null)
                return 0;

            vendor.BusinessField = updateVendorDto.BusinessField;
            vendor.BusinessType = updateVendorDto.BusinessType;

            var result = myContext.SaveChanges();

            return result;
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
