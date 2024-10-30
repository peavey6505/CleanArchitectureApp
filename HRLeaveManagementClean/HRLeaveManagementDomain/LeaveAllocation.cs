﻿using HRLeaveManagementDomain.Common;

namespace HRLeaveManagementDomain;

public class LeaveAllocation : BaseEntity
{
    public int NumberOfDays { get; set; }
    public LeaveType? LeaveType { get; set; }
    public int Period { get; set; }

}
