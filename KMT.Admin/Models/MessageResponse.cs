using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.Admin.Models
{
    public class MessageResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public MessageResponse(int status,string message,object data=null)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}