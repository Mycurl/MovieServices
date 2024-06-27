using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Application.Messages
{
    public class SuccessResponseService
    {
        public string? SuccessCode { get; set; }
        public string? SuccessMessage { get; set; }
        public string? NotFoundCode { get; set; }
        public string? NotFoundMessage { get; set; }
        public string? FailureCode { get; set; }
        public string? FailureMessage { get; set; }
        public string? ErrorOccuredCode { get; set; }
        public string? ErrorOccuredMessage { get; set; }
    }
}
