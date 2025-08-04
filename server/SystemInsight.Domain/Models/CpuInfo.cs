using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemInsight.Domain.Models
{
    public class CpuInfo
    {
        public string Name { get; set; }
        public int NumberOfCores { get; set; }
        public int MaxClockSpeedMHz { get; set; }
    }

}