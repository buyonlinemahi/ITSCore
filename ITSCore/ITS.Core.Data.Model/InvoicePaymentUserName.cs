﻿using System;
namespace ITS.Core.Data.Model
{

    public class InvoicePaymentUserName
    {
        public int InvoicePaymentID { get; set; }
        public int InvoiceID { get; set; }
        public decimal Payment { get; set; }
        public decimal AdjustedPayment { get; set; }
        public string CheckNumber { get; set; }
        public string BACS { get; set; }
        public int UserID { get; set; }
        public DateTime InvoicePaymentDate { get; set; }
        public string UserName { get; set; }
    }
}