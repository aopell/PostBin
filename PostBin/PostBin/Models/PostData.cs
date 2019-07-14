using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostBin.Models
{
    public class PostData
    {
        public JObject Data { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
