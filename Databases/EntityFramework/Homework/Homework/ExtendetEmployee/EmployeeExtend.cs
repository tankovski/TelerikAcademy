using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntetiesData;


class EmployeeExtend : Employee
{
    public string TerritoryID { get; set; }
    public string TerritoryDescription { get; set; }
    public int RegionID { get; set; }
}

