using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemInsight.Domain.Models
{
    public class SystemInfoDto
    {
        public string MachineName { get; set; }
        public string OSVersion { get; set; }
        public string Processor { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
    }
}