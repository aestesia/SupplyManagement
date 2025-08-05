using API.Handlers;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private JWTConfig jwtConfig;
        private AccountRepository accountRepository;

        public AccountController(JWTConfig jwtConfig, AccountRepository accountRepository)
        {
            this.jwtConfig = jwtConfig;
            this.accountRepository = accountRepository;
        }

        [HttpPost("Login")]
        public IActionResult Login (string companyEmail, string password)
        {
            try
            {
                ResponseLogin login = accountRepository.Login(companyEmail, password);
                if (login == null)
                    return Ok(new { StatusCode = 200, Message = "Login Failed" });

                string token = jwtConfig.Token(login.Id, login.Name, login.CompanyEmail, login.Role);
                return Ok(new { StatusCode = 200, Message = "Login Success", Data = login, token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(string name, string companyEmail, string password, string companyName, string companyPhone, string? photoUrl)
        {
            try
            {
                var result = accountRepository.Register(name, companyEmail, password, companyName, companyPhone, photoUrl);
                if (result == 2)
                    return Ok(new { StatusCode = 200, Message = "Email is Already Used" });
                if (result == 0)
                    return Ok(new { StatusCode = 200, Message = "Failed to Register" });
                return Ok(new { StatusCode = 200, Message = "Register Success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message});
            }
        }

        [HttpPut("ChangePass")]
        public IActionResult ChangePass(string email, string currentPass, string newPass)
        {
            try
            {
                var result = accountRepository.ChangePass(email, currentPass, newPass);
                if (result == 0)
                    return Ok(new { StatusCode = 200, Message = "Failed to Change Password" });
                return Ok(new { StatusCode = 200, Message = "Change Password Success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("ForgetPass")]
        public IActionResult ForgotPass(string email, string password)
        {
            try
            {
                var result = accountRepository.ForgotPass(email, password);
                if (result == 0)
                    return Ok(new { StatusCode = 200, Message = "Failed to Reset Password" });
                return Ok(new { StatusCode = 200, Message = "Reset Password Success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

    }
}
