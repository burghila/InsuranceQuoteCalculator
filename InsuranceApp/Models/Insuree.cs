﻿using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Models
{
    public class Insuree
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int SpeedingTickets { get; set; }
        public bool HasDUI { get; set; }
        public bool CoverageType { get; set; }
        public decimal Quote { get; set; }
    }
}
