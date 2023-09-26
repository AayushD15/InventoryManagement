using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace BackendData.Domain.Commons
{
    public class ListQuery<T>
    {
        public string QueryType { get; set; }
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int TotalRecords { get; set; }
        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }
        public void AddParameter(Parameter p)
        {
            if (Parameters == null) Parameters = new List<Parameter>();
            this.Parameters.Add(p);
        }

    }

    public class Parameter
    {
        public string Name { get; set; }
        public string Value { get; set; }

    }
}
