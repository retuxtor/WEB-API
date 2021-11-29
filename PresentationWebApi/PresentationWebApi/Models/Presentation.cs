using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationService.Models
{
    [Table("presentation")]
    public class Presentation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public StatusPresentation Status { get; set; }
        public string Description { get; set; }
        public int QantityVisitors { get; set; }

        public enum StatusPresentation
        {
            Open,
            Close
        }
    }
}
