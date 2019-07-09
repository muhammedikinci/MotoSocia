using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class DataTransport
    {
        public IMotoDBContext _context { get; set; }
        public object Data { get; set; }
    }
}
