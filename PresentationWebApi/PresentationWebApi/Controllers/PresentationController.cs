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
        public Presentation GetPresentation(int id)
        {
            return _context.Presentation.Where(p => p.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Получает все презентации в указанном промежутке дат.
        /// </summary>
        /// <param name="dateFrom">От данной даты</param>
        /// <param name="dateTo">До сюда</param>
        /// <returns></returns>
        [HttpGet("GetByDate")]
        public IEnumerable<Presentation> GetByDate(DateTime dateFrom, DateTime dateTo)
        {
            return _context.Presentation.Where(p => p.Time >= dateFrom && p.Time <= dateTo);
        }
        
        /// <summary>
        /// Изменяет статус у событий, которые уже прошли
        /// </summary>
        /// <returns></returns>
        [HttpPut("RefreshStatus")]
        public StatusCodeResult CheckStatus()
        {
            var closeList = _context.Presentation.Where(p => p.Time < DateTime.Now).ToList();
            closeList.ForEach(p => p.Status = Presentation.StatusPresentation.Close);
            
            _context.SaveChanges();

            return Ok( );
        }

        /// <summary>
        /// Создает новую презентацию
        /// </summary>
        /// <param name="presentation">Объект класса Presentation</param>
        /// <returns></returns>
        [HttpPost("CreateNewPresentation")]
        public StatusCodeResult AddField(Presentation presentation)
        {
            _context.Presentation.Add(presentation);
            return Ok( );
        }
    }
}
