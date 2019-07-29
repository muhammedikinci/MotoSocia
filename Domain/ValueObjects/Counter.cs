using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    public class Counter<T>
    {
        public int TotalCount { get; set; }
        [NotMapped]
        public List<T> CounterList { get; set; }
    }
}
