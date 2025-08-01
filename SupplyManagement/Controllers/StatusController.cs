using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController<StatusRepository, Status, int>
    {
        private StatusRepository statusRepository;
        public StatusController(StatusRepository statusRepository) : base(statusRepository)
        {
            this.statusRepository = statusRepository;
        }
    }
}
