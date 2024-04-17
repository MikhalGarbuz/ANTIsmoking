using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTIsmoking.Models
{
    public class Chaser
    {
        private static int nextId = 1;
        public int id { get;private set; }
        public string name { get; set; }
        public int cum3 { get; set; }
        public int cum8 { get; set; }
        public int cum11 { get; set; }
        public int cum12 { get; set; }
        public int cum14 { get; set; }
        public Chaser()
        {
            id = nextId++;
        }
    }
}
