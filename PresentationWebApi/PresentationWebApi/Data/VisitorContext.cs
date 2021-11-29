using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PresentationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWebApi.Data
{
    public class VisitorContext : DbContext
    {
        public VisitorContext(DbContextOptions<VisitorContext> options) : base(options)
        {
        }

        public DbSet<Visitor> Visitor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
