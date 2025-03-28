﻿using System.ComponentModel;

namespace LeaveManagementSystem.Application.Models.LeaveType
{
    public class LeaveTypeEditVM : BaseLeaveTypeVM
    {
        [Required]
        [Length(4, 150, ErrorMessage = "Enter Correct Value")]
        public string Name { get; set; }

        [Required]
        [Range(1, 90)]
        [DisplayName("Maximum allocation of days")]
        public int NumberOfDays { get; set; }
    }
}
