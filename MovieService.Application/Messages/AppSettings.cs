using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Application.Messages
{
    public class AppSettings
    {
        public string? ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public object? ResponseData { get; set; }
    }
}
