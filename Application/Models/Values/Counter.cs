using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Models.Values
{
    public class Counter<T>
    {
        public int TotalCount { get; set; }
        [NotMapped]
        public List<T> CounterList { get; set; }
    }
}
