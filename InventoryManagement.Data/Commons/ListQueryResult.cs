using System;
using System.Collections.Generic;
using System.Text;

namespace BackendData.Domain.Commons
{
    public class ListQueryResult<T>
    {
        public int TotalRecords { get; set; }
        public List<T> Items { get; set; }
    }
}
