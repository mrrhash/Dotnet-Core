﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class OrderMaster
    {
        [Key]
        public long OrderMasterID { get; set; }

        [Column(TypeName ="nvarchar(75)")]
        public string OrderNumber { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string PMethod { get; set; }

        public decimal GTotal { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
