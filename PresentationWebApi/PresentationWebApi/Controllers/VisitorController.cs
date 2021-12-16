using Microsoft.AspNetCore.Mvc;
using PresentationService.Models;
using PresentationWebApi.Services.Interface;
using System.Linq;

namespace PresentationWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {

        private readonly IVisitorWorker _worker;

        public VisitorController(IVisitorWorker worker)
        {
            _worker = worker;
        }


        [HttpGet()]
        public Visitors GetVisitor(int number)
        {
            return _worker.GetVisitor(number);
        }

        [HttpPost()]
        public StatusCodeResult AddVisitor(Visitors visitor)
        {
            _worker.AddVisitor(visitor);
            return Ok();
        }

        [HttpPut()]
        public StatusCodeResult ChangeVisitor(Visitors visitor)
        {
            _worker.ChangeVisitor(visitor);
            return Ok();
        }

    }
}
