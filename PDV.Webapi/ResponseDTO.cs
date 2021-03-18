using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Webapi
{
    public class ResponseDTO
    {
        public object Collections { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
    }
}
