using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCourseAPI.Modules
{
    public class Computer
    {
        public string Motherboard { get; set; } = "";
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleasedDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";

    }
}
