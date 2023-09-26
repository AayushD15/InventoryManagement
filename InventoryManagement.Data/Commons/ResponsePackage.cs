using System;
using System.Collections.Generic;
using System.Text;

namespace BackendData.Domain.Commons
{
    public class ResponsePackage<T>
    {
        public List<T> Items { get; set; }
        public int PageSize { get; set;}    
        public int CurrentPage { get; set;}
        public int TotalRecords { get; set; }
        internal void Add(T record)
        {
            if (Items == null) Items = new List<T>();
            Items.Add(record);
        }
    }

}
