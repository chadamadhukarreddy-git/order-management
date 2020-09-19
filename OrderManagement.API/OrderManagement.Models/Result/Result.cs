using OrderManagement.Models.Contracts;

namespace OrderManagement.Models.Result
{
    public class Result : IResult
    {
        public bool IsSuccess { get; set; }
        public int ErrorNo { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }        
    }
}
