using System;

namespace WEB.Ecommerce.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime OperationDate { get; set; }
        public string Action { get; set; }
        public string User { get; set; }
        public string Machine { get; set; }
        public string Message { get; set; }
    }
}