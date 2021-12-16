using PresentationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWebApi.Services.Interface
{
    public interface IVisitorWorker
    {
        public Visitors GetVisitor(int idVisitors);
        public bool AddVisitor(Visitors visitor);
        public bool ChangeVisitor(Visitors visitor);

    }
}
