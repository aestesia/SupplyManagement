using API.Base;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : BaseController<VendorRepository, Vendor, int>
    {
        private VendorRepository vendorRepository;

        public VendorController(VendorRepository vendorRepository) : base(vendorRepository)
        {
            this.vendorRepository = vendorRepository;
        }

        //[HttpPut]
        //public override IActionResult Update(Vendor vendor)
        //{
        //    try
        //    {
        //        var result = vendorRepository.Update(vendor);
        //        if (result == 0)
        //            return Ok(new { StatusCode = 200, Message = "Failed to Update Data" });
        //        else if (result == 3)
        //            return Ok(new { StatusCode = 200, Message = "This Company is not Approved as Vendor" });
        //        return Ok(new { StatusCode = 200, Message = "Update Data Success" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { StatusCode = 400, Message = ex.Message });
        //    }
        //}
    }
}
