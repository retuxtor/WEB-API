﻿using System;

namespace PresentationService.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public enum GenderType
    {
        Male,
        Female,
        None
    }
}
