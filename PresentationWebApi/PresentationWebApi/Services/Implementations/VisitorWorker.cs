using PresentationService.Models;
using PresentationWebApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWebApi.Services.Implementations
{
    public class VisitorWorker : IVisitorWorker
    {
        private readonly PresentationContext _context;
        public VisitorWorker(PresentationContext context) => _context = context;

        public Visitors GetVisitor(int idVisitors)
        {
            return _context.Visitors.Where(p => p.Id == idVisitors).FirstOrDefault();
        }

        public bool AddVisitor(Visitors visitor)
        {
            var status = false;

            _context.Add(visitor);
            status = true;

            return status;
        }
        public bool ChangeVisitor(Visitors visitor)
        {
            var status = false;

            var currentVisitor = _context.Visitors.Where(p => p.Id == visitor.Id).FirstOrDefault();
            currentVisitor.Name = visitor.Name;
            currentVisitor.PhoneNumber = visitor.PhoneNumber;
            currentVisitor.Email = visitor.Email;
            currentVisitor.DateOfBirth = visitor.DateOfBirth;

            _context.SaveChanges();

            status = true;

            return status;
        }
    }
}
