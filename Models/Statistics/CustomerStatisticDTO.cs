using System;
using System.ComponentModel.DataAnnotations;

namespace Crm_CSharp.Models.Statistics
{
    public class CustomerStatisticsDTO
    {
        public string CustomerName { get; set; }
        
        public decimal TicketCount { get; set; }
        
        public decimal LeadCount { get; set; }
        
        public int CustomerId { get; set; }
        
        public decimal TotalBudget { get; set; }
    }
}