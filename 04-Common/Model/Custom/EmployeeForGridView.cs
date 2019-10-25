﻿using System;

namespace Model.Custom
{
    public class EmployeeForGridView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public long HourlySalary { get; set; }
        public long MonthlySalary { get; set; }
        public long AnualSalary { get; set; }
    }
}
