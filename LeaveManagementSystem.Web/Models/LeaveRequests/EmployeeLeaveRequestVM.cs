﻿using System.ComponentModel;

namespace LeaveManagementSystem.Web.Models.LeaveRequests
{
    public class EmployeeLeaveRequestListVM
    {
        [DisplayName("Total Number Of Requests")]
        public int TotalRequests {  get; set; }

        [DisplayName("Approved Requests")]
        public int ApprovedRequests { get; set; }

        [DisplayName("Pending Requests")]
        public int PendingRequests  { get; set; }

        [DisplayName("Rejected Requests")]
        public int RejectedRequests { get; set; }

        public List<LeaveRequestReadOnlyVM> LeaveRequests { get; set; } = [];
    }
}