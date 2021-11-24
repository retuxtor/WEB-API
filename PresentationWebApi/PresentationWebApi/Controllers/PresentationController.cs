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
        private readonly ILogger _logger;
        private readonly PresentationContext _context;
        private readonly IWorkerWithDB _presentationWorker;

        public PresentationController(ILogger<PresentationController> logger, PresentationContext context, IWorkerWithDB presentationWorker)
        {
            _logger = logger;
            _context = context;
            _presentationWorker = presentationWorker;
        }

        [HttpGet("GetDefinedValue/{qauntity}")]
        public IEnumerable<Presentation> GetDefinedValue(int qauntity)
        {
            return _context.Presentation.OrderBy(p => p.Id).Take(qauntity).ToList();
        }

        [HttpGet("{id}")]
        public Presentation GetField(int id)
        {
            return _context.Presentation.Where(p => p.Id == id).FirstOrDefault();
        }

        [HttpGet("GetByDate")]
        public IEnumerable<Presentation> GetByDate(DateTime dateFrom, DateTime dateTo)
        {
            return _context.Presentation.Where(p => p.Time >= dateFrom && p.Time <= dateTo).ToList();
        }

        [HttpPut("CheckStatus")]
        public void CheckStatus()
        {
            var t = _context.Presentation.Where(p => p.Time > DateTime.Now).ToList();
            t.ForEach(p => p.Status = Presentation.StatusPresentation.Close);
            _context.SaveChanges();
        }
    }
}
