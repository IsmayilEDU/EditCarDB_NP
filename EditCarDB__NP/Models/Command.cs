using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Command
    {
        public HTTPS Method { get; set; }
        public Car car { get; set; }
    }
}
