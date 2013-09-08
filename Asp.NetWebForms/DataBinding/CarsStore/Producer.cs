using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore
{
    public class Producer
    {
        public string Name { get; set; }
        public ICollection<string> Models { get; set; }

        public Producer()
        {
            this.Models = new List<string>();
        }
    }
}