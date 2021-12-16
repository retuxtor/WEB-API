using PresentationService.Models;
using PresentationService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PresentationService.Services.Implementations
{
    public class PresentationWorker : IPresentationWorker
    {
        private readonly PresentationContext _context;
        public PresentationWorker(PresentationContext context)
        {
            _context = context;
        }

        public IEnumerable<Presentation> GetListPresentation(int qauntity)
        {
            return _context.Presentation.OrderBy(p => p.Id).Take(qauntity).ToList();
        }

        public Presentation GetPresentation(int idPresentation)
        {
            return _context.Presentation.Where(p => p.Id == idPresentation).FirstOrDefault();
        }

        public IEnumerable<Presentation> GetPresentationInDateInterval(DateTime dateFrom, DateTime dateTo)
        {
            return _context.Presentation.Where(p => p.Time >= dateFrom && p.Time <= dateTo);
        }

        public bool UpdateStatus()
        {
            var closeList = _context.Presentation.Where(p => p.Time < DateTime.Now).ToList();
            closeList.ForEach(p => p.Status = Presentation.StatusPresentation.Close);

            _context.SaveChanges();

            return true;
        }

        public bool AddPresentation(Presentation presentation)
        {
            _context.Presentation.Add(presentation);

            return true;
        }
    }
}
