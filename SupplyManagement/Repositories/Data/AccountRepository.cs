using API.Context;
using API.Handlers;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public ResponseLogin Login(string email, string password)
        {
            var data = myContext.Companies
                .Include(x => x.User)
                .Include(x => x.User.Role)
                .SingleOrDefault(x => x.User.CompanyEmail.Equals(email));
            var validate = Hashing.ValidatePassword(password, data.User.Password);

            if (data == null && !validate)
                return null;

            ResponseLogin login = new ResponseLogin()
            {
                Id = data.Id,
                Name = data.User.Name,
                CompanyEmail = data.User.CompanyEmail,
                Role = data.User.Role.Name,
                CompanyName = data.CompanyName ?? ""
            };
            return login;
        }

        public int Register(string name, string companyEmail, string password, string companyName, string companyPhone, string? photoUrl)
        {
            var checkEmail = myContext.Users.Any(x => x.CompanyEmail.Equals(companyEmail));
            if (checkEmail)
                return 2;

            User user = new User()
            {
                Name = name,
                CompanyEmail = companyEmail,
                Password = Hashing.HashPassword(password),
                RoleId = 1 //User
            };
            myContext.Users.Add(user);
            var result = myContext.SaveChanges();
            if(result > 0)            
            { 
                var id = myContext.Users.SingleOrDefault(x => x.CompanyEmail.Equals(companyEmail)).Id;
                Company company = new Company()
                {
                    Id = id,
                    CompanyName = companyName,
                    CompanyPhone = companyPhone,
                    Photo = photoUrl ?? "",
                    StatusId = 3 //pending
                };
                myContext.Companies.Add(company);
                var resultCompany = myContext.SaveChanges();
                if (resultCompany > 0)
                    return resultCompany;
            }
            return 0;
        }

        public int ChangePass(string email, string currentPass, string newPass)
        {
            var data = myContext.Users
                .SingleOrDefault(x => x.CompanyEmail.Equals(email));
            var validate = Hashing.ValidatePassword(currentPass, data.Password);
            if (data != null && validate)
            {
                data.Password = Hashing.HashPassword(newPass);
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return result;
            }
            return 0;
        }

        public int ForgotPass(string email, string newPass)
        {
            var data = myContext.Users
                .SingleOrDefault(x => x.CompanyEmail.Equals(email));
            if (data != null)
            {
                data.Password = Hashing.HashPassword(newPass);
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0) 
                    return result;
            }
            return 0;
        }

    }
}
