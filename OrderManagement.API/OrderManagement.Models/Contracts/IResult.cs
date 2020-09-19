using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Models.Contracts
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        int ErrorNo { get; set; }
        string Message { get; set; }
        dynamic Data { get; set; }
    }
}
