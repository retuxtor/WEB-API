using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationService.Models;
using PresentationService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresentationController : ControllerBase
    {
        //private readonly ILogger _logger;
        //private readonly PresentationContext _context;
        private readonly IPresentationWorker _presentationWorker;

        public PresentationController(IPresentationWorker presentationWorker)
        {
            //_logger = logger;
            //_context = context;
            _presentationWorker = presentationWorker;
        }

        [HttpGet("GetDefinedValue/{qauntity}")]
        public IEnumerable<Presentation> GetDefinedValue(int qauntity)
        {
            return _presentationWorker.GetListPresentation(qauntity);
        }

        [HttpGet("{id}")]
        public Presentation GetPresentation(int id)
        {
            return _presentationWorker.GetPresentation(id);
        }


        [HttpGet("GetByDate")]
        public IEnumerable<Presentation> GetByDate(DateTime dateFrom, DateTime dateTo)
        {
            return _presentationWorker.GetPresentationInDateInterval(dateFrom, dateTo);
        }
        
        [HttpPut("RefreshStatus")]
        public StatusCodeResult CheckStatus()
        {
            return _presentationWorker.UpdateStatus() == true ? Ok() : NoContent();
        }

        [HttpPost("CreateNewPresentation")]
        public StatusCodeResult AddField(Presentation presentation)
        {
            return _presentationWorker.AddPresentation(presentation) == true ? Ok() : NoContent();
        }
    }
}
