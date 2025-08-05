using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : BaseController<CompanyRepository, Company, int>
    {
        private CompanyRepository companyRepository;

        public CompanyController(CompanyRepository companyRepository) : base(companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        
        [HttpGet]
        public override IActionResult GetAll()
        {
            try
            {
                var data = companyRepository.GetAll();
                if (data == null)
                    return Ok(new { StatusCode = 200, Message = "Data is Empty" });
                return Ok(new { StatusCode = 200, Message = "Data Found", Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public override IActionResult GetById(int id)
        {
            try
            {
                var data = companyRepository.GetById(id);
                if (data == null)
                    return Ok(new { StatusCode = 200, Message = "Data is Not Found" });
                return Ok(new { StatusCode = 200, Message = "Data Found", Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost("approve")]
        public IActionResult ApproveCompany(int id)
        {
            try
            {
                var result = companyRepository.ApproveCompany(id);
                if (result == 0)
                    return Ok(new { StatusCode = 200, Message = "Failed to Approve" });
                return Ok(new { StatusCode = 200, Message = "Company Approval Success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }
        
    }
}
