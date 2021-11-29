using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationService.Models
{
    public class Visitor
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("dateofbirth")]
        public DateTime DateOfBirth { get; set; }
        [Column("gender")]
        public GenderType Gender { get; set; }
        [Column("phonenumber")]
        public string PhoneNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }

    public enum GenderType
    {
        Male,
        Female,
        None
    }
}
