using Microsoft.AspNetCore.Mvc;
using PresentationService.Models;
using PresentationWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorContext _context;

        [HttpGet("GetAll")]
        public IEnumerable<Visitor> GetAllVisitors()
        {
            return _context.Visitor.ToList();
        }

    }
}
