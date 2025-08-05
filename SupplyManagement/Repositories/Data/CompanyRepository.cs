using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class CompanyRepository : GeneralRepository<Company, int>
    {
        private MyContext myContext;
        public CompanyRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public override int Create(Company company)
        {
            throw new NotSupportedException("Create is not allowed.");
        }

        public IEnumerable<CompanyViewModel> GetAll()
        {
            var data = myContext.Set<Company>()
                .Include(x => x.User)
                .ToList();

            if (data == null)
                return null;

            var companyViewModel = data.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                CompanyEmail = x.User.CompanyEmail,
                CompanyPhone = x.CompanyPhone,
                Photo = x.Photo ?? "",
                StatusId = x.StatusId
            });

            return companyViewModel;
        }

        public CompanyViewModel GetById(int id)
        {
            var data = myContext.Set<Company>()
                .Include(x => x.User)
                .SingleOrDefault(x => x.Id == id);

            if (data == null)
                return null;

            CompanyViewModel companyViewModel = new CompanyViewModel()
            {
                Id = data.Id,
                CompanyName = data.CompanyName,
                CompanyEmail = data.User.CompanyEmail,
                CompanyPhone = data.CompanyPhone,
                Photo = data.Photo ?? "",
                StatusId = data.StatusId
            };

            return companyViewModel;
        }

        public int ApproveCompany(int id)
        {
            Company company = new Company()
            {
                Id = id,
                StatusId = 1
            };
            myContext.Companies.Attach(company);
            myContext.Entry(company).Property(x => x.StatusId).IsModified = true;
            var result = myContext.SaveChanges();
            if(result > 0)
            {
                Vendor vendor = new Vendor()
                {
                    Id = id,
                    BusinessField = "",
                    BusinessType = "",
                    StatusId = 3 //pending
                };
                myContext.Vendors.Add(vendor);
                var resultVendor = myContext.SaveChanges();
                if (resultVendor > 0)
                    return resultVendor;
            }
            return 0;
        }

    }
}
